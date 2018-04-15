using System;
using System.Diagnostics.Contracts;
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
    public class WmsApiCustomsTestFixture : BaseDbWithWfTestFixture
    {
        /// <summary>
        /// Две накладные. В первой 3 позиции, во второй 2 позиции. При сворачивании должно получиться 4 позиции заявки
        /// 
        /// ----------|---|------|---|---|------|
        /// IWB       | 1 | 2    | 1 | 2 | 1    |
        /// IWBPos    | 1 | 1    | 2 | 2 | 3    |
        /// ----------|---|------|---|---|------|
        /// TNVD      | 1 | 1(А) | 2 | 1 | 1    |
        /// Country   | 1 | 1    | 1 | 2 | 1(А) |
        /// Art       | 1 | 1    | 1 | 1 | 2    |
        /// ----------|---|------|---|---|------|
        /// (А) - должно браться из артикула
        /// </summary>
        [Test]
        public void Smoke()
        {
            WithTemporarySession((session, transaction, container) =>
            {
                #region populate data

                var partner = session.Query<WmsMandant>().Single(i => i.PartnerCode == "TST");

                var reqState = new CstReqCustomsStatus()
                {
                    Status2Entity = "REQCUSTOMS",
                    StatusCode = "REQCUSTOMS_ATST",
                    StatusName = "REQCUSTOMS_ATST"
                };
                session.Save(reqState);

                var reqCustoms = new CstReqCustoms
                {
                    Partner = partner,
                    Status = reqState,
                };
                session.Save(reqCustoms);

                var country1 = new IsoCountry()
                {
                    CountryCode = "XX",
                    CountryNameRus = "ATST XX",
                    CountryNameEng = "ATST XX",
                    CountryNumeric = "888",
                    CountryAlpha2 = "11"
                };
                session.Save(country1);
                var country2 = new IsoCountry()
                {
                    CountryCode = "YY",
                    CountryNameRus = "ATST YY",
                    CountryNameEng = "ATST YY",
                    CountryNumeric = "999",
                    CountryAlpha2 = "22"
                };
                session.Save(country2);

                var art1 = new WmsArt
                {
                    ArtCode = "TST999111",
                    ArtName = "999111",
                    Partner = partner,
                    ArtABCD = 'A',
                    ArtPickOrder = 10,
                    ArtType = "TST",
                    Country = country1
                };
                session.Save(art1);

                var art1Cpv = new WmsArtCPV()
                {
                    ART = art1,
                    CustomParam = session.Query<WmsCustomParam>().Single(i => i.CustomParamCode == WmsArtCPV.ARTTNVD),
                    CPVValue = "1",
                };
                session.Save(art1Cpv);
                art1.CPV_List.Add(art1Cpv);

                var art2 = new WmsArt
                {
                    ArtCode = "TST999222",
                    ArtName = "999222",
                    Partner = partner,
                    ArtABCD = 'A',
                    ArtPickOrder = 10,
                    ArtType = "TST",
                    Country = country1
                };
                session.Save(art2);

                var measureType = new WmsMeasureType
                {
                    MeasureTypeCode = "ATST",
                    MeasureTypeName = "ATST"
                };
                session.Save(measureType);

                var measure = new WmsMeasure
                {
                    MeasureCode = "ATST",
                    MeasureName = "ATST",
                    MeasureShortName = "ATST",
                    MeasureType = measureType
                };
                session.Save(measure);

                var sku1 = new WmsSKU
                {
                    Art = art1,
                    Measure = measure,
                    SKUCount = 1,
                    SKUPrimary = true,
                    SKUName = "ATST1"
                };
                session.Save(sku1);
                var sku2 = new WmsSKU
                {
                    Art = art2,
                    Measure = measure,
                    SKUCount = 2,
                    SKUPrimary = true,
                    SKUName = "ATST2"
                };
                session.Save(sku2);

                var iwbPosState = new WmsIWBPosStatus
                {
                    Status2Entity = "IWB",
                    StatusCode = "IWBPOS_ATST",
                    StatusName = "IWBPOS_ATST"
                };
                session.Save(iwbPosState);

                var cpTnvd = session.Query<WmsCustomParam>().Single(i => i.CustomParamCode == WmsIWBPosCPV.IWBPosTNVD);
                var cpWeight = session.Query<WmsCustomParam>().Single(i => i.CustomParamCode == WmsIWBPosCPV.IWBPosWeightGross);

                // ГОТОВИМ НАКЛАДНУЮ №1
                var iwb1 = new WmsIWB
                {
                    Partner = partner,
                    IWBName = "AUTOTEST1",
                    IWBPriority = 100,
                    IWBType = "TEST"
                };
                session.Save(iwb1);

                var iwb1Pos1 = new WmsIWBPos
                {
                    IWB = iwb1,
                    IWBPosOwner = partner,
                    IWBPosNumber = 1,
                    SKU = sku1,
                    IWBPosCount = 10,
                    IWBPosCount2SKU = 10,
                    Status = iwbPosState,
                    Country = country1,
                    IWBPosPriceValue = 11
                };
                session.Save(iwb1Pos1);
                iwb1.IWB_WmsIWBPos_List.Add(iwb1Pos1);
                var iwb1Pos1TnvdCpv = new WmsIWBPosCPV
                {
                    IWBPOS = iwb1Pos1,
                    CustomParam = cpTnvd,
                    CPVValue = "1"
                };
                session.Save(iwb1Pos1TnvdCpv);
                iwb1Pos1.CPV_List.Add(iwb1Pos1TnvdCpv);
                var iwb1Pos1WeightCpv = new WmsIWBPosCPV
                {
                    IWBPOS = iwb1Pos1,
                    CustomParam = cpWeight,
                    CPVValue = "11"
                };
                session.Save(iwb1Pos1WeightCpv);
                iwb1Pos1.CPV_List.Add(iwb1Pos1WeightCpv);

                var iwb1Pos2 = new WmsIWBPos
                {
                    IWB = iwb1,
                    IWBPosOwner = partner,
                    IWBPosNumber = 2,
                    SKU = sku1,
                    IWBPosCount = 10,
                    IWBPosCount2SKU = 10,
                    Status = iwbPosState,
                    Country = country1,
                    IWBPosPriceValue = 12
                };
                session.Save(iwb1Pos2);
                iwb1.IWB_WmsIWBPos_List.Add(iwb1Pos2);
                var iwb1Pos2TnvdCpv = new WmsIWBPosCPV
                {
                    IWBPOS = iwb1Pos2,
                    CustomParam = cpTnvd,
                    CPVValue = "2"
                };
                session.Save(iwb1Pos2TnvdCpv);
                iwb1Pos2.CPV_List.Add(iwb1Pos2TnvdCpv);
                var iwb1Pos2WeightCpv = new WmsIWBPosCPV
                {
                    IWBPOS = iwb1Pos2,
                    CustomParam = cpWeight,
                    CPVValue = "12"
                };
                session.Save(iwb1Pos2WeightCpv);
                iwb1Pos2.CPV_List.Add(iwb1Pos2WeightCpv);

                var iwb1Pos3 = new WmsIWBPos
                {
                    IWB = iwb1,
                    IWBPosOwner = partner,
                    IWBPosNumber = 3,
                    SKU = sku2,
                    IWBPosCount = 10,
                    IWBPosCount2SKU = 10,
                    Status = iwbPosState,
                    IWBPosPriceValue = 13
                };
                session.Save(iwb1Pos3);
                iwb1.IWB_WmsIWBPos_List.Add(iwb1Pos3);
                var iwb1Pos3TnvdCpv = new WmsIWBPosCPV
                {
                    IWBPOS = iwb1Pos3,
                    CustomParam = cpTnvd,
                    CPVValue = "1"
                };
                session.Save(iwb1Pos3TnvdCpv);
                iwb1Pos3.CPV_List.Add(iwb1Pos3TnvdCpv);
                var iwb1Pos3WeightCpv = new WmsIWBPosCPV
                {
                    IWBPOS = iwb1Pos3,
                    CustomParam = cpWeight,
                    CPVValue = "13"
                };
                session.Save(iwb1Pos3WeightCpv);
                iwb1Pos3.CPV_List.Add(iwb1Pos3WeightCpv);

                // ГОТОВИМ НАКЛАДНУЮ №2

                var iwb2 = new WmsIWB
                {
                    Partner = partner,
                    IWBName = "AUTOTEST2",
                    IWBPriority = 100,
                    IWBType = "TEST"
                };
                session.Save(iwb2);

                var iwb2Pos1 = new WmsIWBPos
                {
                    IWB = iwb2,
                    IWBPosOwner = partner,
                    IWBPosNumber = 1,
                    SKU = sku1,
                    IWBPosCount = 10,
                    IWBPosCount2SKU = 10,
                    Status = iwbPosState,
                    Country = country1,
                    IWBPosPriceValue = 21
                };
                session.Save(iwb2Pos1);
                iwb2.IWB_WmsIWBPos_List.Add(iwb2Pos1);
                //var iwb2Pos1TnvdCpv = new WmsIWBPosCPV
                //{
                //    IWBPOS = iwb2Pos1,
                //    CustomParam = cpTnvd,
                //    CPVValue = "1"
                //};
                //session.Save(iwb2Pos1TnvdCpv);
                //iwb2Pos1.CPV_List.Add(iwb2Pos1TnvdCpv);
                var iwb2Pos1WeightCpv = new WmsIWBPosCPV
                {
                    IWBPOS = iwb2Pos1,
                    CustomParam = cpWeight,
                    CPVValue = "21"
                };
                session.Save(iwb2Pos1WeightCpv);
                iwb2Pos1.CPV_List.Add(iwb2Pos1WeightCpv);

                var iwb2Pos2 = new WmsIWBPos
                {
                    IWB = iwb2,
                    IWBPosOwner = partner,
                    IWBPosNumber = 2,
                    SKU = sku1,
                    IWBPosCount = 10,
                    IWBPosCount2SKU = 10,
                    Status = iwbPosState,
                    Country = country2,
                    IWBPosPriceValue = 22
                };
                session.Save(iwb2Pos2);
                iwb2.IWB_WmsIWBPos_List.Add(iwb2Pos2);
                var iwb2Pos2TnvdCpv = new WmsIWBPosCPV
                {
                    IWBPOS = iwb2Pos2,
                    CustomParam = cpTnvd,
                    CPVValue = "1"
                };
                session.Save(iwb2Pos2TnvdCpv);
                iwb2Pos2.CPV_List.Add(iwb2Pos2TnvdCpv);

                var iwb2Pos2WeightCpv = new WmsIWBPosCPV
                {
                    IWBPOS = iwb2Pos2,
                    CustomParam = cpWeight,
                    CPVValue = "22"
                };
                session.Save(iwb2Pos2WeightCpv);
                iwb2Pos2.CPV_List.Add(iwb2Pos2WeightCpv);


                // ПРИВЯЗЫВАЕМ НАКЛАДНЫЕ К ЗАЯВКЕ
                var req2iwb1 = new CstReqCustoms2WB()
                {
                    IWB = iwb1,
                    ReqCustoms = reqCustoms
                };
                session.Save(req2iwb1);
                reqCustoms.ReqCustoms_CstReqCustoms2WB_List.Add(req2iwb1);

                var req2iwb2 = new CstReqCustoms2WB()
                {
                    IWB = iwb2,
                    ReqCustoms = reqCustoms
                };
                session.Save(req2iwb2);
                reqCustoms.ReqCustoms_CstReqCustoms2WB_List.Add(req2iwb2);

                #endregion

                session.Flush();

                var api = container.Resolve<WmsAPI>();

                var res = api.FillReqCustomsPos(reqCustoms.ReqCustomsID, true);

                session.Flush();

                res.Should().BeTrue();

                // перечитываем
                session.Refresh(reqCustoms);
                reqCustoms.ReqCustoms_CstReqCustomsPos_List.Should().HaveCount(4);
                reqCustoms.ReqCustoms_CstReqCustomsPos_List.Should().ContainSingle(i =>
                    i.ReqCustomsTNVD == "2" &&
                    i.Country == country1 &&
                    i.Art == art1);
                reqCustoms.ReqCustoms_CstReqCustomsPos_List.Should().ContainSingle(i =>
                    i.ReqCustomsTNVD == "1" &&
                    i.Country == country2 &&
                    i.Art == art1);
                reqCustoms.ReqCustoms_CstReqCustomsPos_List.Should().ContainSingle(i =>
                    i.ReqCustomsTNVD == "1" &&
                    i.Country == country1 &&
                    i.Art == art2);
                var pos1 = reqCustoms.ReqCustoms_CstReqCustomsPos_List.Single(i =>
                    i.ReqCustomsTNVD == "1" &&
                    i.Country == country1 &&
                    i.Art == art1);
                pos1.ReqCustomsWeightGross.ShouldBeEquivalentTo(int.Parse(iwb1Pos1WeightCpv.CPVValue) + int.Parse(iwb2Pos1WeightCpv.CPVValue));
                pos1.ReqCustomsAmount.ShouldBeEquivalentTo(iwb1Pos1.IWBPosPriceValue + iwb2Pos1.IWBPosPriceValue);
                pos1.ReqCustomsCount.ShouldBeEquivalentTo(iwb1Pos1.IWBPosCount + iwb2Pos1.IWBPosCount);
            });
        }
    }

    public abstract class BaseDbWithWfTestFixture : BaseDbTestFixture
    {
        protected override void InitializeContainer(IUnityContainer container)
        {
            base.InitializeContainer(container);
            container.RegisterType<IWorkflowLoader, FileWorkflowLoader>(new ContainerControlledLifetimeManager(), new InjectionFactory(cc => new FileWorkflowLoader(Directory.GetCurrentDirectory(), false)));
        }
    }

    [TestFixture]
    public abstract class BaseDbTestFixture
    {
        private IUnityContainer _container;
        private ISessionFactory _sessionFactory;

        [OneTimeSetUp]
        public virtual void TestFixtureSetup()
        {
            UnityConfig.RegisterComponents(InitializeContainer);
        }

        protected virtual void InitializeContainer(IUnityContainer container)
        {
            _container = container;
            _sessionFactory = container.Resolve<ISessionFactory>();

            _container.RegisterType<IWmsEnvironmentInfoProvider, SvcWmsEnvironmentInfoProvider>(
                new ContainerControlledLifetimeManager());
            _container.RegisterType<ILocalData, ThreadStaticLocalData>(new ContainerControlledLifetimeManager());

            //WmsEnvironment.Init(_container.Resolve<IWmsEnvironmentInfoProvider>(), _container.Resolve<ILocalData>());

            var envProvider = new SvcWmsEnvironmentInfoProvider();
            envProvider.SetUserName("TECH_AUTOTEST");
            WmsEnvironment.Init(envProvider, _container.Resolve<ILocalData>());
        }

        protected virtual void WithChildContainer(Action<IUnityContainer> action)
        {
            Contract.Requires(action != null);

            using (var childContainer = _container.CreateChildContainer())
            {
                action(childContainer);
            }
        }

        protected virtual void WithTemporarySession(Action<ISession, ITransaction, IUnityContainer> action)
        {
            WithChildContainer(container =>
            {
                using (var session = _sessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var transactionDecorator = new TransactionDecorator(transaction) {DisableActions = true};
                        var sessionDecorator = new SessionDecorator(session)
                        {
                            DoNotDispose = true,
                            ExternalTransaction = transactionDecorator
                        };

                        var sessionFactoryMock = new Mock<ISessionFactory>();
                        sessionFactoryMock.Setup(i => i.OpenSession()).Returns(sessionDecorator);

                        container.RegisterInstance<ISessionFactory>(sessionFactoryMock.Object);

                        action(session, transaction, container);
                    }
                    finally
                    {
                        transaction.Rollback();
                    }
                }
            });
        }
    }
}