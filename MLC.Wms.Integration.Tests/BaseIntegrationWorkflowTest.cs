using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities;
using System.Activities.Statements;
using System.Reflection;
using System.Runtime.DurableInstancing;
using Microsoft.CSharp.Activities;
using Microsoft.Practices.Unity;
using MLC.WF.Activities;
using System.Diagnostics;
using MLC.WF.Activities.Communication;
using MLC.WF.Activities.DataAccess;
using MLC.WF.Core.Common;
using MLC.WF.Core.Common.Impl;
using MLC.WF.Core.Extensions;
using MLC.Wms.Integration.Common.Exceptions;
using MLC.Wms.Model.Entities;
using Moq;
using NHibernate;
using NHibernate.Linq;

namespace MLC.Wms.Integration.Tests
{
    internal abstract class BaseIntegrationWorkflowTest : BaseManualExecuteFixture
    {
        #region .  Prop&Consts  .

        public const string DefaultCheckerMethodName = "CheckMethod";
        public Activity InArgumentWorkflow { get; set; }
        private static readonly WorkflowIdentity OuterWfidentity = new WorkflowIdentity("OUTER", null, null);
        private static readonly WorkflowIdentity InnerWfIdentity = new WorkflowIdentity("INNER", null, null);

        public class CheckActivity : NativeActivity
        {
            public InArgument<Type> TestType { get; set; }
            public InArgument<string> CheckerMethodName { get; set; }

            protected override void Execute(NativeActivityContext context)
            {
                var type = context.GetValue(TestType);
                var method = context.GetValue(CheckerMethodName);

                if (string.IsNullOrEmpty(method))
                    throw new Exception("Не передано имя метода проверки");

                var sessionExtension = context.GetExtension<SessionShareExtention>();
                type.GetMethod(method, BindingFlags.Public | BindingFlags.Static)
                    .Invoke(null, new object[] { sessionExtension.SharedSession });
            }
        }

        public class GetTestQueueInActivity : NativeActivity
        {
            public InArgument<Type> TestType { get; set; }
            public InArgument<string> GetMethodName { get; set; }
            public OutArgument<IoQueueIn> QueueIn { get; set; }
            public OutArgument<string> MandantCode { get; set; }

            protected override void Execute(NativeActivityContext context)
            {
                var type = context.GetValue(TestType);
                var method = context.GetValue(GetMethodName);

                var sessionExtension = context.GetExtension<SessionShareExtention>();
                var methodInvoker = type.GetMethod(method, BindingFlags.Public | BindingFlags.Static);

                if (methodInvoker == null)
                    throw new Exception(string.Format("Не найден метод {0} в типе {1} ", method, type.FullName));

                var queUeIn = methodInvoker.Invoke(null, new object[] { sessionExtension.SharedSession });

                if (queUeIn == null)
                    throw new Exception("Не удалось получить входные данные QueueMessage (OmsQueUeIn)");

                if (!(queUeIn is IoQueueIn))
                    throw new Exception(
                        String.Format("Получени тип данных {0} .Входные данные должны иметь тип OmsQueUeIn",
                            queUeIn.GetType()));


                if (!sessionExtension.SharedSession.Contains(queUeIn))
                    sessionExtension.SharedSession.Save(queUeIn);
                QueueIn.Set(context, queUeIn);
                MandantCode.Set(context,((IoQueueIn)queUeIn).Mandant.PartnerCode);
            }
        }

        #endregion

        #region .  Methods  .

