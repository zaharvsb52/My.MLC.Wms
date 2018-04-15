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
using Oracle.ManagedDataAccess.Client;

namespace MLC.Wms.Api.Tests
{
    [TestFixture]
    public class WmsApiChangeOwbRouteTests
    {
        private IUnityContainer _container;
        private ISessionFactory _sessionFactory;

        [OneTimeSetUp]
        public void Setup()
        {
            UnityConfig.RegisterComponents(c =>
            {
                _container = c;
                _sessionFactory = c.Resolve<ISessionFactory>();

                _container.RegisterType<IWmsEnvironmentInfoProvider, SvcWmsEnvironmentInfoProvider>(new ContainerControlledLifetimeManager());
                _container.RegisterType<ILocalData, ThreadStaticLocalData>(new ContainerControlledLifetimeManager());
                WmsEnvironment.Init(_container.Resolve<IWmsEnvironmentInfoProvider>(), _container.Resolve<ILocalData>());
                _container.RegisterType<IWorkflowLoader, FileWorkflowLoader>(new ContainerControlledLifetimeManager(), new InjectionFactory(cc => new FileWorkflowLoader(Directory.GetCurrentDirectory(), false)));
            });
        }

        /// <summary>
        ///     Накладная:
        ///     * OWBOutDatePlan - есть
        ///     * OWBRoutePlan - нет
        ///     * Груза - нет
        ///     API
        ///     * ChangeOwbRoute(owb.OWBID, route.RouteID, null, false, true)
        ///     Ожидание
        ///     * Накладная привяжется к маршруту
        ///     * Накладная привяжется к грузу
        ///     * Создастся груз
        /// </summary>
        [Test]
        public void Test1()
        {
            using (var session = _sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var fakeSession = new SessionDecorator(session) { DoNotDispose = true };
                var mockSessionFactory = new Mock<ISessionFactory>();
                mockSessionFactory.Setup(i => i.OpenSession()).Returns(fakeSession);

                var tstMandant = session.Query<WmsMandant>().Single(i => i.PartnerCode == "TST");

                // создаем маршрут
                var route = new YRoute
                {
                    Partner = tstMandant,
                    RouteDate = DateTime.Today.AddDays(3), // через 3 дня
                    RouteNumber = "AutoTestRoute"
                };
                session.Save(route);

                // создаем накладную с плановой датой отгрузки
                var owb = new WmsOWB
                {
                    Partner = tstMandant,
                    OWBName = "Owb for testing routes",
                    OWBProductNeed = "NOACTIVATE",
                    OWBType = "OWBTYPENORMAL",
                    OWBOutDatePlan = route.RouteDate,
                    Status = session.Query<WmsOWBStatus>().Single(i => i.StatusCode == "OWB_NONE")
                };
                session.Save(owb);

                session.Flush();

                // груза еще не должно быть
                var cargo = session.Query<WmsCargoOWB>().FirstOrDefault(i => i.Route == route);
                cargo.Should().BeNull();

                // запускаем
                var api = new WmsAPI(mockSessionFactory.Object, _container.Resolve<IWmsXmlConverter>(), _container.Resolve<IWorkflowLoader>());
                var res = api.ChangeOwbRoute(owb.OWBID, route.RouteID, null, false, true);

                res.ShouldBeEquivalentTo(string.Format("Накладная с ID = {0} включена в маршрут {1} отгрузкой {2:dd.MM.yyyy HH:mm}", owb.OWBID, route.RouteID, route.RouteDate));

                // перечитываем накладную
                session.Refresh(owb);

                // должен проставиться маршрут
                owb.OWBRoutePlan.Should().Be(route.RouteID);

                // должен создаться груз
                cargo = session.Query<WmsCargoOWB>().FirstOrDefault(i => i.Route == route);
                cargo.Should().NotBeNull();

                // должен прописаться груз
                owb.WmsCargoOWB_List.Should().HaveCount(1);
                owb.WmsCargoOWB_List.Should().ContainSingle(i => i == cargo);

                transaction.Rollback();
            }
        }

