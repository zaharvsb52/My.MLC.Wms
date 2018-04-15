using System;
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
using MLC.Wms.Model.Entities;
using Moq;
using NHibernate;
using NHibernate.Linq;
using NUnit.Framework;

namespace MLC.Wms.Api.Tests
{
    [TestFixture]
    public class WmsApiChangeOwnerByOwbTest
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
        ///     Ожидаем ошибку.
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
                Action action = () => { api.ChangeOwnerByOwb(owb.OWBID, "OP_OPERATOR_OWBPROCESSING", "TEST", null); };

                action.ShouldThrow<Exception>().Which.Message.Should().Contain("в статусе 'OWB_CREATED' запрещена");

                transaction.Rollback();
            }
        }

        /// <summary>
        ///     Создаём накладную в статусе OWB_ACTIVATED и товар.
        ///     Ожидаем ошибку - смена владельца не требуется.
        /// </summary>
        [Test]
        public void Tes2()
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

                const string testName = "TestName";

                var tstMandant = session.Query<WmsMandant>().Single(i => i.PartnerCode == "TST");

                var owb = new WmsOWB
                {
                    Partner = tstMandant,
                    OWBName = "Owb for testing change owner",
                    OWBProductNeed = "NOACTIVATE",
                    OWBType = "OWBTYPENORMAL",
                    OWBOwner = tstMandant,
                    Status = session.Query<WmsOWBStatus>().Single(i => i.StatusCode == "OWB_ACTIVATED")
                };
                session.Save(owb);

                #region data

                var warehouse = new WmsWarehouse
                {
                    WarehouseCode = testName,
                    WarehouseName = testName
                };
                session.Save(warehouse);


                var areaType = new WmsAreaType
                {
                    AreaTypeCode = testName,
                    AreaTypeName = testName
                };
                session.Save(areaType);

                session.Save(new SysGlobalParamValue
                {
                    GParamVal2Entity = "AREATYPE",
                    GlobalParam = session.Query<SysGlobalParam>().Single(i => i.GlobalParamCode == "AreaDestination"),
                    GParamValKey = areaType.AreaTypeCode,
                    GParamValValue = "OUT"
                });

                var area = new WmsArea
                {
                    AreaCode = testName,
                    AreaName = testName,
                    Warehouse = warehouse,
                    AreaType = areaType
                };
                session.Save(area);

                var segmentType = new WmsSegmentType
                {
                    SegmentTypeCode = testName,
                    SegmentTypeName = testName
                };
                session.Save(segmentType);

                var segment = new WmsSegment
                {
                    SegmentCode = testName,
                    SegmentName = testName,
                    SegmentNumber = testName,
                    Area = area,
                    SegmentType = segmentType
                };
                session.Save(segment);

                var placeType = new WmsPlaceType
                {
                    PlaceTypeCode = testName,
                    PlaceTypeName = testName,
                    PlaceTypeMaxWeight = 200000,
                    PlaceTypeHeight = 200000,
                    PlaceTypeLength = 200000,
                    PlaceTypeWidth = 200000,
                    PlaceTypeCapacity = 200
                };
                session.Save(placeType);

                var placeClass = new WmsPlaceClass
                {
                    PlaceClassCode = testName,
                    PlaceClassName = testName
                };
                session.Save(placeClass);

                var teType = new WmsTEType
                {
                    TETypeCode = testName,
                    TETypeName = testName,
                    TETypeWidth = 10000,
                    TETypeHeight = 10000,
                    TETypeLength = 10000,
                    TETypeMaxWeight = 100000
                };
                session.Save(teType);

                session.Save(new SysGlobalParamValue
                {
                    GParamVal2Entity = "TETYPE",
                    GlobalParam =
                        session.Query<SysGlobalParam>().Single(i => i.GlobalParamCode == "TETypeSequence2TENumber"),
                    GParamValKey = teType.TETypeCode,
                    GParamValValue = "SQ_TE"
                });

                session.Save(new WmsTEType2Mandant
                {
                    TEType = teType,
                    Partner = tstMandant
                });

                session.Save(new WmsTEType2PlaceClass
                {
                    TEType = teType,
                    PlaceClass = placeClass
                });

                var truckType = new WmsTruckType
                {
                    TruckTypeCode = testName,
                    TruckTypeName = testName,
                    TruckTypeWeightMax = 100000,
                    TruckTypePickCount = 100
                };
                session.Save(truckType);

                session.Save(new WmsTeType2TruckType
                {
                    TruckType = truckType,
                    TEType = teType,
                    TeType2TruckTypeCount = 100
                });

                var receiveArea = new WmsReceiveArea
                {
                    ReceiveAreaCode = testName,
                    ReceiveAreaName = testName
                };
                session.Save(receiveArea);

                var placeStart = new WmsPlace
                {
                    PlaceCode = testName,
                    PlaceName = testName,
                    Segment = segment,
                    PlaceS = 1,
                    PlaceX = 1,
                    PlaceY = 1,
                    PlaceZ = 1,
                    PlaceType = placeType,
                    PlaceClass = placeClass,
                    PlaceCapacity = 9,
                    PlaceCapacityMax = 10,
                    PlaceWeight = 20000,
                    PlaceHeight = 20000,
                    PlaceLength = 20000,
                    PlaceWidth = 20000,
                    Status = session.Query<WmsPlaceStatus>().Single(i => i.StatusCode == "PLC_FREE"),
                };
                session.Save(placeStart);

                var art = new WmsArt
                {
                    Partner = tstMandant,
                    ArtName = testName,
                    ArtCode = testName,
                    ArtInputDateMethod =
                        session.Query<SYSENUM_ART_FIFO>().Single(i => i.EnumKey == "FIFO" && i.EnumValue == "YEAR"),
                    ArtType = "PRODUCT",
                    ArtABCD = 'A'
                };
                session.Save(art);

                var measureType = new WmsMeasureType
                {
                    MeasureTypeCode = testName
                };
                session.Save(measureType);

                var measure = new WmsMeasure
                {
                    MeasureCode = testName,
                    MeasureType = measureType,
                    MeasureFactor = 1
                };
                session.Save(measure);

                var sku = new WmsSKU
                {
                    SKUName = testName,
                    Measure = measure,
                    SKUCount = 1,
                    Art = art,
                    SKUPrimary = true,
                    SKUClient = true,
                    SKUDefault = true,
                    SKUIndivisible = true,
                    SKUWeight = 10,
                    SKUHeight = 10,
                    SKULength = 10,
                    SKUWidth = 10,
                    SKUVolume = 10
                };
                session.Save(sku);

                session.Save(new WmsSKU2TTE
                {
                    SKU = sku,
                    TEType = teType,
                    SKU2TTEDefault = true,
                    SKU2TTEQuantity = 1000,
                    SKU2TTEQuantityMax = 1000,
                    SKU2TTEMaxWeight = 10000
                });

                var te = new WmsTE
                {
                    TECode = testName,
                    TEType = session.Query<WmsTEType>().Single(i => i.TETypeCode == testName),
                    TECurrentPlace = placeStart,
                    TECreationPlace = placeStart.PlaceCode,
                    TELength = 1000,
                    TEHeight = 1000,
                    TEWeight = 1000,
                    TEWidth = 1000,
                    Status = session.Query<WmsTEStatus>().Single(i => i.StatusCode == "TE_FREE"),
                    TEPackStatus = "TE_PKG_NONE",
                    TEMaxWeight = 1000
                };
                session.Save(te);

                var owbPos = new WmsOWBPos
                {
                    SKU = sku,
                    OWBPosCount = 1,
                    OWBPosCount2SKU = 1,
                    OWBPosOwner = tstMandant,
                    OWB = owb,
                    QLF = session.Query<WmsQLF>().Single(i => i.QLFCode == "QLFNORMAL"),
                    Status = session.Query<WmsOWBPosStatus>().Single(i => i.StatusCode == "OWBPOS_CREATED")
                };
                session.Save(owbPos);

                session.Save(new WmsProduct
                {
                    TE = te,
                    SKU = session.Query<WmsSKU>().Single(i => i.SKUName == testName),
                    ProductCountSKU = 1,
                    ProductCount = 1,
                    ProductTTEQuantity = 1,
                    QLF = session.Query<WmsQLF>().Single(i => i.QLFCode == "QLFNORMAL"),
                    ProductInputDate = DateTime.Now,
                    ProductInputDateMethod = art.ArtInputDateMethod,
                    Art = art,
                    Partner = tstMandant,
                    ProductOwner = tstMandant,
                    Status = session.Query<WmsProductStatus>().Single(i => i.StatusCode == "PRODUCT_FREE"),
                    ProductTone = testName,
                    ProductLot = testName,
                    OWBPos = owbPos
                });

                #endregion data

                session.Flush();

                // запускаем
                var api = new WmsAPI(mockSessionFactory.Object, _container.Resolve<IWmsXmlConverter>(), _container.Resolve<IWorkflowLoader>());
                Action action = () => { api.ChangeOwnerByOwb(owb.OWBID, "OP_OPERATOR_OWBPROCESSING", "TEST", null); };

                action.ShouldThrow<Exception>().Which.Message.Should().Contain("смена владельца не требуется");

                transaction.Rollback();
            }
        }

        /// <summary>
        ///     Создаём накладную в статусе OWB_ACTIVATED и товар.
        /// </summary>
        [Test]
        public void Tes3()
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

                const string testName = "TestName";

                var tstMandant = session.Query<WmsMandant>().Single(i => i.PartnerCode == "TST");
                var tstOwner = new WmsMandant
                {
                    PartnerCode = "TSTOwner12"
                };
                session.Save(tstOwner);

                var owb = new WmsOWB
                {
                    Partner = tstMandant,
                    OWBName = "Owb for testing change owner",
                    OWBProductNeed = "NOACTIVATE",
                    OWBType = "OWBTYPENORMAL",
                    OWBOwner = tstMandant,
                    Status = session.Query<WmsOWBStatus>().Single(i => i.StatusCode == "OWB_ACTIVATED")
                };
                session.Save(owb);

                var clientType = new SysClientType
                {
                    ClientTypeCode = "WEBAPITEST",
                    ClientTypeName = "WEBAPITEST"
                };
                session.Save(clientType);

                #region data

                var warehouse = new WmsWarehouse
                {
                    WarehouseCode = testName,
                    WarehouseName = testName
                };
                session.Save(warehouse);


                var areaType = new WmsAreaType
                {
                    AreaTypeCode = testName,
                    AreaTypeName = testName
                };
                session.Save(areaType);

                session.Save(new SysGlobalParamValue
                {
                    GParamVal2Entity = "AREATYPE",
                    GlobalParam = session.Query<SysGlobalParam>().Single(i => i.GlobalParamCode == "AreaDestination"),
                    GParamValKey = areaType.AreaTypeCode,
                    GParamValValue = "OUT"
                });

                var area = new WmsArea
                {
                    AreaCode = testName,
                    AreaName = testName,
                    Warehouse = warehouse,
                    AreaType = areaType
                };
                session.Save(area);

                var segmentType = new WmsSegmentType
                {
                    SegmentTypeCode = testName,
                    SegmentTypeName = testName
                };
                session.Save(segmentType);

                var segment = new WmsSegment
                {
                    SegmentCode = testName,
                    SegmentName = testName,
                    SegmentNumber = testName,
                    Area = area,
                    SegmentType = segmentType
                };
                session.Save(segment);

                var placeType = new WmsPlaceType
                {
                    PlaceTypeCode = testName,
                    PlaceTypeName = testName,
                    PlaceTypeMaxWeight = 200000,
                    PlaceTypeHeight = 200000,
                    PlaceTypeLength = 200000,
                    PlaceTypeWidth = 200000,
                    PlaceTypeCapacity = 200
                };
                session.Save(placeType);

                var placeClass = new WmsPlaceClass
                {
                    PlaceClassCode = testName,
                    PlaceClassName = testName
                };
                session.Save(placeClass);

                var teType = new WmsTEType
                {
                    TETypeCode = testName,
                    TETypeName = testName,
                    TETypeWidth = 10000,
                    TETypeHeight = 10000,
                    TETypeLength = 10000,
                    TETypeMaxWeight = 100000
                };
                session.Save(teType);

                session.Save(new SysGlobalParamValue
                {
                    GParamVal2Entity = "TETYPE",
                    GlobalParam =
                        session.Query<SysGlobalParam>().Single(i => i.GlobalParamCode == "TETypeSequence2TENumber"),
                    GParamValKey = teType.TETypeCode,
                    GParamValValue = "SQ_TE"
                });

                session.Save(new WmsTEType2Mandant
                {
                    TEType = teType,
                    Partner = tstMandant
                });

                session.Save(new WmsTEType2PlaceClass
                {
                    TEType = teType,
                    PlaceClass = placeClass
                });

                var truckType = new WmsTruckType
                {
                    TruckTypeCode = testName,
                    TruckTypeName = testName,
                    TruckTypeWeightMax = 100000,
                    TruckTypePickCount = 100
                };
                session.Save(truckType);

                session.Save(new WmsTeType2TruckType
                {
                    TruckType = truckType,
                    TEType = teType,
                    TeType2TruckTypeCount = 100
                });

                var receiveArea = new WmsReceiveArea
                {
                    ReceiveAreaCode = testName,
                    ReceiveAreaName = testName
                };
                session.Save(receiveArea);

                var placeStart = new WmsPlace
                {
                    PlaceCode = testName,
                    PlaceName = testName,
                    Segment = segment,
                    PlaceS = 1,
                    PlaceX = 1,
                    PlaceY = 1,
                    PlaceZ = 1,
                    PlaceType = placeType,
                    PlaceClass = placeClass,
                    PlaceCapacity = 9,
                    PlaceCapacityMax = 10,
                    PlaceWeight = 20000,
                    PlaceHeight = 20000,
                    PlaceLength = 20000,
                    PlaceWidth = 20000,
                    Status = session.Query<WmsPlaceStatus>().Single(i => i.StatusCode == "PLC_FREE"),
                };
                session.Save(placeStart);

                var art = new WmsArt
                {
                    Partner = tstMandant,
                    ArtName = testName,
                    ArtCode = testName,
                    ArtInputDateMethod =
                        session.Query<SYSENUM_ART_FIFO>().Single(i => i.EnumKey == "FIFO" && i.EnumValue == "YEAR"),
                    ArtType = "PRODUCT",
                    ArtABCD = 'A'
                };
                session.Save(art);

                var measureType = new WmsMeasureType
                {
                    MeasureTypeCode = testName
                };
                session.Save(measureType);

                var measure = new WmsMeasure
                {
                    MeasureCode = testName,
                    MeasureType = measureType,
                    MeasureFactor = 1
                };
                session.Save(measure);

                var sku = new WmsSKU
                {
                    SKUName = testName,
                    Measure = measure,
                    SKUCount = 1,
                    Art = art,
                    SKUPrimary = true,
                    SKUClient = true,
                    SKUDefault = true,
                    SKUIndivisible = true,
                    SKUWeight = 10,
                    SKUHeight = 10,
                    SKULength = 10,
                    SKUWidth = 10,
                    SKUVolume = 10
                };
                session.Save(sku);

                session.Save(new WmsSKU2TTE
                {
                    SKU = sku,
                    TEType = teType,
                    SKU2TTEDefault = true,
                    SKU2TTEQuantity = 1000,
                    SKU2TTEQuantityMax = 1000,
                    SKU2TTEMaxWeight = 10000
                });

                var te = new WmsTE
                {
                    TECode = testName,
                    TEType = session.Query<WmsTEType>().Single(i => i.TETypeCode == testName),
                    TECurrentPlace = placeStart,
                    TECreationPlace = placeStart.PlaceCode,
                    TELength = 1000,
                    TEHeight = 1000,
                    TEWeight = 1000,
                    TEWidth = 1000,
                    Status = session.Query<WmsTEStatus>().Single(i => i.StatusCode == "TE_FREE"),
                    TEPackStatus = "TE_PKG_NONE",
                    TEMaxWeight = 1000
                };
                session.Save(te);

                var owbPos = new WmsOWBPos
                {
                    SKU = sku,
                    OWBPosCount = 1,
                    OWBPosCount2SKU = 1,
                    OWBPosOwner = tstMandant,
                    OWB = owb,
                    QLF = session.Query<WmsQLF>().Single(i => i.QLFCode == "QLFNORMAL"),
                    Status = session.Query<WmsOWBPosStatus>().Single(i => i.StatusCode == "OWBPOS_CREATED")
                };
                session.Save(owbPos);

                session.Save(new WmsProduct
                {
                    TE = te,
                    SKU = session.Query<WmsSKU>().Single(i => i.SKUName == testName),
                    ProductCountSKU = 1,
                    ProductCount = 1,
                    ProductTTEQuantity = 1,
                    QLF = session.Query<WmsQLF>().Single(i => i.QLFCode == "QLFNORMAL"),
                    ProductInputDate = DateTime.Now,
                    ProductInputDateMethod = art.ArtInputDateMethod,
                    Art = art,
                    Partner = tstMandant,
                    ProductOwner = tstOwner,
                    Status = session.Query<WmsProductStatus>().Single(i => i.StatusCode == "PRODUCT_FREE"),
                    ProductTone = testName,
                    ProductLot = testName,
                    OWBPos = owbPos
                });

                #endregion data

                session.Flush();

                // запускаем
                var api = new WmsAPI(mockSessionFactory.Object, _container.Resolve<IWmsXmlConverter>(), _container.Resolve<IWorkflowLoader>());
                api.ChangeOwnerByOwb(owb.OWBID, "OP_OPERATOR_OWBPROCESSING", clientType.ClientTypeCode, null);

                //Проверяем смену владельуа у товара
                var products = session.Query<WmsProduct>().Where(p => p.OWBPos == owbPos).ToArray();
                products.Length.Should().BeGreaterOrEqualTo(1);

                foreach (var product in products)
                {
                    product.ProductOwner.ShouldBeEquivalentTo(tstMandant);

                    //Проверяем наличие события
                    var events =
                        session.Query<wmsEventDetailPRD>().Where(p => p.PRODUCTID_R == product.ProductID).ToArray();
                    events.Should().HaveCount(1);
                }

                transaction.Rollback();
            }
        }
    }
}
