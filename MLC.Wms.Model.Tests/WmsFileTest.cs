using System;
using Microsoft.Practices.Unity;
using MLC.Wms.Bootstrap;
using MLC.Wms.Common;
using MLC.Wms.Common.Environment;
using MLC.Wms.Common.Environment.Impl;
using MLC.Wms.Common.LocalStorage;
using MLC.Wms.Model.Entities;
using NHibernate;
using NUnit.Framework;

namespace MLC.Wms.Model.Tests
{
    [TestFixture]
    public class WmsFileTest
    {
        private ISessionFactory _sessionFactory;

        private void Configure(IUnityContainer container)
        {
            _sessionFactory = container.Resolve<ISessionFactory>();

            container.RegisterType<IWmsEnvironmentInfoProvider, SvcWmsEnvironmentInfoProvider>(
                new ContainerControlledLifetimeManager());
            container.RegisterType<ILocalData, ThreadStaticLocalData>(new ContainerControlledLifetimeManager());
            WmsEnvironment.Init(container.Resolve<IWmsEnvironmentInfoProvider>(), container.Resolve<ILocalData>());
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            UnityConfig.RegisterComponents(Configure);
        }

        [Test]
        public void Test()
        {
            using (var session = _sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var file = new WmsFile()
                {
                    File2Entity = "ART_TEST_1",
                    FileKey = "Key_Test_1",
                    FileName = "Art_Test_1",

                    FileDesc = null,
                    FileSize = null,
                    FileLink = null,
                    FileVersion = null,
                    FileData = Convert.FromBase64String("TESTOLGA11223344")
                };

                session.Save(file);
                session.Flush();
                transaction.Rollback();
            }
        }
    }
}