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
using MLC.Wms.Api;
using MLC.Wms.Bootstrap;
using MLC.Wms.Common;
using MLC.Wms.Common.DataAccess;
using MLC.Wms.Common.Environment;
using MLC.Wms.Common.Environment.Impl;
using MLC.Wms.Common.LocalStorage;
using MLC.Wms.Integration.Common;
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
    public class OrderPackTest
    {
        private const string QueueMessageTypeCode = "ORDER_PACK";
        private const string MandantCode = "TST";
        private const string EventKindCode = "OWB_PACKING_END";

        private WorkflowIdentity _wfIdentity = new WorkflowIdentity("ORDER_PACK", new Version("1.0.0.0"), "INTEGRATION.OUT");
        private ORDER_PACK_1 _wf = new ORDER_PACK_1();
        private string _testName = "OrderPackTest_" + DateTime.UtcNow.ToString("yyMMddhhmmss").Trim();
        private IUnityContainer _container = new UnityContainer();
        private ISessionFactory _sessionFactory;

        [OneTimeSetUp]
        public void Setup()
        {
            UnityConfig.RegisterComponents(container =>
            {
                _container = container;

                container.RegisterType<IWmsEnvironmentInfoProvider, SvcWmsEnvironmentInfoProvider>(new ContainerControlledLifetimeManager());
                container.RegisterType<ILocalData, ThreadStaticLocalData>(new ContainerControlledLifetimeManager());
                WmsEnvironment.Init(container.Resolve<IWmsEnvironmentInfoProvider>(), container.Resolve<ILocalData>());

                container.RegisterType<IExtensionsFactory, ExtensionsFactory>();
                container.RegisterType<IWorkflowChildContainerConfigurator, StubWorkflowChildContainerConfigurator>();

                _container.RegisterType<IWorkflowLoader, FileWorkflowLoader>(new ContainerControlledLifetimeManager(), new InjectionFactory(cc => new FileWorkflowLoader(Directory.GetCurrentDirectory(), false)));

                _sessionFactory = _container.Resolve<ISessionFactory>();
            });
        }

        [Test]
        public void Test()
        {
            var sessionShareExtention = new SessionShareExtention();

            var mockWfStorage = new Mock<IWorkflowStorage>();
            mockWfStorage.Setup(i => i.Load(_wfIdentity)).Returns(_wf);
            var wfAppFactory = new WorkflowApplicationFactory(null as InstanceStore, mockWfStorage.Object);
            
            using (var childContainer = _container.CreateChildContainer())
            {
                childContainer.RegisterInstance<IWorkflowApplicationFactory>(wfAppFactory);
                childContainer.RegisterInstance(sessionShareExtention, new ContainerControlledLifetimeManager());

                using (var session = _sessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    var sessionDecorator = new SessionDecorator(session)
                    {
                        DoNotDispose = true,
                        ExternalTransaction = new TransactionDecorator(transaction)
                        {
                            DisableActions = true
                        }
                    };

                    var sessionFactoryMock = new Mock<ISessionFactory>();
                    sessionFactoryMock.Setup(i => i.OpenSession()).Returns(sessionDecorator);
                    sessionFactoryMock.Setup(i => i.OpenSession(It.IsAny<IInterceptor>())).Returns(sessionDecorator);

                    #region prepare data

                    var mandant = session.Query<WmsMandant>().FirstOrDefault(o => o.PartnerCode == MandantCode);
                    if (mandant == null)
                        throw new Exception(string.Format("Отсутствует тестовый мандант с кодом '{0}'", MandantCode));

                    var eventKind = session.Query<WmsEventKind>().FirstOrDefault(o => o.EventKindCode == EventKindCode);
                    if (eventKind == null)
                        throw new Exception(string.Format("Отсутствует вид события с кодом '{0}'", EventKindCode));

                    var partner = new WmsPartner
                    {
                        PartnerCode = _testName,
                        PartnerName = _testName,
                        PartnerLink2Mandant = mandant,
                        PartnerHostRef = _testName
                    };
                    session.Save(partner);

                    var owb = new WmsOWB
                    {
                        OWBName = _testName,
                        OWBType = "OWBTYPENORMAL",
                        OWBPriority = 500,
                        Status = session.Query<WmsOWBStatus>().FirstOrDefault(o => o.StatusCode == "OWB_ACTIVATED"),
                        Partner = mandant,
                        OWBProductNeed = "NOACTIVATE",
                        OWBCarrier = partner
                    };
                    session.Save(owb);

                    var iwb = new WmsIWB
                    {
                        IWBName = _testName,
                        IWBType = "IWBTYPENORMAL",
                        IWBPriority = 500,
                        Status = session.Query<WmsIWBStatus>().FirstOrDefault(o => o.StatusCode == "IWB_COMPLETED"),
                        Partner = mandant
                    };
                    session.Save(iwb);

                    #region Product

                    var tetype = new WmsTEType
                    {
                        TETypeCode = _testName,
                        TETypeName = _testName,
                        TETypeLength = 1000,
                        TETypeWidth = 1000,
                        TETypeHeight = 1000,
                        TETypeMaxWeight = 1000,
                    };
                    session.Save(tetype);

                    var placeType = new WmsPlaceType
                    {
                        PlaceTypeCode = _testName,
                        PlaceTypeName = _testName,
                        PlaceTypeCapacity = 100,
                        PlaceTypeLength = 10000,
                        PlaceTypeWidth = 10000,
                        PlaceTypeHeight = 10000,
                        PlaceTypeMaxWeight = 10000,
                    };
                    session.Save(placeType);

                    var placeClass = new WmsPlaceClass
                    {
                        PlaceClassCode = _testName,
                        PlaceClassName = _testName
                    };
                    session.Save(placeClass);

                    var receiveArea = new WmsReceiveArea
                    {
                        ReceiveAreaCode = _testName,
                        ReceiveAreaName = _testName
                    };
                    session.Save(receiveArea);

                    var supplyArea = new WmsSupplyArea
                    {
                        SupplyAreaCode = _testName,
                        SupplyAreaName = _testName
                    };
                    session.Save(supplyArea);

                    var motionArea = new WmsMotionArea
                    {
                        MotionAreaCode = _testName,
                        MotionAreaName = _testName
                    };
                    session.Save(motionArea);

                    var segmentType = new WmsSegmentType
                    {
                        SegmentTypeCode = _testName,
                        SegmentTypeName = _testName
                    };
                    session.Save(segmentType);

                    var areaType = new WmsAreaType
                    {
                        AreaTypeCode = _testName,
                        AreaTypeName = _testName
                    };
                    session.Save(areaType);

                    var warehouse = new WmsWarehouse
                    {
                        WarehouseCode = _testName,
                        WarehouseName = _testName
                    };
                    session.Save(warehouse);

                    var area = new WmsArea
                    {
                        AreaCode = _testName,
                        AreaName = _testName,
                        AreaType = areaType,
                        Warehouse = warehouse
                    };
                    session.Save(area);

                    var segment = new WmsSegment
                    {
                        SegmentCode = _testName,
                        SegmentNumber = _testName,
                        SegmentName = _testName,
                        SegmentType = segmentType,
                        Area = area
                    };
                    session.Save(segment);

                    var place = new WmsPlace
                    {
                        PlaceCode = _testName,
                        Segment = segment,
                        PlaceS = 1,
                        PlaceX = 1,
                        PlaceY = 1,
                        PlaceZ = 1,
                        PlaceCapacityMax = 100,
                        PlaceCapacity = 100,
                        Status = session.Query<WmsPlaceStatus>().FirstOrDefault(o => o.StatusCode == "PLC_FREE"),
                        PlaceName = _testName,
                        PlaceType = placeType,
                        PlaceClass = placeClass,
                        PlaceSortA = 1,
                        PlaceSortB = 1,
                        PlaceSortC = 1,
                        PlaceSortD = 1,
                        PlaceSortPick = 1,
                        ReceiveArea = receiveArea,
                        MotionArea = motionArea,
                        SupplyArea = supplyArea,
                        PlaceWeight = 10000,
                        PlaceWeightGroup = 10000
                    };
                    session.Save(place);

                    var te = new WmsTE
                    {
                        TECode = _testName,
                        TEType = tetype,
                        TECurrentPlace = place,
                        TECreationPlace = place.PlaceCode,
                        TELength = 1000,
                        TEWidth = 1000,
                        TEHeight = 1000,
                        Status = session.Query<WmsTEStatus>().FirstOrDefault(o => o.StatusCode == "TE_FREE"),
                        TEPackStatus = "TE_PKG_NONE",
                        TEWeight = 1000,
                        TEMaxWeight = 10000,
                        TETareWeight = 1000,

                    };
                    session.Save(te);

                    var art = new WmsArt
                    {
                        ArtCode = _testName,
                        ArtName = _testName,
                        Partner = mandant,
                        ArtABCD = 'A',
                        ArtTempMin = 1,
                        ArtTempMax = 1000,
                        ArtDeleted = false,
                        ArtManufacturer = mandant,
                        ArtType = _testName
                    };
                    session.Save(art);

                    var measureType = new WmsMeasureType
                    {
                        MeasureTypeCode = _testName,
                        MeasureTypeName = _testName
                    };
                    session.Save(measureType);

                    var measure = new WmsMeasure
                    {
                        MeasureCode = _testName,
                        MeasureType = measureType,
                        MeasurePrimary = true,
                        MeasureFactor = 1,
                        MeasureDefault = true,
                        MeasureShortName = "Test",
                        MeasureName = _testName,
                    };
                    session.Save(measure);

                    var sku = new WmsSKU
                    {
                        Art = art,
                        Measure = measure,
                        SKUCount = 1,
                        SKUPrimary = true,
                        SKUClient = false,
                        SKUIndivisible = true,
                        SKUParent = null,
                        SKUName = _testName

                    };
                    session.Save(sku);

                    var qlfDetail = new WmsQLFDetail
                    {
                        QLFDetailCode = _testName,
                        QLFDetailName = _testName
                    };
                    session.Save(qlfDetail);

                    var iwbPos = new WmsIWBPos
                    {
                        IWB = iwb,
                        IWBPosNumber = 1,
                        SKU = sku,
                        IWBPosCount = 1,
                        IWBPosCount2SKU = 1,
                        Status = session.Query<WmsIWBPosStatus>().SingleOrDefault(o => o.StatusCode == "IWBPOS_CREATED"),
                        QLF = session.Query<WmsQLF>().Single(o => o.QLFCode == "QLFNORMAL"),
                        IWBPosOwner = mandant
                    };
                    session.Save(iwbPos);

                    var owbPos = new WmsOWBPos
                    {
                        OWB = owb,
                        OWBPosNumber = 1,
                        SKU = sku,
                        OWBPosCount = 1,
                        OWBPosCount2SKU = 1,
                        OWBPosReserved = 1,
                        Status = session.Query<WmsOWBPosStatus>().SingleOrDefault(o => o.StatusCode == "OWBPOS_ACTIVATED"),
                        QLF = session.Query<WmsQLF>().Single(o => o.QLFCode == "QLFNORMAL"),
                        OWBPosOwner = mandant
                    };
                    session.Save(owbPos);

                    var factory = new WmsFactory
                    {
                        FactoryCode = "TST",
                        FactoryName = _testName,
                        Partner = mandant,
                        FactoryBatchCode = _testName

                    };
                    session.Save(factory);

                    var product = new WmsProduct
                    {
                        TE = te,
                        SKU = sku,
                        ProductCountSKU = 1,
                        ProductCount = 2,
                        ProductTTEQuantity = 3,
                        QLF = session.Query<WmsQLF>().Single(o => o.QLFCode == "QLFNORMAL"),
                        QLFDetail = qlfDetail,
                        ProductInputDate = DateTime.Now,
                        ProductInputDateMethod = session.Query<SYSENUM_ART_FIFO>().Single(i => i.EnumKey == "FIFO" && i.EnumValue == "YEAR"),
                        ProductDate = DateTime.Now,
                        ProductPack = "Pack",
                        ProductPackCountSKU = 4,
                        ProductExpiryDate = DateTime.Now,
                        ProductBatch = "Batch",
                        ProductLot = "Lot",
                        ProductSerialNumber = "Number",
                        ProductColor = "Color",
                        ProductTone = "Tone",
                        ProductSize = "Size",
                        Art = art,
                        Partner = mandant,
                        ProductOwner = mandant,
                        IWBPos = iwbPos,
                        OWBPos = owbPos,
                        Factory = factory,
                        Status = session.Query<WmsProductStatus>().SingleOrDefault(i => i.StatusCode == "PRODUCT_BUSY"),
                        ProductBatchCode = "BatchCode",
                        ProductBoxNumber = "BoxNumber",
                        ProductHostRef = "HostRef",
                        ProductKitArtName = "KitArtName",
                        ProductRoot = 5,
                        ProductPriority = 6,
                        Country = session.Query<IsoCountry>().SingleOrDefault(i => i.CountryCode == "RUS"),
                        ProductGTD = "GTD",
                        TransportTaskID_r = null
                    };
                    session.Save(product);

                    var ehPrd = new WmsEventHeader
                    {
                        Partner = mandant,
                        EventKind = session.Query<WmsEventKind>().FirstOrDefault(o => o.EventKindCode == "PRD_INPUT"),
                        Status = session.Query<WmsEventHeaderStatus>().FirstOrDefault(o => o.StatusCode == "EVENT_CREATED"),
                        ClientType = session.Query<SysClientType>().FirstOrDefault(o => o.ClientTypeCode == "DCL"),
                        EventHeaderBillStatus = session.Query<EventHeaderBillStatus>().FirstOrDefault(o => o.StatusCode == "EVENT_BILL_OPEN"),
                        EventHeaderOperationBusiness = session.Query<SYSENUM_OPERATION_BUSINESS>().FirstOrDefault(p => p.EnumGroup == "OPERATION" && p.EnumKey == "BUSINESS"),
                        Operation = session.Query<BillOperation>().First(),
                        EventHeaderInstance = "none"
                    };

                    var edPrd = new wmsEventDetailPRD
                    {
                        PARTNERID_R = mandant.PartnerID,
                        PRODUCTID_R = product.ProductID,
                        OLDPRODUCTID_R = product.ProductID,
                        EVENTKINDCODE_R = "PRD_INPUT"
                    };
                    #endregion

                    session.Flush();

                    var eventHeader = new WmsEventHeader
                    {
                        Partner = mandant,
                        EventKind = session.Query<WmsEventKind>().FirstOrDefault(o => o.EventKindCode == EventKindCode),
                        Status = session.Query<WmsEventHeaderStatus>().FirstOrDefault(o => o.StatusCode == "EVENT_CREATED"),
                        ClientType = session.Query<SysClientType>().FirstOrDefault(o => o.ClientTypeCode == "DCL"),
                        EventHeaderBillStatus = session.Query<EventHeaderBillStatus>().FirstOrDefault(o => o.StatusCode == "EVENT_BILL_OPEN"),
                        EventHeaderOperationBusiness = session.Query<SYSENUM_OPERATION_BUSINESS>().FirstOrDefault(p => p.EnumGroup == "OPERATION" && p.EnumKey == "BUSINESS"),
                        Operation = session.Query<BillOperation>().First(),
                        EventHeaderInstance = "none"
                    };

                    var eventDetailOwb = new wmsEventDetailOWB { OWBID_r = owb.OWBID, OWBName = owb.OWBName };

                    var api = new WmsAPI(sessionFactoryMock.Object, _container.Resolve<IWmsXmlConverter>(), _container.Resolve<IWorkflowLoader>());
                    api.RegEvent(session.GetSession(EntityMode.Poco), ehPrd, edPrd, null);
                    api.RegEvent(session.GetSession(EntityMode.Poco), eventHeader, eventDetailOwb, null);

                    var array =
                        session.Query<wmsEventDetailOWB>()
                            .Where(i => i.EventHeader.Partner.PartnerCode == MandantCode &&
                                        i.EventHeader.EventKind.EventKindCode == EventKindCode &&
                                        i.EventHeader.Status.StatusCode == "EVENT_CREATED" &&
                                        i.EventHeader.DateIns >= DateTime.Today.AddDays(-1) &&
                                        !session.Query<IoLaunchControl>()
                                            .Any(
                                                j =>
                                                    j.EventHeader == i.EventHeader &&
                                                    j.QueueMessageType.Code == EventKindCode &&
                                                    j.Mandant.PartnerCode == MandantCode))
                            .ToArray();

                    if (!array.Any())
                    {
                        throw new Exception("Нет данных для теста");
                    }

                    #endregion

                    sessionShareExtention.SharedSession = sessionDecorator;
                    
                    var inputs = new Dictionary<string, object>
                    {
                        {"ROUTE", "ROUTE=OMS"},
                        {"MandantCode", MandantCode},
                        {"BatchSize", "1"}
                    };

                    var service = childContainer.Resolve<WorkflowService>();
                    service.Run(_wfIdentity, inputs);

                    var lan = session.Query<IoLaunchControl>().FirstOrDefault(i => i.EventHeader != null && i.EventHeader.EventHeaderID == eventHeader.EventHeaderID);
                    lan.Should().NotBeNull("Не создали LanchControl");
                    
                    var qout = session.Query<IoQueueOut>()
                        .Where(i => i.Uri == string.Format("ENTITYKEY={0}; ENTITY = OWB", owb.OWBName) && i.QueueMessageType.Code == QueueMessageTypeCode)
                        .OrderByDescending(i => i.DateIns)
                        .First();
                    var data = SerializationHelper.Deserialize<WHSOWBCommandMessage>(qout.Data);
                    data.OWBList[0].ProductList.Count.ShouldBeEquivalentTo(1);
                    data.OWBList[0].ProductList[0].ID.ShouldBeEquivalentTo(product.ProductID);
                    data.OWBList[0].CargoSpaceList.Count().ShouldBeEquivalentTo(1);
                    data.OWBList[0].CargoSpaceList[0].Code.ShouldBeEquivalentTo(te.TECode);

                    transaction.Rollback();
                }
            }
        }
    }
}