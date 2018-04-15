using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentAssertions;
using Microsoft.Practices.Unity;
using MLC.WF.Core.Common;
using MLC.WF.Core.Common.Impl;
using MLC.Wms.Bootstrap;
using MLC.Wms.Common;
using MLC.Wms.Common.DataAccess;
using MLC.Wms.Common.Environment;
using MLC.Wms.Common.Environment.Impl;
using MLC.Wms.Common.LocalStorage;
using MLC.Wms.Integration.Common;
using MLC.Wms.Integration.Common.Message;
using MLC.Wms.Model.Entities;
using Moq;
using NHibernate;
using NHibernate.Linq;
using NUnit.Framework;

namespace MLC.Wms.Api.Tests
{
    [TestFixture]
    public class WmsApiIntegrationInSetOrderReserveTest
    {

        private IUnityContainer _container;
        private ISessionFactory _sessionFactory;

        [OneTimeSetUp]
        public void Setup()
        {
            UnityConfig.RegisterComponents(p =>
            {
                _container = p;
                _sessionFactory = p.Resolve<ISessionFactory>();

                _container.RegisterType<IWmsEnvironmentInfoProvider, SvcWmsEnvironmentInfoProvider>(
                    new ContainerControlledLifetimeManager());
                _container.RegisterType<ILocalData, ThreadStaticLocalData>(new ContainerControlledLifetimeManager());
                WmsEnvironment.Init(_container.Resolve<IWmsEnvironmentInfoProvider>(), _container.Resolve<ILocalData>());
                _container.RegisterType<IWorkflowLoader, FileWorkflowLoader>(new ContainerControlledLifetimeManager(),
                    new InjectionFactory(cc => new FileWorkflowLoader(Directory.GetCurrentDirectory(), false)));
            });
        }

        /// <summary>
        ///     Создаём накладную в статусе OWB_CREATED.
        /// </summary>
        [Test]
        public void Test1()
        {
            using (var session = _sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var fakeSession = new SessionDecorator(session)
                {
                    DoNotDispose = true,
                    ExternalTransaction = new TransactionDecorator(transaction)
                    {
                        DisableActions = true
                    }
                };
                var mockSessionFactory = new Mock<ISessionFactory>();
                mockSessionFactory.Setup(i => i.OpenSession()).Returns(fakeSession);

                var tstMandant = session.Query<WmsMandant>().Single(i => i.PartnerCode == "TST");

                var owb = new WmsOWB
                {
                    Partner = tstMandant,
                    OWBName = "Owb for testing change owner",
                    OWBProductNeed = "NOACTIVATE",
                    OWBType = "OWBTYPENORMAL",
                    Status = session.Query<WmsOWBStatus>().Single(i => i.StatusCode == "OWB_CREATED")
                };

                session.Save(owb);

                // запускаем
                var api = new WmsAPI(mockSessionFactory.Object, _container.Resolve<IWmsXmlConverter>(), _container.Resolve<IWorkflowLoader>());
                api.IntegrationInSetOrderReserve(owb.OWBID); 

                //Ищем сообшение
                var ins =
                    session.Query<IoQueueIn>()
                        .Where(
                            p =>
                                p.Mandant == tstMandant && p.QueueMessageType.Code == "SET_ORDER_RESERVE" &&
                                p.QueueMessageState == QueueMessageStates.Ready && p.DateIns >= DateTime.Now.Date)
                        .ToArray();

                var testresult = new List<bool>();
                foreach (var que in ins)
                {
                    var message = SerializationHelper.Deserialize<UniversalCommandMessage>(que.Data);
                    if (message.CommandList.FirstOrDefault(p => p.Name == "OWBId" && p.Value == owb.OWBID.ToString()) !=
                        null)
                        testresult.Add(true);
                }

                testresult.Should().HaveCount(1);

                transaction.Rollback();
            }
        }
    }
}