        /// <summary>
        ///     Накладная:
        ///     * OWBOutDatePlan - есть
        ///     * OWBRoutePlan - нет
        ///     * Груз - есть (но не привзязан к накладной)
        ///     API
        ///     * ChangeOwbRoute(owb.OWBID, route.RouteID, null, false, true)
        ///     Ожидание
        ///     * Накладная привяжется к маршруту
        ///     * Накладная привяжется к грузу
        /// </summary>
        [Test]
        public void Test2()
        {
            using (var session = _sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var fakeSession = new SessionDecorator(session) { DoNotDispose = true };
                var mockSessionFactory = new Mock<ISessionFactory>();
                mockSessionFactory.Setup(i => i.OpenSession()).Returns(fakeSession);

                var tstMandant = session.Query<WmsMandant>().Single(i => i.PartnerCode == "TST");

                // создаем маршрут
                var route = new YRoute
                {
                    Partner = tstMandant,
                    RouteDate = DateTime.Today.AddDays(3), // через 3 дня
                    RouteNumber = "AutoTestRoute"
                };
                session.Save(route);

                var cargo = new WmsCargoOWB
                {
                    Route = route
                };
                session.Save(cargo);

                // создаем накладную с плановой датой отгрузки
                var owb = new WmsOWB
                {
                    Partner = tstMandant,
                    OWBName = "Owb for testing routes",
                    OWBProductNeed = "NOACTIVATE",
                    OWBType = "OWBTYPENORMAL",
                    OWBOutDatePlan = route.RouteDate,
                    Status = session.Query<WmsOWBStatus>().Single(i => i.StatusCode == "OWB_NONE")
                };
                session.Save(owb);

                session.Flush();

                // запускаем
                var api = new WmsAPI(mockSessionFactory.Object, _container.Resolve<IWmsXmlConverter>(), _container.Resolve<IWorkflowLoader>());
                var res = api.ChangeOwbRoute(owb.OWBID, route.RouteID, null, false, true);

                res.ShouldBeEquivalentTo(string.Format("Накладная с ID = {0} включена в маршрут {1} отгрузкой {2:dd.MM.yyyy HH:mm}", owb.OWBID, route.RouteID, route.RouteDate));

                // перечитываем накладную
                session.Refresh(owb);

                // должен проставиться маршрут
                owb.OWBRoutePlan.Should().Be(route.RouteID);

                // должен прописаться груз
                owb.WmsCargoOWB_List.Should().HaveCount(1);
                owb.WmsCargoOWB_List.Should().ContainSingle(i => i == cargo);

                transaction.Rollback();
            }
        }

        /// <summary>
        ///     Накладная:
        ///     * OWBOutDatePlan - есть
        ///     * OWBRoutePlan - нет
        ///     * Груз - есть (уже привязан к накладной)
        ///     API
        ///     * ChangeOwbRoute(owb.OWBID, route.RouteID, null, false, true)
        ///     Ожидание
        ///     * Накладная привяжется к маршруту
        ///     * Накладная привяжется к грузу
        /// </summary>
        [Test]
        public void Test3()
        {
            using (var session = _sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var fakeSession = new SessionDecorator(session) { DoNotDispose = true };
                var mockSessionFactory = new Mock<ISessionFactory>();
                mockSessionFactory.Setup(i => i.OpenSession()).Returns(fakeSession);

                var tstMandant = session.Query<WmsMandant>().Single(i => i.PartnerCode == "TST");

                // создаем маршрут
                var route = new YRoute
                {
                    Partner = tstMandant,
                    RouteDate = DateTime.Today.AddDays(3), // через 3 дня
                    RouteNumber = "AutoTestRoute"
                };
                session.Save(route);

                var cargo = new WmsCargoOWB
                {
                    Route = route
                };
                session.Save(cargo);

                // создаем накладную с плановой датой отгрузки
                var owb = new WmsOWB
                {
                    Partner = tstMandant,
                    OWBName = "Owb for testing routes",
                    OWBProductNeed = "NOACTIVATE",
                    OWBType = "OWBTYPENORMAL",
                    OWBOutDatePlan = route.RouteDate,
                    Status = session.Query<WmsOWBStatus>().Single(i => i.StatusCode == "OWB_NONE")
                };
                owb.WmsCargoOWB_List.Add(cargo);

                session.Save(owb);

                session.Flush();

                // запускаем
                var api = new WmsAPI(mockSessionFactory.Object, _container.Resolve<IWmsXmlConverter>(), _container.Resolve<IWorkflowLoader>());
                var res = api.ChangeOwbRoute(owb.OWBID, route.RouteID, null, false, true);

                res.ShouldBeEquivalentTo(string.Format("Накладная с ID = {0} включена в маршрут {1} отгрузкой {2:dd.MM.yyyy HH:mm}", owb.OWBID, route.RouteID, route.RouteDate));

                // перечитываем накладную
                session.Refresh(owb);

                // должен проставиться маршрут
                owb.OWBRoutePlan.Should().Be(route.RouteID);

                // должен прописаться груз
                owb.WmsCargoOWB_List.Should().HaveCount(1);
                owb.WmsCargoOWB_List.Should().ContainSingle(i => i == cargo);

                transaction.Rollback();
            }
        }

