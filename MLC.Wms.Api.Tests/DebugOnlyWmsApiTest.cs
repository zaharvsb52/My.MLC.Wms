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
using MLC.Wms.Common.Environment;
using MLC.Wms.Common.Environment.Impl;
using MLC.Wms.Common.LocalStorage;
using MLC.Wms.Model.Entities;
using NHibernate;
using NHibernate.Linq;
using NUnit.Framework;
using Moq;

namespace MLC.Wms.Api.Tests
{
    [TestFixture]
    [Ignore("Используется только для отладки. Запускается вручную")]
    public class DebugOnlyWmsApiTest
    {
        [Test]
        public void DoTest()
        {
            UnityConfig.RegisterComponents(container =>
            {
                //var factory = container.Resolve<ISessionFactory>();

                container.RegisterType<IWmsEnvironmentInfoProvider, SvcWmsEnvironmentInfoProvider>(new ContainerControlledLifetimeManager());
                container.RegisterType<ILocalData, ThreadStaticLocalData>(new ContainerControlledLifetimeManager());
                WmsEnvironment.Init(container.Resolve<IWmsEnvironmentInfoProvider>(), container.Resolve<ILocalData>());
                container.RegisterType<IWorkflowLoader, FileWorkflowLoader>(new ContainerControlledLifetimeManager(), new InjectionFactory(c => new FileWorkflowLoader(Directory.GetCurrentDirectory(), false)));

                //var classMetadata = factory.GetClassMetadata(typeof(WmsEventHeader).Name);
                //var userMetadata = classMetadata as NHibernate.Persister.Entity.AbstractEntityPersister;
                //if (userMetadata != null)
                //{
                //    var cols = userMetadata.KeyColumnNames;
                //    var table = userMetadata.TableName;

                //    //userMetadata.SubclassColumnClosure
                //    var t = userMetadata.GetSubclassPropertyColumnNames("EventKind");
                //}

                var api = container.Resolve<WmsAPI>();

                //api.ChangeOwnerByOwb(14249, "OP_OPERATOR_OWBPROCESSING", "WEB", null);

                //api.RegEvent(null, new WmsEventHeader(), new wmsEventDetailPRD(), null);
                //api.RegEvent(factory.OpenSession(), new WmsEventHeader(), new wmsEventDetailPRD(), null);

                //var prev = "SDCL_DEBUG";
                //var res = api.GetSdclEndPoint("P8Z77-002", prev, null);
                //var prev = "";
                //var res = api.GetSdclEndPoint("P8H61-047", prev, null);

                //var res = api.GetEntityMappingByWmsEntity("TE");

                //var eventHeader = new WmsEventHeader
                //{
                //    Partner = new WmsMandant { PartnerID = 5 },
                //    Operation = new BillOperation { OperationCode = "OP_OPERATOR_OWBOUTPUT" },
                //    EventKind = new WmsEventKind { EventKindCode = "PRD_OUTPUT" },
                //    EventHeaderStartTime = new DateTime(2014, 6, 18, 11, 17, 22), //18.06.2014 11:17:22
                //    ClientSession = null,
                //    ClientType = new SysClientType { ClientTypeCode = "DCL" },
                //    EventHeaderInstance = "WmsApi"
                //};
                //var eventDetail = new wmsEventDetailPRD
                //{
                //    ProductID_r = 22111 //17821
                //};

                //api.RegEvent(null, eventHeader, eventDetail, null);

                //var res = api.RegEventPl(5002, "OP_PICKING_TERM", "PRD_PICK", 72134, "RCL", null, null, 7150, 142484, "37GS2012031001003", null);
                //var res = api.ValidatePlace("41M25006018002004", "EU216074", true, true, null);

                //api.ReserveOwbList(new[] {1,2}, "OP_OPERATOR_OWBPROCESSING", null);

                //api.IntegrationInSetOrderReserve(14687);


                //Отчёты
                //api.ExecuteEpsJob("C_SENDAPP", "Test", null);
                //var res = api.GetDefaultPrinter("TListParams(TParam('REPORT_R','MX-1',null),TParam('HOST_R','B75M-001',null))");
                //api.PrintReport("CstReqCustoms_test1", "Glebachev_YV", null); //"http://localhost/epsapi/v1/eps/print"

                //var res = api.GetEpsConfig();
                //return;

                api.PrintReport("CstReqCustoms_test1", "Glebachev_YV", new Dictionary<string, object>
                {
                    {
                        "ResultReportFile",
                        "${SQL=select 'MO_OWB_Order_'||'{OWBID}'||'_'|| TO_CHAR(sysdate,'ddMMyyyy') from dual}"
                    },
                    {"OWBID", 171579 }
                }, null);
                //Отчёты
            });
        }

        [Test]
        public void TestWorkflowLoader()
        {
            UnityConfig.RegisterComponents(container =>
            {
                container.RegisterType<IWmsEnvironmentInfoProvider, SvcWmsEnvironmentInfoProvider>(new ContainerControlledLifetimeManager());
                container.RegisterType<ILocalData, ThreadStaticLocalData>(new ContainerControlledLifetimeManager());
                WmsEnvironment.Init(container.Resolve<IWmsEnvironmentInfoProvider>(), container.Resolve<ILocalData>());
                var path = Directory.GetCurrentDirectory();
                path = path.Replace("MLC.Wms.Api.Tests\\bin\\Debug", "MLC.Wms.Workflows\\Wf_Data");

                container.RegisterType<IWorkflowLoader, FileWorkflowLoader>(new ContainerControlledLifetimeManager(), new InjectionFactory(c => new FileWorkflowLoader(path, true)));

                var api = container.Resolve<WmsAPI>();
                var res1 = api.GetWorkflow("CLIENT", "PIN_CREATE", "1.0.0.0");
                res1.Should().NotBe("Can't get body WF Client.Pin_Create");
            });
        }
    }
}
