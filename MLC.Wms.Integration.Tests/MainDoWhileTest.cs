using System;
using System.Activities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.DurableInstancing;
using FluentAssertions;
using Microsoft.Practices.Unity;
using MLC.WF.Core.Common;
using MLC.WF.Core.Common.Impl;
using MLC.WF.Core.Extensions;
using MLC.Wms.Bootstrap;
using MLC.Wms.Common;
using MLC.Wms.Common.Environment;
using MLC.Wms.Common.Environment.Impl;
using MLC.Wms.Common.LocalStorage;
using MLC.Wms.Integration.Common;
using MLC.Wms.Integration.Common.Exceptions;
using MLC.Wms.Integration.Common.Message;
using MLC.Wms.Model.Entities;
using MLC.Wms.Workflows.Wf_Data;
using Moq;
using NHibernate;
using NHibernate.Linq;
using NUnit.Framework;

namespace MLC.Wms.Integration.Tests
{
    [TestFixture]
    public class MainDoWhileTest
    {
        const string WfPackageName = "Test";
        const string WfVersion = "1.1.1.1";

        private IUnityContainer _container = new UnityContainer();
        private readonly WorkflowIdentity _mainDoWhileWfIdentity = new WorkflowIdentity("Run_Do_While", null, null);
        private ISessionFactory _sessionFactory;
        private static string _messageTypeCode;

        [OneTimeSetUp]
        public void Setup()
        {
            UnityConfig.RegisterComponents(container =>
            {
                _container = container;

                container.RegisterType<IWmsEnvironmentInfoProvider, SvcWmsEnvironmentInfoProvider>(
                    new ContainerControlledLifetimeManager());
                container.RegisterType<ILocalData, ThreadStaticLocalData>(new ContainerControlledLifetimeManager());
                WmsEnvironment.Init(container.Resolve<IWmsEnvironmentInfoProvider>(), container.Resolve<ILocalData>());

                container.RegisterType<IExtensionsFactory, ExtensionsFactory>();
                container.RegisterType<IWorkflowChildContainerConfigurator, StubWorkflowChildContainerConfigurator>();

                _sessionFactory = _container.Resolve<ISessionFactory>();
            });
        }

        private string GetWfFullName(string wfName)
        {
            return WfPackageName + "$" + wfName + "$" + WfVersion;
        }

        private Activity GetContentWf(NativeActivity implementation)
        {
            var queueMessage = new InArgument<IoQueueIn>();
            var mandantCode = new InArgument<string>();

            return new DynamicActivity
            {
                Name = "Default",
                Properties =
                {
                    new DynamicActivityProperty
                    {
                        Name = "QueueMessage",
                        Type = queueMessage.GetType(),
                        Value = queueMessage
                    },
                    new DynamicActivityProperty
                    {
                        Name = "MandantCode",
                        Type = mandantCode.GetType(),
                        Value = mandantCode
                    }
                },
                Implementation = () => implementation
            };
        }

        private static void Error()
        {
            throw new Exception("MyException");
        }

        private static void TechnicalError()
        {
            throw new TechnicalIntegrationException("MainDoWhile_Test") {QueueMessageTypeName = _messageTypeCode };
        }

        private WorkflowApplicationFactory GetWfFactory(WorkflowIdentity wfIdentity, NativeActivity implementation, bool loadContentWf = true)
        {
            var mockWfStorage = new Mock<IWorkflowStorage>();
            mockWfStorage.Setup(i => i.Load(_mainDoWhileWfIdentity)).Returns(new INTEGRATION_IN_MAIN());
            if (loadContentWf)
                mockWfStorage.Setup(i => i.Load(wfIdentity)).Returns(GetContentWf(implementation));
            else
                mockWfStorage.Setup(i => i.Load(wfIdentity)).Throws(new FileNotFoundException());

            return new WorkflowApplicationFactory(null as InstanceStore, mockWfStorage.Object);
        }

        private WorkflowApplicationFactory GetWfFactory(WorkflowIdentity wfIdentity, Activity wf, bool loadContentWf = true)
        {
            var mockWfStorage = new Mock<IWorkflowStorage>();
            mockWfStorage.Setup(i => i.Load(_mainDoWhileWfIdentity)).Returns(new INTEGRATION_IN_MAIN());
            if (loadContentWf)
                mockWfStorage.Setup(i => i.Load(wfIdentity)).Returns(wf);
            return new WorkflowApplicationFactory(null as InstanceStore, mockWfStorage.Object);
        }