        /// <summary>
        ///     Накладная:
        ///     * OWBOutDatePlan - f
        ///     * OWBRoutePlan - нет
        ///     Маршрут уже существует
        ///     API
        ///     * ChangeOwbRoute(owb.OWBID, null, null, true, true)
        ///     Ожидание
        ///     * Выберется дата
        ///     * Выберется маршрут
        ///     * Накладная привяжется к маршруту
        ///     * Создастся груз
        ///     * Накладная привяжется к грузу
        /// </summary>
        [Test]
        //[Ignore("Разобраться. Получаем ошибку из БД.")]
        public void Test4()
        {
            using (var session = _sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var fakeSession = new SessionDecorator(session) { DoNotDispose = true };
                var mockSessionFactory = new Mock<ISessionFactory>();
                mockSessionFactory.Setup(i => i.OpenSession()).Returns(fakeSession);

                #region populate test data

                WmsOWB owb;
                DateTime expectedDate;
                YMgRoute mgrRoute;

                PopulateTestData(session, out owb, out expectedDate, out mgrRoute);

                #endregion

                // запускаем
                var api = new WmsAPI(mockSessionFactory.Object, _container.Resolve<IWmsXmlConverter>(), _container.Resolve<IWorkflowLoader>());
                var res = api.ChangeOwbRoute(owb.OWBID, null, null, true, true);

                // перечитываем накладную
                session.Refresh(owb);

                // проверяем маршрут
                owb.OWBRoutePlan.Should().HaveValue();
                var route = session.Get<YRoute>(owb.OWBRoutePlan.Value);
                route.Should().NotBeNull();
                route.RouteDate.ShouldBeEquivalentTo(expectedDate);
                route.RouteNumber.ShouldBeEquivalentTo(mgrRoute.MgRouteNumber);
                route.MgRoute.ShouldBeEquivalentTo(mgrRoute);
                route.Partner.ShouldBeEquivalentTo(owb.Partner);

                // проверяем дату
                owb.OWBOutDatePlan.Should().HaveValue();
                owb.OWBOutDatePlan.ShouldBeEquivalentTo(expectedDate);

                res.ShouldBeEquivalentTo(string.Format("Накладная с ID = {0} включена в маршрут {1} отгрузкой {2:dd.MM.yyyy HH:mm}", owb.OWBID, owb.OWBRoutePlan.Value, owb.OWBOutDatePlan.Value));

                // должен прописаться груз
                owb.WmsCargoOWB_List.Should().HaveCount(1);
                var cargo = owb.WmsCargoOWB_List.Single();
                cargo.Route.ShouldBeEquivalentTo(route);

                transaction.Rollback();
                //transaction.Commit();
            }
        }

