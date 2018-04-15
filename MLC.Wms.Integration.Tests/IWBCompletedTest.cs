using System;
using System.IO;
using System.Activities;
using System.Collections.Generic;
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
using Moq;
using NHibernate;
using NHibernate.Linq;
using NUnit.Framework;

namespace MLC.Wms.Integration.Tests
{
    [TestFixture]
    public class IWBCompletedTest
    {
        private IUnityContainer _container = new UnityContainer();
        private ISessionFactory _sessionFactory;
        private const string Name = "TestIwbCompleted";
        private DateTime timeNow = DateTime.Now;

        [TestFixtureSetUp]
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
        public void RunIWBCompleted()
        {
            var sessionShareExtention = new SessionShareExtention();
            var wfIdentity = new WorkflowIdentity("Run_Completed", new Version("1.0.0.0"), "Test");

            var mockWfStorage = new Mock<IWorkflowStorage>();
            mockWfStorage.Setup(i => i.Load(wfIdentity)).Returns(new IntegrationOutIWBCompleted());
            var wfAppFactory = new WorkflowApplicationFactory(null as InstanceStore, mockWfStorage.Object);

            var eventKindCode = "IWB_COMPLETED";
            var mandantCode = "TST";

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

                    var mandant = session.Query<WmsMandant>().FirstOrDefault(o => o.PartnerCode == mandantCode);
                    if (mandant == null)
                        throw new Exception(string.Format("Отсутствует тестовый мандант с кодом {0}", mandantCode));

                    var partner = new WmsPartner
                    {
                        PartnerCode = Name,
                        PartnerName = Name,
                        PartnerLink2Mandant = mandant,
                        PartnerHostRef = Name
                    };
                    session.Save(partner);

                    var owb = new WmsOWB
                    {
                        OWBName = Name,
                        OWBType = "OWBTYPENORMAL",
                        OWBPriority = 500,
                        Status = session.Query<WmsOWBStatus>().FirstOrDefault(o => o.StatusCode == "OWB_CREATED"),
                        Partner = mandant,
                        OWBProductNeed = "NOACTIVATE",
                        OWBPartnerOrder = "Test DSOrderReturn",
                        OWBCarrier = partner
                    };
                    session.Save(owb);

                    var iwb = new WmsIWB
                    {
                        IWBName = Name,
                        IWBType = "IWBTYPENORMAL",
                        IWBPriority = 500,
                        Status = session.Query<WmsIWBStatus>().FirstOrDefault(o => o.StatusCode == "IWB_COMPLETED"),
                        Partner = mandant,
                        OWBID_r = owb.OWBID
                    };
                    session.Save(iwb);

                    var cpv = new WmsIWBCPV
                    {
                        CPVValue = "Test",
                        IWB = iwb,
                        CustomParam = session.Query<WmsCustomParam>().Single(o => o.CustomParam2Entity == "IWB" && o.CustomParamCode == "IWBECommReturnDSOrder")
                    };
                    iwb.CPV_List.Add(cpv);
                    session.SaveOrUpdate(iwb);

                    #region Product

                    var tetype = new WmsTEType
                    {
                        TETypeCode = Name,
                        TETypeName = Name,
                        TETypeLength = 1000,
                        TETypeWidth = 1000,
                        TETypeHeight = 1000,
                        TETypeMaxWeight = 1000,
                    };
                    session.Save(tetype);

                    var placeType = new WmsPlaceType
                    {
                        PlaceTypeCode = Name,
                        PlaceTypeName = Name,
                        PlaceTypeCapacity = 100,
                        PlaceTypeLength = 10000,
                        PlaceTypeWidth = 10000,
                        PlaceTypeHeight = 10000,
                        PlaceTypeMaxWeight = 10000,
                    };
                    session.Save(placeType);

                    var placeClass = new WmsPlaceClass
                    {
                         PlaceClassCode = Name,
                         PlaceClassName = Name
                    };
                    session.Save(placeClass);

                    var receiveArea = new WmsReceiveArea
                    {
                        ReceiveAreaCode = Name,
                        ReceiveAreaName = Name
                    };
                    session.Save(receiveArea);

                    var supplyArea = new WmsSupplyArea
                    {
                        SupplyAreaCode = Name,
                        SupplyAreaName = Name
                    };
                    session.Save(supplyArea);

                    var motionArea = new WmsMotionArea
                    {
                        MotionAreaCode = Name,
                        MotionAreaName = Name
                    };
                    session.Save(motionArea);

                    var segmentType = new WmsSegmentType
                    {
                        SegmentTypeCode = Name,
                        SegmentTypeName = Name
                    };
                    session.Save(segmentType);

                    var areaType = new WmsAreaType
                    {
                        AreaTypeCode = Name,
                        AreaTypeName = Name
                    };
                    session.Save(areaType);

                    var warehouse = new WmsWarehouse
                    {
                        WarehouseCode = Name,
                        WarehouseName = Name
                    };
                    session.Save(warehouse);

                    var area = new WmsArea
                    {
                        AreaCode = Name,
                        AreaName = Name,
                        AreaType = areaType,
                        Warehouse = warehouse
                    };
                    session.Save(area);

                    var segment = new WmsSegment
                    {
                        SegmentCode = Name,
                        SegmentNumber = Name,
                        SegmentName = Name,
                        SegmentType = segmentType,
                        Area = area
                    };
                    session.Save(segment);

                    var place = new WmsPlace
                    {
                        PlaceCode = Name,
                        Segment = segment,
                        PlaceS = 1,
                        PlaceX = 1,
                        PlaceY = 1,
                        PlaceZ = 1,
                        PlaceCapacityMax = 100,
                        PlaceCapacity = 100,
                        Status = session.Query<WmsPlaceStatus>().FirstOrDefault(o => o.StatusCode == "PLC_FREE"),
                        PlaceName = Name,
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
                        TECode = Name,
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
                        ArtCode = Name,
                        ArtName = Name,
                        Partner = mandant,
                        ArtABCD= 'A',
                        ArtTempMin = 1,
                        ArtTempMax = 1000,
                        ArtDeleted = false,
                        ArtManufacturer = mandant,
                        ArtType = Name
                    };
                    session.Save(art);

                    var measureType = new WmsMeasureType
                    {
                        MeasureTypeCode = Name,
                        MeasureTypeName = Name
                    };
                    session.Save(measureType);

                    var measure = new WmsMeasure
                    {
                        MeasureCode = Name,
                        MeasureType = measureType,
                        MeasurePrimary = true,
                        MeasureFactor = 1,
                        MeasureDefault = true,
                        MeasureShortName = "Test",
                        MeasureName = Name,
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
                        SKUName = Name
       
                    };
                    session.Save(sku);

                    var qlfDetail = new WmsQLFDetail
                    {
                        QLFDetailCode = Name,
                        QLFDetailName = Name
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

                    var factory = new WmsFactory
                    {
                        FactoryCode = "TST",
                        FactoryName = Name,
                        Partner = mandant,
                        FactoryBatchCode = Name
                        
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
                        OWBPos = null,
                        Factory = factory,
                        Status = session.Query<WmsProductStatus>().SingleOrDefault(i => i.StatusCode == "PRODUCT_FREE"),
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
                        PARTNERID_R =  mandant.PartnerID,
                        PRODUCTID_R = product.ProductID,
                        OLDPRODUCTID_R = product.ProductID,
                        EVENTKINDCODE_R = "PRD_INPUT"
                    };
                    #endregion

                    session.Flush();

                    var eh = new WmsEventHeader
                    {
                        Partner = mandant,
                        EventKind = session.Query<WmsEventKind>().FirstOrDefault(o => o.EventKindCode == "IWB_COMPLETED"),
                        Status = session.Query<WmsEventHeaderStatus>().FirstOrDefault(o => o.StatusCode == "EVENT_CREATED"),
                        ClientType = session.Query<SysClientType>().FirstOrDefault(o => o.ClientTypeCode == "DCL"),
                        EventHeaderBillStatus = session.Query<EventHeaderBillStatus>().FirstOrDefault(o => o.StatusCode == "EVENT_BILL_OPEN"),
                        EventHeaderOperationBusiness = session.Query<SYSENUM_OPERATION_BUSINESS>().FirstOrDefault(p => p.EnumGroup == "OPERATION" && p.EnumKey == "BUSINESS"),
                        Operation = session.Query<BillOperation>().First(),
                        EventHeaderInstance = "none"
                    };

                    var ed = new wmsEventDetailIWB
                    {
                        Partner = mandant,
                        IWBID_r = iwb.IWBID,
                        IWBName_r = iwb.IWBName,
                        StatusCode_r = "EVENT_CREATED",
                        EventKindCode_r = "IWB_COMPLETED"
                    };

                    var api = new WmsAPI(sessionFactoryMock.Object, _container.Resolve<IWmsXmlConverter>(), _container.Resolve<IWorkflowLoader>());
                    api.RegEvent(session.GetSession(EntityMode.Poco), eh, ed, null);
                    api.RegEvent(session.GetSession(EntityMode.Poco), ehPrd, edPrd, null);

                    var res = session.Query<wmsEventDetailIWB>().FirstOrDefault(i => i.EventKindCode_r == "IWB_COMPLETED" && i.StatusCode_r == "EVENT_CREATED" && i.IWBName_r == iwb.IWBName);
                    var id = res.EventHeader.EventHeaderID;

                    var array =
                        session.Query<wmsEventDetailIWB>()
                            .Where(i => i.EventHeader.Partner.PartnerCode == mandantCode &&
                                        i.EventHeader.EventKind.EventKindCode == eventKindCode &&
                                        i.EventHeader.Status.StatusCode == "EVENT_CREATED" &&
                                        i.EventHeader.DateIns >= DateTime.Today.AddDays(-1) &&
                                        !session.Query<IoLaunchControl>()
                                            .Any(
                                                j =>
                                                    j.EventHeader == i.EventHeader &&
                                                    eventKindCode == j.QueueMessageType.Code &&
                                                    j.Mandant.PartnerCode == mandantCode))
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
                        {"MandantCode", mandantCode},
                        {"BatchSize", "1"}
                    };

                    var service = childContainer.Resolve<WorkflowService>();
                    service.Run(wfIdentity, inputs);

                    var lan = session.Query<IoLaunchControl>().FirstOrDefault(i => i.EventHeader != null && i.EventHeader.EventHeaderID == id);
                    lan.Should().NotBeNull("Не создали LanchControl");

                    var str = string.Format("ROUTE=OMS ENTITYKEY={0}; ENTITY=IWB", iwb.IWBName);
                    var qout = session.Query<IoQueueOut>().Single(i => i.Selector == str && i.RequiredProcessDate > timeNow);
                    var data = SerializationHelper.Deserialize<WHSIWBCommandMessage>(qout.Data);
                    data.CommandList.Single(i => i.Name == "DSOrderReturn" && i.Value == "Test");
                    data.IWBList[0].ProductList.Count.ShouldBeEquivalentTo(1);
                    data.IWBList[0].ProductList[0].ID.ShouldBeEquivalentTo(product.ProductID);

                    transaction.Rollback();
                }
            }
        }
    }
}