        private static IoQueueIn CreateQueueIn(ISession session)
        {
            var partner = session.Query<WmsMandant>().FirstOrDefault();
            if (partner == null)
                throw new Exception("Отсутствует партнёр для тестирования");

            var queueMessageType = session.Query<IoQueueMessageType>().FirstOrDefault();
            if (queueMessageType == null)
                throw new Exception("Отсутствует тип сообщения для тестирования");

            _messageTypeCode = queueMessageType.Code;

            return new IoQueueIn
            {
                Mandant = partner,
                QueueMessageType = queueMessageType,
                QueueMessageState = QueueMessageStates.Ready,
                Message = "Test Do While",
                Data = SerializationHelper.SerializeToBytes(new WHSOWBCommandMessage()
                {
                    CommandList = new List<Command>()
                    {
                        new Command() {Name = "ClientFileName", Value = "testMain"}
                    }
                })
            };
        }

        [Test]
        public void Dont_do_anything_when_no_ready_queue()
        {
            var contentWfName = "I_DONT_MAKE_PROBLEMS";
            var sessionShareExtention = new SessionShareExtention();
            var customActivity = new CustomActivity();
            var wfIdentity = new WorkflowIdentity(contentWfName, new Version(WfVersion), WfPackageName);
            var wfAppFactory = GetWfFactory(wfIdentity, customActivity);

            using (var childContainer = _container.CreateChildContainer())
            {
                childContainer.RegisterInstance<IWorkflowApplicationFactory>(wfAppFactory);
                childContainer.RegisterInstance(sessionShareExtention);

                using (var session = _sessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    sessionShareExtention.SharedSession = session;

                    var queueIn = CreateQueueIn(session);
                    session.Save(queueIn);
                    var queueList = session.Query<IoQueueIn>().Where(i => i.Mandant.PartnerCode == queueIn.Mandant.PartnerCode && i.QueueMessageType.Code == queueIn.QueueMessageType.Code);
                    foreach (var queue in queueList)
                    {
                        queue.QueueMessageState = QueueMessageStates.Completed;
                    }

                    var inputs = new Dictionary<string, object>
                    {
                        {"ContentWorkflowIdentity", GetWfFullName(contentWfName)},
                        {"MandantCode", queueIn.Mandant.PartnerCode},
                        {"QueueMessageTypeCode", queueIn.QueueMessageType.Code}
                    };
                    var service = childContainer.Resolve<TestWorkflowService>();
                    service.Run(_mainDoWhileWfIdentity, inputs);
                    customActivity.IsExecuted.Should().BeFalse();
                    transaction.Rollback();
                }
            }
        }

        [Test]
        public void Dont_do_anything_when_bad_input_parameters()
        {
            var contentWfName = "I_DONT_MAKE_PROBLEMS";
            var sessionShareExtention = new SessionShareExtention();
            var customActivity = new CustomActivity();
            var wfIdentity = new WorkflowIdentity(contentWfName, new Version(WfVersion), WfPackageName);
            var wfAppFactory = GetWfFactory(wfIdentity, customActivity);

            using (var childContainer = _container.CreateChildContainer())
            {
                childContainer.RegisterInstance<IWorkflowApplicationFactory>(wfAppFactory);
                childContainer.RegisterInstance(sessionShareExtention);

                using (var session = _sessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    sessionShareExtention.SharedSession = session;
                    
                    var inputs = new Dictionary<string, object>
                    {
                        {"ContentWorkflowIdentity", GetWfFullName(contentWfName)},
                        {"MandantCode", "NotExistingMandantCode"},
                        {"QueueMessageTypeCode", "NotExistingQueueMessageTypeCode"}
                    };
                    var service = childContainer.Resolve<TestWorkflowService>();
                    service.Run(_mainDoWhileWfIdentity, inputs);
                    customActivity.IsExecuted.Should().BeFalse();
                    transaction.Rollback();
                }
            }
        }

