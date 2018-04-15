using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using FluentAssertions;
using Microsoft.Practices.Unity;
using MLC.Wms.Bootstrap;
using MLC.Wms.Common;
using MLC.Wms.Common.Environment;
using MLC.Wms.Common.Environment.Impl;
using MLC.Wms.Common.LocalStorage;
using MLC.Wms.Model.Entities;
using NHibernate;
using NHibernate.Linq;
using NUnit.Framework;

namespace MLC.Wms.Model.Tests
{
    [TestFixture]
    public class SimplePerformance
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

        /// <summary>
        /// Тестируется вариант получения записи по первичному ключу.
        /// Ручная проверка используется ли индекс при работе с Guid
        /// </summary>
        [Test]
        public void GetByIdTest()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var sw = new Stopwatch();
                sw.Start();

                var obj = session.Get<WmsTruckType>("AnyCode");

                sw.Stop();
                Console.WriteLine(sw.Elapsed);

                sw.Elapsed.Should().BeLessOrEqualTo(new TimeSpan(0, 0, 0, 0, 100));
            }
        }

        private void DoWithDbTrace(ISession session, string traceName, Action action)
        {
            int traceLevel = 12;
            var cmd = session.Connection.CreateCommand();
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "alter session set timed_statistics=true";
                cmd.ExecuteNonQuery();
                cmd.CommandText = string.Format("alter session set tracefile_identifier='{0}'", traceName);
                cmd.ExecuteNonQuery();
                cmd.CommandText = string.Format("alter session set events '10046 trace name context forever, level {0}'", traceLevel);
                cmd.ExecuteNonQuery();

                action();
            }
            finally
            {
                cmd.CommandText = "alter session set events '10046 trace name context off'";
                cmd.ExecuteNonQuery();
            }
        }
    }

    [TestFixture]
    public class WmsReportTest
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
            try
            {
                UnityConfig.RegisterComponents(Configure);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [Test, Ignore("http://mp-ts-nwms/issue/wmsMLC-11536")]
        public void Test()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var key = "MOExpInputInvoice";

                var job = session.Query<EpsJob>().First(i => i.JobCode == key);
                var jobParams = job.CFG_List.ToArray();
                var jobCpv = job.CPV_List.ToArray();

                var report = session.Query<WmsReport>().First(i => i.Report == key);
                var reportParams = report.CFG_List.ToArray();
                var reportCpv = report.CPV_List.ToArray();

                var task = session.Query<EpsTask>().First(i => i.TaskCode == key);
                var taskParams = task.CFG_List.ToArray();
                //var taskCpv = task.CPV_List.ToArray();
            }
        }
    }
}