        public static void PopulateTestData(ISession session, out WmsOWB owb, out DateTime expectedDate, out YMgRoute mgrRoute)
        {
            var tstMandant = session.Query<WmsMandant>().Single(i => i.PartnerCode == "TST");

            // создаем накладную с плановой датой отгрузки
            owb = new WmsOWB
            {
                Partner = tstMandant,
                OWBName = "Owb for testing routes",
                OWBProductNeed = "NOACTIVATE",
                OWBType = "OWBTYPENORMAL",
                Status = session.Query<WmsOWBStatus>().Single(i => i.StatusCode == "OWB_CREATED")
            };
            session.Save(owb);

            // проверяем если ли записи календаря на даты расчета (+2 дня)
            var exprectedTime = TimeSpan.FromHours(15);
            int timeToPrepare = 2880; //min
            int tmpTimeToPrepare = timeToPrepare;
            var dateIdx = 0;
            while (tmpTimeToPrepare > 0)
            {
                var tmpDate = GetOrAddCalendarDate(owb.DateIns.Value.Date.AddDays(dateIdx), session);
                // для первой даты вычитаем кол-во минут оставшегося раб.дня
                if (dateIdx == 0)
                {
                    if (owb.DateIns.Value < tmpDate.CalendarTimeTill)
                        tmpTimeToPrepare -= (int) (tmpDate.CalendarTimeTill - owb.DateIns.Value).TotalMinutes;
                }
                else
                {
                    tmpTimeToPrepare -= (int) (tmpDate.CalendarTimeTill - tmpDate.CalendarTimeFrom).TotalMinutes;
                }
                dateIdx++;
            }

            expectedDate = owb.DateIns.Value.AddDays(--dateIdx);

            //TODO: Разаобраться зачем нужен код внизу
            //if (expectedDate > expectedDate.Date.Add(exprectedTime))
            //{
            //    var tmpDate = GetOrAddCalendarDate(expectedDate.Date.AddDays(dateIdx), session);
            //    expectedDate = expectedDate.AddDays(1);
            //}
            //else
            //    expectedDate = expectedDate.Date.Add(exprectedTime);

            // создаем выбор даты
            // пока работаем с имеющимся, когда появится возможность работать с CPV - перейти на создание здесь
            var routeDateSelect = new YMgRouteDateSelect
            {
                Partner = tstMandant,
                MgRouteDateSelectDateSource = MgRouteDateSelectDateSources.OwbDateIns,
                Priority = 1
            };
            session.Save(routeDateSelect);

            // добавляем CPV
            var cpvRouteDSL1 = new YMgRouteDateSelectCPV()
            {
                CustomParam = session.Get<WmsCustomParam>("RouteDSL1"),
                MGROUTEDATESELECT = routeDateSelect
            };
            session.Save(cpvRouteDSL1);

            var cpvRouteDSUseWeekendL2 = new YMgRouteDateSelectCPV
            {
                CustomParam = session.Get<WmsCustomParam>("RouteDSUseWeekendL2"),
                MGROUTEDATESELECT = routeDateSelect,
                Parent = cpvRouteDSL1,
                CPVValue = "0"
            };
            session.Save(cpvRouteDSUseWeekendL2);

            var cpvRouteDSTimeConstL2 = new YMgRouteDateSelectCPV
            {
                CustomParam = session.Get<WmsCustomParam>("RouteDSTimeConstL2"),
                MGROUTEDATESELECT = routeDateSelect,
                Parent = cpvRouteDSL1,
                CPVValue = expectedDate.ToString("yyyyMMdd HH:mm:ss")
            };
            session.Save(cpvRouteDSTimeConstL2);

            var cpvRouteDSIncrementL2 = new YMgRouteDateSelectCPV
            {
                CustomParam = session.Get<WmsCustomParam>("RouteDSIncrementL2"),
                MGROUTEDATESELECT = routeDateSelect,
                Parent = cpvRouteDSL1,
                CPVValue = timeToPrepare.ToString()
            };
            session.Save(cpvRouteDSIncrementL2);

            var cpvRouteDSDateSourceL2 = new YMgRouteDateSelectCPV
            {
                CustomParam = session.Get<WmsCustomParam>("RouteDSDateSourceL2"),
                MGROUTEDATESELECT = routeDateSelect,
                Parent = cpvRouteDSL1,
                CPVValue = "DATEINS"
            };
            session.Save(cpvRouteDSDateSourceL2);

            // создаем менеджер маршрутов
            mgrRoute = new YMgRoute
            {
                Partner = tstMandant,
                MgRouteCreateRoute = false,
                MgRouteName = "Mgr for autotests",
                MgRouteNumber = "AutoTestRouteNumber"
            };
            session.Save(mgrRoute);

            // создаем выбор менеджера маршрутов
            var routeSelect = new YMgRouteSelect
            {
                Partner = tstMandant,
                MgRoute = mgrRoute,
                Priority = 1
            };
            session.Save(routeSelect);


            // создаем маршрут (создание из API проверить не получится, т.к. там, для блокировки параллельного создания, используются атомарные транзакции
            var route = new YRoute()
            {
                Partner = tstMandant,
                MgRoute = mgrRoute,
                RouteDate = expectedDate,
                RouteNumber = mgrRoute.MgRouteNumber // mgrRoute.MgRouteNumber
            };
            session.Save(route);

            session.Flush();

            // перечитываем DateSelect
            session.Refresh(routeDateSelect);
        }