        [Test]
        public void Exception_when_content_wf_not_exist()
        {
            var contentWfName = "I_DONT_EXIST";
            var sessionShareExtention = new SessionShareExtention();
            var customActivity = new CustomActivity();
            var wfIdentity = new WorkflowIdentity(contentWfName, new Version(WfVersion), WfPackageName);
            var wfAppFactory = GetWfFactory(wfIdentity, customActivity, false);

            using (var childContainer = _container.CreateChildContainer())
            {
                childContainer.RegisterInstance<IWorkflowApplicationFactory>(wfAppFactory);
                childContainer.RegisterInstance(sessionShareExtention);

                using (var session = _sessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    sessionShareExtention.SharedSession = session;

                    var queueIn = CreateQueueIn(session);
                    session.Save(queueIn);

                    customActivity.IsAborted = true;
                    var inputs = new Dictionary<string, object>
                    {
                        {"ContentWorkflowIdentity", GetWfFullName(contentWfName)},
                        {"MandantCode", queueIn.Mandant.PartnerCode},
                        {"QueueMessageTypeCode", queueIn.QueueMessageType.Code}
                    };
                    var service = childContainer.Resolve<TestWorkflowService>();

                    service.Run(_mainDoWhileWfIdentity, inputs);
                    session.Refresh(queueIn);
                    queueIn.QueueMessageState.ShouldBeEquivalentTo(QueueMessageStates.Error);

                    transaction.Rollback();
                }
            }
        }

        [Test]
        public void QueueState_should_be_completed_when_all_right()
        {
            var contentWfName = "I_DONT_MAKE_PROBLEMS";
            var sessionShareExtention = new SessionShareExtention();
            var customActivity = new CustomActivity();
            var wfIdentity = new WorkflowIdentity(contentWfName, new Version(WfVersion), WfPackageName);
            var wfAppFactory = GetWfFactory(wfIdentity, customActivity);

            using (var childContainer = _container.CreateChildContainer())
            {
                childContainer.RegisterInstance<IWorkflowApplicationFactory>(wfAppFactory);
                childContainer.RegisterInstance(sessionShareExtention);

                using (var session = _sessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    sessionShareExtention.SharedSession = session;

                    var queueIn = CreateQueueIn(session);
                    session.Save(queueIn);

                    var inputs = new Dictionary<string, object>
                    {
                        {"ContentWorkflowIdentity", GetWfFullName(contentWfName)},
                        {"MandantCode", queueIn.Mandant.PartnerCode},
                        {"QueueMessageTypeCode", queueIn.QueueMessageType.Code}
                    };
                    var service = childContainer.Resolve<TestWorkflowService>();
                    service.Run(_mainDoWhileWfIdentity, inputs);
                    customActivity.IsExecuted.Should().BeTrue();
                    queueIn.QueueMessageState.Should().Be(QueueMessageStates.Completed);
                    transaction.Rollback();
                }
            }
        }

        [Test]
        public void QueueState_should_be_error_when_content_wf_exception()
        {
            var contentWfName = "I_THROW_EXCEPTION";
            var sessionShareExtention = new SessionShareExtention();
            var customActivity = new CustomActivity(Error);
            var wfIdentity = new WorkflowIdentity(contentWfName, new Version(WfVersion), WfPackageName);
            var wfAppFactory = GetWfFactory(wfIdentity, customActivity);

            using (var childContainer = _container.CreateChildContainer())
            {
                childContainer.RegisterInstance<IWorkflowApplicationFactory>(wfAppFactory);
                childContainer.RegisterInstance(sessionShareExtention);

                using (var session = _sessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    sessionShareExtention.SharedSession = session;

                    var queueIn = CreateQueueIn(session);
                    session.Save(queueIn);

                    var inputs = new Dictionary<string, object>
                    {
                        {"ContentWorkflowIdentity", GetWfFullName(contentWfName)},
                        {"MandantCode", queueIn.Mandant.PartnerCode},
                        {"QueueMessageTypeCode", queueIn.QueueMessageType.Code}
                    };
                    var service = childContainer.Resolve<TestWorkflowService>();
                    
                    service.Run(_mainDoWhileWfIdentity, inputs);
                    queueIn.QueueMessageState.Should().Be(QueueMessageStates.Error);
                    transaction.Rollback();
                }
            }
        }

