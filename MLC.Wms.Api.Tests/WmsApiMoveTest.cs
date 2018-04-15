using System;
using System.Data;
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
using NUnit.Framework.Internal;
using Oracle.ManagedDataAccess.Client;

namespace MLC.Wms.Api.Tests
{
    [TestFixture]
    public class WmsApiMoveTest : BaseDbWithWfTestFixture
    {
        private string tstMandantCode = "TST";

        private const string TestName = "MoveTest";
        private const string StartCode = TestName + "_Start";
        private const string FinishCode = TestName + "_Finish";
        private const string OtherCode = TestName + "_Other";

        #region .  Data  .

        /// <summary>
        /// Создаем топологию для тестов
        /// </summary>
        /// <param name="session"></param>
        private void GeneralData(ISession session)
        {
            var tstMandant = session.Query<WmsMandant>().Single(i => i.PartnerCode == tstMandantCode);

            var warehouse = new WmsWarehouse
            {
                WarehouseCode = TestName,
                WarehouseName = TestName
            };
            session.Save(warehouse);


            var areaType = new WmsAreaType
            {
                AreaTypeCode = TestName,
                AreaTypeName = TestName
            };
            session.Save(areaType);

            session.Save(new SysGlobalParamValue
            {
                GParamVal2Entity = "AREATYPE",
                GlobalParam = session.Query<SysGlobalParam>().Single(i => i.GlobalParamCode == "AreaDestination"),
                GParamValKey = areaType.AreaTypeCode,
                GParamValValue = "STORAGE"
            });

            var area = new WmsArea
            {
                AreaCode = TestName,
                AreaName = TestName,
                Warehouse = warehouse,
                AreaType = areaType
            };
            session.Save(area);

            var segmentType = new WmsSegmentType
            {
                SegmentTypeCode = TestName,
                SegmentTypeName = TestName
            };
            session.Save(segmentType);

            var segment = new WmsSegment
            {
                SegmentCode = TestName,
                SegmentName = TestName,
                SegmentNumber = TestName,
                Area = area,
                SegmentType = segmentType
            };
            session.Save(segment);

            var placeType = new WmsPlaceType
            {
                PlaceTypeCode = TestName,
                PlaceTypeName = TestName,
                PlaceTypeMaxWeight = 200000,
                PlaceTypeHeight = 200000,
                PlaceTypeLength = 200000,
                PlaceTypeWidth = 200000,
                PlaceTypeCapacity = 200
            };
            session.Save(placeType);

            var placeClass = new WmsPlaceClass
            {
                PlaceClassCode = TestName,
                PlaceClassName = TestName
            };
            session.Save(placeClass);

            var teType = new WmsTEType
            {
                TETypeCode = TestName,
                TETypeName = TestName,
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
                TruckTypeCode = TestName,
                TruckTypeName = TestName,
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
                ReceiveAreaCode = TestName,
                ReceiveAreaName = TestName
            };
            session.Save(receiveArea);

            var placeStart = new WmsPlace
            {
                PlaceCode = StartCode,
                PlaceName = StartCode,
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

            session.Save(new WmsPlace
            {
                PlaceCode = FinishCode,
                PlaceName = FinishCode,
                Segment = segment,
                PlaceS = 1,
                PlaceX = 2,
                PlaceY = 1,
                PlaceZ = 1,
                PlaceType = placeType,
                PlaceClass = placeClass,
                PlaceCapacity = 10,
                PlaceCapacityMax = 10,
                PlaceWeight = 20000,
                PlaceHeight = 20000,
                PlaceLength = 20000,
                PlaceWidth = 20000,
                Status = placeStart.Status,
                ReceiveArea = receiveArea
            });

            var art = new WmsArt
            {
                Partner = tstMandant,
                ArtName = TestName,
                ArtCode = TestName,
                ArtInputDateMethod =
                    session.Query<SYSENUM_ART_FIFO>().Single(i => i.EnumKey == "FIFO" && i.EnumValue == "YEAR"),
                ArtType = "PRODUCT",
                ArtABCD = 'A'
            };
            session.Save(art);

            var measureType = new WmsMeasureType
            {
                MeasureTypeCode = TestName
            };
            session.Save(measureType);


            var measure = new WmsMeasure
            {
                MeasureCode = TestName,
                MeasureType = measureType,
                MeasureFactor = 1
            };
            session.Save(measure);

            var sku = new WmsSKU
            {
                SKUName = TestName,
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
                TECode = StartCode,
                TEType = session.Query<WmsTEType>().Single(i => i.TETypeCode == TestName),
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

            session.Save(new WmsProduct
            {
                TE = te,
                SKU = session.Query<WmsSKU>().Single(i => i.SKUName == TestName),
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
                ProductTone = TestName,
                ProductLot = TestName
            });
        }

        /// <summary>
        /// Создаем PM и настройку
        /// </summary>
        /// <param name="session"></param>
        private void PMData(ISession session, string operationCode, string code = TestName, bool isArt = true, string entitycode = "PRODUCT", string attrubute = "PRODUCTTONE", string pmMethodCode = "MUST_EQ")
        {
            var pm = new WmsPM
            {
                PMCode = code,
                PMName = code
            };
            session.Save(pm);

            var oper = session.Query<BillOperation>().Single(i => i.OperationCode == operationCode);

            var pm2Operation = new WmsPM2Operation
            {
                PM2OperationCode = code,
                PM = pm,
                Operation = oper
            };
            session.Save(pm2Operation);

            if (isArt)
                session.Save(new WmsPM2Art
                {
                    Art = session.Query<WmsArt>().Single(i => i.ArtCode == TestName),
                    PM = pm
                });

            session.Save(new WmsPMConfig
            {
                PM2Operation = pm2Operation,
                ObjectEntityCode_r = entitycode,
                ObjectName_r = attrubute,
                PMMethod = session.Query<WmsPMMethod>().Single(i => i.PMMethodCode == pmMethodCode),
                PMConfigByProduct = false
            });
        }

        /// <summary>
        /// Добавляем MM и настройку
        /// </summary>
        /// <param name="session"></param>
        /// <param name="strategy">Код TE</param>
        /// <param name="addCpv">Код TE</param>
        /// <param name="pmCurrent">Код TE</param>
        private void MMData(ISession session, string strategy, bool addCpv = false, string pmCurrent = null)
        {
            var mm = new WmsMM
            {
                MMCode = TestName,
                MMName = TestName
            };
            session.Save(mm);

            session.Save(new WmsMMSelect
            {
                MM = mm,
                Priority = 1,
                PartnerID_r = session.Query<WmsMandant>().Single(i => i.PartnerCode == tstMandantCode).PartnerID,
                MMSelectTECompleteMin = 1,
                MMSelectTECompleteMax = 100
            });

            var mmUse = new WmsMMUse
            {
                MM = mm,
                MMUsePriority = 1,
                MMUseStrategy = strategy,
                MMUseStrategyValue = session.Query<WmsReceiveArea>().Single(i => i.ReceiveAreaCode == TestName).ReceiveAreaCode
            };
            session.Save(mmUse);

            if (!addCpv && string.IsNullOrEmpty(pmCurrent))
                return;

            var parentCPV = new WmsMMUseCPV()
            {
                MMUSE = mmUse,
                EntityName = "MMUSE",
                CustomParam = session.Query<WmsCustomParam>().Single(i => i.CustomParamCode == "MMUsePM")
            };

            session.Save(parentCPV);

            if (addCpv)
                session.Save(new WmsMMUseCPV()
                {
                    MMUSE = mmUse,
                    EntityName = "MMUSE",
                    CustomParam = session.Query<WmsCustomParam>().Single(i => i.CustomParamCode == "MMUsePMUse"),
                    CPVValue = "1",
                    Parent = parentCPV
                });

            if (!string.IsNullOrEmpty(pmCurrent))
                session.Save(new WmsMMUseCPV()
                {
                    MMUSE = mmUse,
                    EntityName = "MMUSE",
                    CustomParam = session.Query<WmsCustomParam>().Single(i => i.CustomParamCode == "MMUsePMCurrent"),
                    CPVValue = pmCurrent,
                    Parent = parentCPV
                });
        }

        /// <summary>
        /// Создаем TE и товар на финишном месте
        /// </summary>
        /// <param name="session"></param>
        /// <param name="teCode">Код TE</param>
        private void ProductData(ISession session, string placeCode = FinishCode, bool createProduct = true)
        {
            var place = session.Query<WmsPlace>().Single(i => i.PlaceCode == placeCode);
            var art = session.Query<WmsArt>().Single(i => i.ArtCode == TestName);
            var tstMandant = session.Query<WmsMandant>().Single(i => i.PartnerCode == tstMandantCode);

            var te = new WmsTE
            {
                TECode = placeCode,
                TEType = session.Query<WmsTEType>().Single(i => i.TETypeCode == TestName),
                TECurrentPlace = place,
                TECreationPlace = place.PlaceCode,
                TELength = 1100,
                TEHeight = 1100,
                TEWeight = 1100,
                TEWidth = 1100,
                Status = session.Query<WmsTEStatus>().Single(i => i.StatusCode == "TE_FREE"),
                TEPackStatus = "TE_PKG_NONE",
                TEMaxWeight = 11000
            };
            session.Save(te);

            if (createProduct)
            {
                session.Save(new WmsProduct
                {
                    TE = te,
                    SKU = session.Query<WmsSKU>().Single(i => i.SKUName == TestName),
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
                    ProductTone = TestName,
                    ProductLot = TestName
                });
            }

            place.PlaceCapacity = place.PlaceCapacity - 1;
            session.Update(place);
        }

        /// <summary>
        /// Добавляем место
        /// </summary>
        /// <param name="session"></param>
        /// <param name="placeCode">Код TE</param>
        private void PlaceData(ISession session, string placeCode)
        {
            session.Save(new WmsPlace
            {
                PlaceCode = placeCode,
                PlaceName = placeCode,
                Segment = session.Query<WmsSegment>().Single(i => i.SegmentCode == TestName),
                PlaceS = 1,
                PlaceX = 2,
                PlaceY = 1,
                PlaceZ = 1,
                PlaceType = session.Query<WmsPlaceType>().Single(i => i.PlaceTypeCode == TestName),
                PlaceClass = session.Query<WmsPlaceClass>().Single(i => i.PlaceClassCode == TestName),
                PlaceCapacity = 10,
                PlaceCapacityMax = 10,
                PlaceWeight = 20000,
                PlaceHeight = 20000,
                PlaceLength = 20000,
                PlaceWidth = 20000,
                Status = session.Query<WmsPlaceStatus>().Single(i => i.StatusCode == "PLC_FREE"),
                ReceiveArea = session.Query<WmsReceiveArea>().Single(i => i.ReceiveAreaCode == TestName)
            });
        }
        
        /// <summary>
        /// Добавляем артикул и товар на сущест. место
        /// </summary>
        /// <param name="session"></param>
        /// /// <param name="placeCode"></param>
        /// /// <param name="code"></param>
        private void OtherProductData(ISession session, string placeCode, string code)
        {
            var mandant = session.Query<WmsMandant>().Single(i => i.PartnerCode == tstMandantCode);

            var art = new WmsArt
            {
                Partner = mandant,
                ArtName = code,
                ArtCode = code,
                ArtInputDateMethod = session.Query<SYSENUM_ART_FIFO>().Single(i => i.EnumKey == "FIFO" && i.EnumValue == "YEAR"),
                ArtType = "PRODUCT",
                ArtABCD = 'A',
            };
            session.Save(art);

            var sku = new WmsSKU
            {
                SKUName = code,
                Measure = session.Query<WmsMeasure>().Single(i => i.MeasureCode == TestName),
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
                TEType = session.Query<WmsTEType>().Single(i => i.TETypeCode == TestName),
                SKU2TTEDefault = true,
                SKU2TTEQuantity = 1000,
                SKU2TTEQuantityMax = 1000,
                SKU2TTEMaxWeight = 10000
            });

            session.Save(new WmsProduct
            {
                TE = session.Query<WmsTE>().Single(i => i.TECode == placeCode),
                SKU = sku,
                ProductCountSKU = 1,
                ProductCount = 1,
                ProductTTEQuantity = 1,
                QLF = session.Query<WmsQLF>().Single(i => i.QLFCode == "QLFNORMAL"),
                ProductInputDate = DateTime.Now,
                ProductInputDateMethod = art.ArtInputDateMethod,
                Art = art,
                Partner = mandant,
                ProductOwner = mandant,
                Status = session.Query<WmsProductStatus>().Single(i => i.StatusCode == "PRODUCT_FREE"),
                ProductTone = code,
            });

            var place = session.Query<WmsPlace>().Single(i => i.PlaceCode == placeCode);
            place.PlaceCapacity = place.PlaceCapacity - 1;
            session.Update(place);
        }

        #endregion

        /// <summary>
        /// Перемещение на местo, которого нет
        /// Стратегия "PLACE_FIX"
        /// Ожидаем ошибку
        /// </summary>
        [Test]
        public void TestNotExistPlace()
        {
            WithTemporarySession((session, transaction, container) =>
            {
                GeneralData(session);
                session.Flush();

                var api = container.Resolve<WmsAPI>();
                Action action = () => { api.MoveManyTE2Place(StartCode, "NotPlaceCode", Strateges.PLACE_FIX, null, null, 0); };

                var expectedMessage = "Место \"NotPlaceCode\" занято";
                action.ShouldThrowExactly<OracleException>().Which.Message.Should().Contain(expectedMessage);
            });
        }

        /// <summary>
        /// Перемещение на местo "Finish"  без дозагруза
        /// Стратегия "PLACE_FIX", на конечном месте нет TE
        /// Ожидаем ЗНТ с конечным местом - Finish
        /// </summary>
        [Test]
        public void Test11()
        {
            WithTemporarySession((session, transaction, container) =>
            {
                GeneralData(session);
                session.Flush();

                var api = container.Resolve<WmsAPI>();
                Action action = () =>
                {
                    var res = api.MoveManyTE2Place(StartCode, FinishCode, "PLACE_FIX", null, null, 0);
                    var tTask = session.Query<WmsTransportTask>().Single(i => i.TTaskID == res);
                    tTask.Should().NotBeNull();
                    tTask.TTaskFinishPlace.Should().NotBeNull();
                    tTask.TTaskFinishPlace.PlaceCode.ShouldBeEquivalentTo(FinishCode);
                };
                action.ShouldNotThrow();
            });

        }

        /// <summary>
        /// Перемещение на местo без дозагруза
        /// Стратегия "PLACE_FIX", на финишном месте есть TE c товаром, менеджер настроен, атрибуты не совпадают 
        /// Ожидаем ошибку
        /// </summary>
        [Test]
       // [Ignore("Логическая ошибка. Восстановить работу.Получаем ошибку, отличную от тестовой")]
        public void Test12()
        {
            WithTemporarySession((session, transaction, container) =>
            {
                GeneralData(session);
                PMData(session, Operations.OP_MOVE_TE);
                ProductData(session);
                var product = session.Query<WmsProduct>().Single(i => i.TE.TECode == FinishCode);
                product.ProductTone = product.ProductTone + "Exception";
                session.Update(product);
                session.Flush();

                var api = container.Resolve<WmsAPI>();
                Action action = () => { api.MoveManyTE2Place(StartCode, FinishCode, Strateges.PLACE_FIX, null, null, 0); };

                var expectedMessage = $"Невозможно переместить ТЕ \"{StartCode}\" на место \"{FinishCode}\": не удовлетворяет настройкам менеджера товара";
                action.ShouldThrowExactly<OracleException>().Which.Message.Should().Contain(expectedMessage);
            });
        }

        /// <summary>
        /// Перемещение на местo без дозагруза
        /// Стратегия "PLACE_FIX", На финишном месте есть TE c товаром, менеджер настроен, атрибуты совпадают 
        /// Ожидаем, что ЗНТ будет
        /// </summary>
        [Test]
        public void Test13()
        {
            WithTemporarySession((session, transaction, container) =>
            {
                GeneralData(session);
                PMData(session, Operations.OP_MOVE_TE);
                ProductData(session);
                session.Flush();

                var api = container.Resolve<WmsAPI>();
                Action action = () =>
                {
                    var res = api.MoveManyTE2Place(StartCode, FinishCode, Strateges.PLACE_FIX, null, null, 0);
                    var tTask = session.Query<WmsTransportTask>().Single(i => i.TTaskID == res);
                    tTask.Should().NotBeNull();
                    tTask.TTaskFinishPlace.Should().NotBeNull();
                    tTask.TTaskFinishPlace.PlaceCode.ShouldBeEquivalentTo(FinishCode);
                };

                action.ShouldNotThrow();
            });
        }

        /// <summary>
        /// Перемещение на местo без дозагруза
        /// Стратегия "PLACE_FIX", на финишном месте есть TE c товаром, менеджер не настроен
        /// Ожидаем ЗНТ
        /// </summary>
        [Test]
        public void Test14()
        {
            WithTemporarySession((session, transaction, container) =>
            {
                GeneralData(session);
                PMData(session, Operations.OP_MOVE_TE);
                session.Flush();

                var api = container.Resolve<WmsAPI>();

                Action action = () =>
                {
                    var res = api.MoveManyTE2Place(StartCode, FinishCode, Strateges.PLACE_FIX, null, null, 0);
                    var tTask = session.Query<WmsTransportTask>().Single(i => i.TTaskID == res);
                    tTask.Should().NotBeNull();
                    tTask.TTaskFinishPlace.Should().NotBeNull();
                    tTask.TTaskFinishPlace.PlaceCode.ShouldBeEquivalentTo(FinishCode);
                };

                action.ShouldNotThrow();
            });
        }
        
        /// <summary>
        /// Перемещение на местo c дозагрузом
        /// Стратегия "PLACE_FIX_LOAD", на конечном месте нет TE
        /// Ожидаем ошибку
        /// </summary>
        [Test]
        public void Test21()
        {
            WithTemporarySession((session, transaction, container) =>
            {
                GeneralData(session);
                session.Flush();

                var api = container.Resolve<WmsAPI>();
                Action action = () => { api.MoveManyTE2Place(StartCode, FinishCode, Strateges.PLACE_FIX_LOAD, null, null, 0); };

                var expectedMessage = $"Для ТЕ \"{StartCode}\" не найдена целевая/несущая ТЕ";
                action.ShouldThrowExactly<OracleException>().Which.Message.Should().Contain(expectedMessage);
            });
        }

        /// <summary>
        /// Перемещение на местo c дозагрузом
        /// Стратегия "PLACE_FIX_LOAD", на финишном месте есть TE c товаром, менеджер настроен, атрибуты не совпадают, операция OP_PRODUCT_PART_LOAD 
        /// Ожидаем ошибку
        /// </summary>
        [Test]
        public void Test22()
        {
            WithTemporarySession((session, transaction, container) =>
            {
                GeneralData(session);
                PMData(session, Operations.OP_PRODUCT_PART_LOAD);
                ProductData(session);
                var product = session.Query<WmsProduct>().Single(i => i.TE.TECode == FinishCode);
                product.ProductTone = product.ProductTone + "Exception";
                session.Update(product);
                session.Flush();

                var api = container.Resolve<WmsAPI>();
                Action action = () => { api.MoveManyTE2Place(StartCode, FinishCode, Strateges.PLACE_FIX_LOAD, FinishCode, null, 0); };

                var expectedMessage = $"Невозможно переместить ТЕ \"{StartCode}\" на место \"{FinishCode}\":  не найдена ТЕ для дозагруза, проверьте настройки PM";
                action.ShouldThrowExactly<OracleException>().Which.Message.Should().Contain(expectedMessage);
            });
        }

        /// <summary>
        /// Перемещение на местo c дозагрузом
        /// Стратегия "PLACE_FIX_LOAD", На финишном месте есть TE c товаром, менеджер настроен, атрибуты совпадают, операция OP_PRODUCT_PART_LOAD 
        /// Ожидаем, что ЗНТ будет
        /// </summary>
        [Test]
        public void Test23()
        {
            WithTemporarySession((session, transaction, container) =>
            {
                GeneralData(session);
                PMData(session, Operations.OP_PRODUCT_PART_LOAD);
                ProductData(session);
                session.Flush();

                var api = container.Resolve<WmsAPI>();
                Action action = () =>
                {
                    var res = api.MoveManyTE2Place(StartCode, FinishCode, Strateges.PLACE_FIX_LOAD, FinishCode, null, 0);
                    var tTask = session.Query<WmsTransportTask>().Single(i => i.TTaskID == res);
                    tTask.Should().NotBeNull();
                    tTask.TTaskFinishPlace.Should().NotBeNull();
                    tTask.TTaskFinishPlace.PlaceCode.ShouldBeEquivalentTo(FinishCode);
                    tTask.TTaskTargetTE.ShouldBeEquivalentTo(FinishCode);
                };

                action.ShouldNotThrow();
            });
        }

        /// <summary>
        /// Перемещение на местo дозагрузом
        /// Стратегия "PLACE_FIX_LOAD", на финишном месте есть TE c товаром, менеджер не настроен
        /// Ожидаем, что ЗНТ будет 
        /// </summary>
        [Test]
        public void Test24()
        {
            WithTemporarySession((session, transaction, container) =>
            {
                GeneralData(session);
                ProductData(session);
                session.Flush();

                var api = container.Resolve<WmsAPI>();
                Action action = () =>
                {
                    var res = api.MoveManyTE2Place(StartCode, FinishCode, Strateges.PLACE_FIX_LOAD, FinishCode, null, 0);
                    var tTask = session.Query<WmsTransportTask>().Single(i => i.TTaskID == res);
                    tTask.Should().NotBeNull();
                    tTask.TTaskFinishPlace.Should().NotBeNull();
                    tTask.TTaskFinishPlace.PlaceCode.ShouldBeEquivalentTo(FinishCode);
                    tTask.TTaskTargetTE.ShouldBeEquivalentTo(FinishCode);
                };

                action.ShouldNotThrow();
            });
        }

        /// <summary>
        /// Проверка стретегии "PLACE_FREE" 
        /// на финишном месте есть ТЕ и товар на нем, 
        /// На дополнительном месте есть TE и товар на нем 
        /// менеджер товара настроен
        /// менеджер перемещения настроен, CPV MMUsePMUse нет, CPV MMUsePMCurrent - нет
        /// Ожидаем два доступных места
        /// </summary>
        [Test]
        public void Test31()
        {
            WithTemporarySession((session, transaction, container) =>
            {
                GeneralData(session);
                ProductData(session);
                PMData(session, Operations.OP_MOVE_TE);
                MMData(session, Strateges.PLACE_FREE);
                PlaceData(session, OtherCode);
                ProductData(session, OtherCode);

                var product = session.Query<WmsProduct>().Single(i => i.TE.TECode == FinishCode);
                product.ProductTone = "some";
                session.Update(product);

                session.Flush();

                var api = container.Resolve<WmsAPI>();
                Action action = () =>
                {
                    var res = api.GetPlaceLstByStrategy(Strateges.PLACE_FREE, StartCode, 2);
                    res.Should().NotBeNull();
                    res.Count().ShouldBeEquivalentTo(2);
                    res.Should().Contain(OtherCode);
                    res.Should().Contain(FinishCode);
                };

                action.ShouldNotThrow();
            });
        }

        /// <summary>
        /// Проверка стретегии "PLACE_FREE" 
        /// на финишном месте есть ТЕ и товар на нем, 
        /// На дополнительном месте есть TE и товар на нем 
        /// менеджер товара не настроен
        /// менеджер перемещения настроен, CPV MMUsePMUse нет, CPV MMUsePMCurrent - нет
        /// Ожидаем два доступных места
        /// </summary>
        [Test]
        public void Test32()
        {
            WithTemporarySession((session, transaction, container) =>
            {
                GeneralData(session);
                ProductData(session);
                MMData(session, Strateges.PLACE_FREE, true);
                PlaceData(session, OtherCode);
                ProductData(session, OtherCode);

                var product = session.Query<WmsProduct>().Single(i => i.TE.TECode == FinishCode);
                product.ProductTone = "some";
                session.Update(product);

                session.Flush();

                var api = container.Resolve<WmsAPI>();
                Action action = () =>
                {
                    var res = api.GetPlaceLstByStrategy(Strateges.PLACE_FREE, StartCode, 2);
                    res.Should().NotBeNull();
                    res.Count().ShouldBeEquivalentTo(2);
                    res.Should().Contain(OtherCode);
                    res.Should().Contain(FinishCode);
                };

                action.ShouldNotThrow();
            });
        }

        /// <summary>
        /// Проверка стретегии "PLACE_FREE" 
        /// на финишном месте есть ТЕ и товар на нем, 
        /// На дополнительном месте есть TE и товар на нем 
        /// менеджер товара настроен
        /// менеджер перемещения настроен, CPV MMUsePMUse есть, CPV MMUsePMCurrent - нет
        /// Ожидаем одно место
        /// </summary>
        [Test]
        public void Test33()
        {
            WithTemporarySession((session, transaction, container) =>
            {
                GeneralData(session);
                ProductData(session);
                PMData(session, Operations.OP_MOVE_TE);
                MMData(session, Strateges.PLACE_FREE, true);
                PlaceData(session, OtherCode);
                ProductData(session, OtherCode);

                var product = session.Query<WmsProduct>().Single(i => i.TE.TECode == FinishCode);
                product.ProductTone = "some";
                session.Update(product);

                session.Flush();

                var api = container.Resolve<WmsAPI>();
                Action action = () =>
                {
                    var res = api.GetPlaceLstByStrategy(Strateges.PLACE_FREE, StartCode, 2);
                    res.Should().NotBeNull();
                    res.Count().ShouldBeEquivalentTo(1);
                    res.Should().Contain(OtherCode);
                };

                action.ShouldNotThrow();
            });
        }
        
        /// <summary>
        /// Проверка стретегии "PLACE_FREE" 
        /// на финишном месте есть ТЕ и товар на нем, 
        /// На дополнительном месте есть TE и товар на нем 
        /// менеджер товара не настроен
        /// менеджер перемещения настроен, CPV MMUsePMUse есть, CPV MMUsePMCurrent - нет
        /// Ожидаем два места
        /// </summary>
        [Test]
        public void Test34()
        {
            WithTemporarySession((session, transaction, container) =>
            {
                GeneralData(session);
                ProductData(session);
                MMData(session, Strateges.PLACE_FREE, true);
                PlaceData(session, OtherCode);
                ProductData(session, OtherCode);

                var product = session.Query<WmsProduct>().Single(i => i.TE.TECode == FinishCode);
                product.ProductTone = "some";
                session.Update(product);

                session.Flush();

                var api = container.Resolve<WmsAPI>();
                Action action = () =>
                {
                    var res = api.GetPlaceLstByStrategy(Strateges.PLACE_FREE, StartCode, 2);
                    res.Should().NotBeNull();
                    res.Count().ShouldBeEquivalentTo(2);
                    res.Should().Contain(OtherCode);
                    res.Should().Contain(FinishCode);
                };

                action.ShouldNotThrow();
            });
        }

        /// <summary>
        /// Проверка стретегии "PLACE_FREE" 
        /// на финишном месте есть ТЕ и товар на нем, 
        /// На дополнительном месте есть TE и товар на нем 
        /// менеджер товара настроен без учета ART
        /// менеджер перемещения настроен, CPV MMUsePMUse есть, CPV MMUsePMCurrent ( = PmCode)
        /// Ожидаем два места
        /// </summary>
        [Test]
        public void Test35()
        {
            WithTemporarySession((session, transaction, container) =>
            {
                GeneralData(session);
                ProductData(session);
                PMData(session, Operations.OP_MOVE_TE, TestName, false);
                MMData(session, Strateges.PLACE_FREE, true, TestName);
                PlaceData(session, OtherCode);
                ProductData(session, OtherCode);

                var product = session.Query<WmsProduct>().Single(i => i.TE.TECode == FinishCode);
                product.ProductTone = "some";
                session.Update(product);

                session.Flush();

                var api = container.Resolve<WmsAPI>();
                Action action = () =>
                {
                    var res = api.GetPlaceLstByStrategy(Strateges.PLACE_FREE, StartCode, 2);
                    res.Should().NotBeNull();
                    res.Count().ShouldBeEquivalentTo(1);
                    res.Should().Contain(OtherCode);
                };

                action.ShouldNotThrow();
            });
        }

        /// <summary>
        /// Проверка стретегии "PLACE_FREE" 
        /// на финишном месте есть ТЕ и товар на нем, 
        /// На дополнительном месте есть TE и товар на нем 
        /// менеджер товара настроен (2 шт)
        /// менеджер перемещения настроен, CPV MMUsePMUse есть, CPV MMUsePMCurrent есть ( = PmCode)
        /// Ожидаем одно место
        /// </summary>
        [Test]
        public void Test36()
        {
            WithTemporarySession((session, transaction, container) =>
            {
                GeneralData(session);
                ProductData(session);
                PMData(session, Operations.OP_MOVE_TE);
                PMData(session, Operations.OP_MOVE_TE, OtherCode, true);
                MMData(session, Strateges.PLACE_FREE, true, OtherCode);
                PlaceData(session, OtherCode);
                ProductData(session, OtherCode);

                session.Save(new WmsPMConfig
                {
                    PM2Operation = session.Query<WmsPM2Operation>().Single(i => i.PM2OperationCode == OtherCode),
                    ObjectEntityCode_r = "PRODUCT",
                    ObjectName_r = "PRODUCTLOT",
                    PMMethod = session.Query<WmsPMMethod>().Single(i => i.PMMethodCode == "MUST_EQ"),
                });

                var product = session.Query<WmsProduct>().Single(i => i.TE.TECode == FinishCode);
                product.ProductLot = "some";
                session.Update(product);

                session.Flush();

                var api = container.Resolve<WmsAPI>();
                Action action = () =>
                {
                    var res = api.GetPlaceLstByStrategy(Strateges.PLACE_FREE, StartCode, 2);
                    res.Should().NotBeNull();
                    res.Count().ShouldBeEquivalentTo(1);
                    res.Should().Contain(OtherCode);
                };

                action.ShouldNotThrow();
            });
        }

        /// <summary>
        /// Перемещение на местo c дозагрузом
        /// Стратегия "PPLACE_FREE_LOAD", На финишном месте есть ТЕ, но без товара, менеджер настроен на MUST_EQ_NULL, операция OP_PRODUCT_PART_LOAD 
        /// Ожидаем создание ЗНТ
        /// </summary>
        [Test]
        public void Test37()
        {
            const string strategy = "PLACE_FREE_LOAD";
            WithTemporarySession((session, transaction, container) =>
            {
                GeneralData(session);
                PMData(session: session, operationCode: Operations.OP_PRODUCT_PART_LOAD, attrubute: "VARTNAME", pmMethodCode: "MUST_EQ_NULL");
                ProductData(session: session, createProduct: false);
                session.Flush();
                
                var api = container.Resolve<WmsAPI>();
                Action action = () =>
                {
                    var res = api.MoveManyTE2Place(StartCode, FinishCode, strategy, null, null, 0);
                    var tTask = session.Query<WmsTransportTask>().Single(i => i.TTaskID == res);

                    tTask.Should().NotBeNull();
                    tTask.TTaskFinishPlace.Should().NotBeNull();
                    tTask.TTaskFinishPlace.PlaceCode.ShouldBeEquivalentTo(FinishCode);
                    tTask.TTaskTargetTE.ShouldBeEquivalentTo(FinishCode);
                    tTask.TTaskLoad.ShouldBeEquivalentTo(true);
                    tTask.TransportTaskStrategy.ShouldBeEquivalentTo(strategy);

                    var te1products = session.Query<WmsProduct>().Where(p => p.TE.TECode == StartCode).ToArray();
                    var arts1 = te1products.Select(p => p.Art.ArtName).Distinct().ToArray();

                    var te2products = session.Query<WmsProduct>().Where(p => p.TE.TECode == tTask.TTaskTargetTE).ToArray();
                    var arts2 = te2products.Select(p => p.Art.ArtName).Distinct().ToArray();

                    if (arts2.Length > 0)
                        arts2.Intersect(arts1).ToArray().Length.Should().BeGreaterThan(0, "На ТЕ для дозагруза нет товара с соответствующими артикулами");
                };

                action.ShouldNotThrow();
            });
        }

        /// <summary>
        /// Проверка настройки "По артикулу"
        /// Ожидаем - 2 мест
        /// </summary>
        [Test]
        public void Test41()
        {
            WithTemporarySession((session, transaction, container) =>
            {
                GeneralData(session);
                ProductData(session);
                PMData(session, Operations.OP_MOVE_TE);
                MMData(session, Strateges.PLACE_FREE, true, TestName);
                OtherProductData(session, FinishCode, OtherCode);

                PlaceData(session, OtherCode);
                ProductData(session, OtherCode);
                var art = session.Query<WmsArt>().Single(i => i.ArtCode == OtherCode);
                var mandant = session.Query<WmsMandant>().Single(i => i.PartnerCode == tstMandantCode);
                session.Save(new WmsProduct
                {
                    TE = session.Query<WmsTE>().Single(i => i.TECode == OtherCode),
                    SKU = session.Query<WmsSKU>().Single(i => i.SKUName == OtherCode),
                    ProductCountSKU = 1,
                    ProductCount = 1,
                    ProductTTEQuantity = 1,
                    QLF = session.Query<WmsQLF>().Single(i => i.QLFCode == "QLFNORMAL"),
                    ProductInputDate = DateTime.Now,
                    ProductInputDateMethod = art.ArtInputDateMethod,
                    Art = art,
                    Partner = mandant,
                    ProductOwner = mandant,
                    Status = session.Query<WmsProductStatus>().Single(i => i.StatusCode == "PRODUCT_FREE"),
                    ProductTone = OtherCode
                });

                session.Flush();

                var api = container.Resolve<WmsAPI>();
                Action action = () =>
                {
                    var res = api.GetPlaceLstByStrategy(Strateges.PLACE_FREE, StartCode, 2);
                    res.Should().NotBeNull();
                    res.Count().ShouldBeEquivalentTo(2);
                    res.Should().Contain(FinishCode);
                    res.Should().Contain(OtherCode);
                };

                action.ShouldNotThrow();
            });
        }

        /// <summary>
        /// Проверка настройки "По товару"
        /// Ожидаем - 1 мест
        /// </summary>
        [Test]
        public void Test42()
        {
            WithTemporarySession((session, transaction, container) =>
            {
                GeneralData(session);
                ProductData(session);
                PMData(session, Operations.OP_MOVE_TE);
                MMData(session, Strateges.PLACE_FREE, true, TestName);
                OtherProductData(session, FinishCode, OtherCode);

                var product = session.Query<WmsProduct>().Single(i => i.ProductTone == OtherCode);
                product.ProductTone = TestName;
                session.Update(product);

                PlaceData(session, OtherCode);
                ProductData(session, OtherCode);
                var art = session.Query<WmsArt>().Single(i => i.ArtCode == OtherCode);
                var mandant = session.Query<WmsMandant>().Single(i => i.PartnerCode == tstMandantCode);
                session.Save(new WmsProduct
                {
                    TE = session.Query<WmsTE>().Single(i => i.TECode == OtherCode),
                    SKU = session.Query<WmsSKU>().Single(i => i.SKUName == OtherCode),
                    ProductCountSKU = 1,
                    ProductCount = 1,
                    ProductTTEQuantity = 1,
                    QLF = session.Query<WmsQLF>().Single(i => i.QLFCode == "QLFNORMAL"),
                    ProductInputDate = DateTime.Now,
                    ProductInputDateMethod = art.ArtInputDateMethod,
                    Art = art,
                    Partner = mandant,
                    ProductOwner = mandant,
                    Status = session.Query<WmsProductStatus>().Single(i => i.StatusCode == "PRODUCT_FREE"),
                    ProductTone = OtherCode
                });

                var pm2oper = session.Query<WmsPM2Operation>().Single(i => i.PM2OperationCode == TestName);
                var pm2Config = session.Query<WmsPMConfig>().Single(i => i.ObjectEntityCode_r == "PRODUCT" && i.ObjectName_r == "PRODUCTTONE" && i.PM2Operation == pm2oper);
                pm2Config.PMConfigByProduct = true;
                session.Update(pm2Config);

                session.Flush();

                var api = container.Resolve<WmsAPI>();
                Action action = () =>
                {
                    var res = api.GetPlaceLstByStrategy(Strateges.PLACE_FREE, StartCode, 2);
                    res.Should().NotBeNull();
                    res.Count().ShouldBeEquivalentTo(1);
                    res.Should().Contain(FinishCode);
                };

                action.ShouldNotThrow();
            });
        }
    }
}