        public void ExecuteWorkFlowIntegrationTest(IUnityContainer container, Type testType, string getQueueMessageName,
            string checkMethodName)
        {
            var typeStr = string.Format("System.Type.GetType(\"{0}, {1}\")", testType.FullName,
                testType.Assembly.GetName().Name);
            var queueMessageVar = new Variable<IoQueueIn>("QueueMessage");
            var queueMandantCode = new Variable<string>("MandantCode");
            var outerActivity = new DynamicActivity
            {
                Name = "OUTER",
                Implementation = () => new TryCatch()
                {
                    Try = new SessionScope()
                    {
                        Body = new Sequence
                        {
                            Variables =
                            {
                                queueMessageVar,
                                queueMandantCode
                            },
                            Activities =
                            {
                                new GetTestQueueInActivity()
                                {
                                    TestType = new InArgument<Type>(new CSharpValue<Type>(typeStr)),
                                    GetMethodName = new InArgument<string>(getQueueMessageName),
                                    QueueIn = new OutArgument<IoQueueIn>(queueMessageVar),
                                    MandantCode = new OutArgument<string>(queueMandantCode)
                                },
                                new ExecuteWorkflow
                                {
                                    Inputs = new InArgument<IDictionary<string, object>>(
                                        new CSharpValue<IDictionary<string, object>>(
                                            "new Dictionary<string, object>() { {\"QueueMessage\", QueueMessage }, {\"MandantCode\", MandantCode }  }"
                                            )
                                        ),
                                    Identity = new InArgument<WorkflowIdentity>(
                                        new CSharpValue<WorkflowIdentity>(
                                            string.Format(
                                                "new WorkflowIdentity(\"{0}\", null, null)",
                                                InnerWfIdentity.Name))
                                        )
                                },
                                new CheckActivity()
                                {
                                    TestType = new InArgument<Type>(new CSharpValue<Type>(typeStr)),
                                    CheckerMethodName = new InArgument<string>(checkMethodName)
                                }
                                ,
                                {
                                    new Throw()
                                    {
                                        Exception =
                                            new InArgument<Exception>(
                                                new CSharpValue<Exception>(
                                                    "new NotImplementedException(\"Откат транзакции\")"))
                                    }
                                }
                            }
                        }
                    },
                    Catches =
                    {
                        new Catch<NotImplementedException>()
                    }
                }
            };

            var knownTypes = new[] { typeof(Dictionary<string, object>), typeof(IoQueueIn), testType };
            ActivityHelper.CompileExpressions(outerActivity, knownTypes);

            var inputs = new Dictionary<string, object>();
            var service = GetWfService(container, outerActivity, InnerWfIdentity, InArgumentWorkflow);
            try
            {
                service.Run(OuterWfidentity, inputs);
            }
            catch (TechnicalIntegrationException e)
            {
                var errorMessage = e.ErrorMessage;
                if (errorMessage != null && errorMessage.ErrorInfoList != null && errorMessage.ErrorInfoList.Any())
                {
                    var allMessages = errorMessage.ErrorInfoList.Aggregate(string.Empty, (current, errorInfo) => current + (errorInfo.Message + Environment.NewLine));
                    var resException = new TechnicalIntegrationException(allMessages) { CallStack = errorMessage.ErrorInfoList.First().CallStack };
                    throw resException;
                }
                throw;
            }
        }

        protected static IWorkflowService GetWfService(IUnityContainer container, Activity outerActivity,
            WorkflowIdentity innerIdentity, Activity innerActivity)
        {
            var mockWfStorage = new Mock<IWorkflowStorage>();

            mockWfStorage.Setup(i => i.Load(OuterWfidentity)).Returns(outerActivity);
            mockWfStorage.Setup(i => i.Load(innerIdentity)).Returns(innerActivity);

            var wfAppFactory = new WorkflowApplicationFactory(null as InstanceStore, mockWfStorage.Object);

            container.RegisterInstance<IWorkflowApplicationFactory>(wfAppFactory);
            container.RegisterType<IWorkflowChildContainerConfigurator, StubWorkflowChildContainerConfigurator>();
            var extensionsFactory = new ExtensionsFactory(container);
            return new WorkflowService(wfAppFactory, extensionsFactory);
        }

        public void ExecuteWorkflowTest(Type testType, string getQueueMessageName, string checkMethodName)
        {
            WithChildContainer(container =>
            {
                ExecuteWorkFlowIntegrationTest(container, testType, getQueueMessageName, checkMethodName);
            });
        }

        public static WmsMandant GetTstMandant(ISession session, string code = "TST")
        {
            var mandant = session.Query<WmsMandant>().FirstOrDefault(o => o.PartnerCode == code);
            if (mandant == null)
                throw new Exception(string.Format("Отсутствует мандант {0}", code));
            return mandant;
        }

        #endregion
    }
}