        [Test]
        public void QueueState_should_make_queueOut_when_content_wf_tech_exception()
        {
            var contentWfName = "I_THROW_EXCEPTION";
            var sessionShareExtention = new SessionShareExtention();
            var customActivity = new CustomActivity(TechnicalError);
            var wfIdentity = new WorkflowIdentity(contentWfName, new Version(WfVersion), WfPackageName);
            var wfAppFactory = GetWfFactory(wfIdentity, customActivity);

            using (var childContainer = _container.CreateChildContainer())
            {
                childContainer.RegisterInstance<IWorkflowApplicationFactory>(wfAppFactory);
                childContainer.RegisterInstance(sessionShareExtention);

                using (var session = _sessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    sessionShareExtention.SharedSession = session;

                    var queueIn = CreateQueueIn(session);
                    session.Save(queueIn);

                    var inputs = new Dictionary<string, object>
                    {
                        {"ContentWorkflowIdentity", GetWfFullName(contentWfName)},
                        {"MandantCode", queueIn.Mandant.PartnerCode},
                        {"QueueMessageTypeCode", queueIn.QueueMessageType.Code}
                    };
                    var service = childContainer.Resolve<TestWorkflowService>();

                    service.Run(_mainDoWhileWfIdentity, inputs);
                    queueIn.QueueMessageState.Should().Be(QueueMessageStates.Error);
                    var queueOut = session.Query<IoQueueOut>().FirstOrDefault(x => x.QueueIn.ID.Equals(queueIn.ID));
                    queueOut.Should().NotBeNull();
                    transaction.Rollback();
                }
            }
        }

        [Test]
        public void QueueState_should_be_processing_while_processing()
        {
            var contentWfName = "I_DONT_MAKE_PROBLEMS";
            var sessionShareExtention = new SessionShareExtention();
            var customActivity = new CustomActivity();
            var wfIdentity = new WorkflowIdentity(contentWfName, new Version(WfVersion), WfPackageName);
            var wfAppFactory = GetWfFactory(wfIdentity, customActivity);

            using (var childContainer = _container.CreateChildContainer())
            {
                childContainer.RegisterInstance<IWorkflowApplicationFactory>(wfAppFactory);
                childContainer.RegisterInstance(sessionShareExtention);

                using (var session = _sessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    sessionShareExtention.SharedSession = session;

                    var queueIn = CreateQueueIn(session);
                    session.Save(queueIn);

                    var inputs = new Dictionary<string, object>
                    {
                        {"ContentWorkflowIdentity", GetWfFullName(contentWfName)},
                        {"MandantCode", queueIn.Mandant.PartnerCode},
                        {"QueueMessageTypeCode", queueIn.QueueMessageType.Code}
                    };
                    var service = childContainer.Resolve<TestWorkflowService>();
                    service.Run(_mainDoWhileWfIdentity, inputs);
                    customActivity.IsExecuted.Should().BeTrue();
                    queueIn.QueueMessageState.Should().Be(QueueMessageStates.Completed);
                    var queueHistory = session.Query<IoQueueInHistory>().Where(i => i.ID == queueIn.ID);
                    queueHistory.Select(i => i.QueueMessageState).Should().Contain(QueueMessageStates.Processing);
                    transaction.Rollback();
                }
            }
        }
    }

    public class TestWorkflowService : WorkflowService
    {
        public TestWorkflowService(IWorkflowApplicationFactory appFactory, IExtensionsFactory extensionsFactory) : base(appFactory, extensionsFactory)
        {

        }

        protected override void DisposeExtensions(IEnumerable<object> extensions)
        {

        }
    }

    public class CustomActivity : NativeActivity
    {
        private readonly Action _action;

        public bool IsExecuted { get; private set; }
        public bool IsAborted { get; set; }
        public bool IsCanceled { get; private set; }

        public CustomActivity()
        {
        }

        public CustomActivity(Action action)
        {
            _action = action;
        }

        protected override void Execute(NativeActivityContext context)
        {
            _action?.Invoke();
            IsExecuted = true;
        }

        protected override void Abort(NativeActivityAbortContext context)
        {
            base.Abort(context);
            IsAborted = true;
        }

        protected override void Cancel(NativeActivityContext context)
        {
            base.Cancel(context);
            IsCanceled = true;
        }
    }
}