        /// <summary>
        ///     Накладная:
        ///     * OWBOutDatePlan - да
        ///     * OWBRoutePlan - да
        ///     Маршрут уже существует
        ///     API
        ///     * ChangeOwbRoute(owb.OWBID, route.routeID, null, false, true)
        ///     Ожидание
        ///     * Exception, т.к. 002.021 еще не реализовано (красный цвет)
        /// </summary>
        [Test]
        public void Test5()
        {
            using (var session = _sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var fakeSession = new SessionDecorator(session) { DoNotDispose = true };
                var mockSessionFactory = new Mock<ISessionFactory>();
                mockSessionFactory.Setup(i => i.OpenSession()).Returns(fakeSession);

                #region populate test data

                var tstMandant = session.Query<WmsMandant>().Single(i => i.PartnerCode == "TST");

                // создаем менеджер маршрутов
                var mgrRoute = new YMgRoute
                {
                    Partner = tstMandant,
                    MgRouteCreateRoute = false,
                    MgRouteName = "Mgr for autotests",
                    MgRouteNumber = "AutoTestRouteNumber"
                };
                session.Save(mgrRoute);

                // создаем маршрут 
                var route = new YRoute()
                {
                    Partner = tstMandant,
                    MgRoute = mgrRoute,
                    RouteDate = DateTime.Now,
                    RouteNumber = mgrRoute.MgRouteNumber
                };
                session.Save(route);

                // создаем маршрут 
                var routeChange = new YRoute()
                {
                    Partner = tstMandant,
                    MgRoute = mgrRoute,
                    RouteDate = route.RouteDate.AddDays(1), 
                    RouteNumber = "TestRoute"
                };
                session.Save(routeChange);

                // создаем накладную с плановой датой отгрузки
                var owb = new WmsOWB
                {
                    Partner = tstMandant,
                    OWBName = "Owb for testing routes",
                    OWBProductNeed = "NOACTIVATE",
                    OWBType = "OWBTYPENORMAL",
                    OWBRoutePlan = route.RouteID,
                    OWBOutDatePlan = route.RouteDate,
                    Status = session.Query<WmsOWBStatus>().Single(i => i.StatusCode == "OWB_NONE")
                };
                session.Save(owb);
                
                session.Flush();
                
                #endregion

                try
                {
                    // запускаем
                    var api = new WmsAPI(mockSessionFactory.Object, _container.Resolve<IWmsXmlConverter>(), _container.Resolve<IWorkflowLoader>());
                    api.ChangeOwbRoute(owb.OWBID, routeChange.RouteID, route.RouteDate, false, true);
                }
                catch (OracleException ex)
                {
                    if (!string.IsNullOrEmpty(ex.Message))
                    {
                        var errorText = ex.Message.Split(new[] {"\n"}, StringSplitOptions.None);
                        errorText[0].ShouldBeEquivalentTo(string.Format("ORA-20801: В накладной с ID = {0} уже проставлен маршрут и он отличается от переданного/расчитанного({1})", owb.OWBID, routeChange.RouteID));
                    }
                    else
                    {
                        throw (ex);
                    }
                }
                transaction.Rollback();
            }
        }

