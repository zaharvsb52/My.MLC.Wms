using System.Linq;
using Microsoft.Practices.Unity;
using MLC.Wms.Bootstrap;
using MLC.Wms.Common;
using MLC.Wms.Common.Environment;
using MLC.Wms.Common.Environment.Impl;
using MLC.Wms.Common.LocalStorage;
using MLC.Wms.Integration.Common;
using MLC.Wms.Integration.Common.Message;
using MLC.Wms.Model.Entities;
using NHibernate;
using NHibernate.Linq;
using NUnit.Framework;

namespace MLC.Wms.Integration.Tests
{
    [TestFixture]
    public class SerializationTest
    {
        [Test]
        public void Test()
        {
            UnityConfig.RegisterComponents(container =>
            {
                var factory = container.Resolve<ISessionFactory>();

                container.RegisterType<IWmsEnvironmentInfoProvider, SvcWmsEnvironmentInfoProvider>(new ContainerControlledLifetimeManager());
                container.RegisterType<ILocalData, ThreadStaticLocalData>(new ContainerControlledLifetimeManager());
                WmsEnvironment.Init(container.Resolve<IWmsEnvironmentInfoProvider>(), container.Resolve<ILocalData>());

                using (var session = factory.OpenSession())
                {
                    var qType = session.Query<IoQueueMessageType>().First(i => i.Code == "IP_LOAD_ART");
                    var q =
                        session.Query<IoQueueIn>()
                            .Where(i => i.QueueMessageType == qType)
                            .OrderBy(i => i.DateIns)
                            .First();
                    var result = SerializationHelper.Deserialize<ArticleLoad>(q.Data);
                }
            });
        }
    }
}