        /// <summary>
        ///     Накладная:
        ///     * OWBOutDatePlan - есть
        ///     * OWBRoutePlan - нет
        ///     * Груз - есть (уже привязан к накладной)
        ///     * Привязан товар к наклданйо на месте - воротах
        ///     API
        ///     * ChangeOwbRoute(owb.OWBID, route.RouteID, null, false, true)
        ///     Ожидание
        ///     * Не должно быть ошибки о воротах (ORA:20800)
        /// </summary>
        [Test]
        public void Test6()
        {
            using (var session = _sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var fakeSession = new SessionDecorator(session) { DoNotDispose = true };
                var mockSessionFactory = new Mock<ISessionFactory>();
                mockSessionFactory.Setup(i => i.OpenSession()).Returns(fakeSession);

                const string testName = "TestName";
                const string mandantCode = "TST";

                var tstMandant = session.Query<WmsMandant>().Single(i => i.PartnerCode == mandantCode);

                // создаем маршрут
                var route = new YRoute
                {
                    Partner = tstMandant,
                    RouteDate = DateTime.Today.AddDays(3), // через 3 дня
                    RouteNumber = "AutoTestRoute"
                };
                session.Save(route);

                var cargo = new WmsCargoOWB
                {
                    Route = route
                };
                session.Save(cargo);

                // создаем накладную с плановой датой отгрузки
                var owb = new WmsOWB
                {
                    Partner = tstMandant,
                    OWBName = "Owb for testing routes",
                    OWBProductNeed = "NOACTIVATE",
                    OWBType = "OWBTYPENORMAL",
                    OWBOutDatePlan = route.RouteDate,
                    Status = session.Query<WmsOWBStatus>().Single(i => i.StatusCode == "OWB_NONE")
                };
                owb.WmsCargoOWB_List.Add(cargo);
                session.Save(owb);

                #region . CreatePlaceProductTE .

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

                #endregion

                session.Flush();

                try
                {
                    // запускаем
                    var api = new WmsAPI(mockSessionFactory.Object, _container.Resolve<IWmsXmlConverter>(), _container.Resolve<IWorkflowLoader>());
                    api.ChangeOwbRoute(owb.OWBID, route.RouteID, null, false, true);
                }
                catch (OracleException oraex)
                {
                    if (!string.IsNullOrEmpty(oraex.Message))
                    {
                        var errorText = oraex.Message.Split(new[] {"\n"}, StringSplitOptions.None);
                        errorText[0].Should().NotBe(string.Format("ORA-20800: По накладной с ID = {0} имеется товар на воротах отгрузки", owb.OWBID));
                    }
                    else
                    {
                        // Все OK
                    }
                }
                catch (Exception ex)
                {
                    // Все OK
                }
                transaction.Rollback();
            }
        }
        
        private static WmsCalendar GetOrAddCalendarDate(DateTime date, ISession session)
        {
            var item = session.Query<WmsCalendar>().FirstOrDefault(i => i.CalendarDate == date);
            if (item != null)
                return item;

            var calendar = new WmsCalendar
            {
                CalendarDate = date,
                CalendarTimeFrom = date,
                CalendarTimeTill = date.AddDays(1).AddSeconds(-1),
                CalendarType = "ON"
            };
            session.Save(calendar);
            return calendar;
        }
    }
}