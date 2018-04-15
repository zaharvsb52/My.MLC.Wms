using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.Practices.Unity;
using MLC.Wms.Bootstrap;
using MLC.Wms.Common;
using MLC.Wms.Common.Environment;
using MLC.Wms.Common.Environment.Impl;
using MLC.Wms.Common.LocalStorage;
using MLC.Wms.Integration.Common;
using MLC.Wms.Integration.Common.Entities;
using MLC.Wms.Model.Entities;
using NHibernate;
using NHibernate.Linq;
using NUnit.Framework;

namespace MLC.Wms.Integration.Tests
{
    [TestFixture]
    public class MappingHelperTest
    {
        private ISessionFactory _factory;

        [OneTimeSetUp]
        public void Setup()
        {
            UnityConfig.RegisterComponents(container =>
            {
                _factory = container.Resolve<ISessionFactory>();

                container.RegisterType<IWmsEnvironmentInfoProvider, SvcWmsEnvironmentInfoProvider>(
                    new ContainerControlledLifetimeManager());
                container.RegisterType<ILocalData, ThreadStaticLocalData>(new ContainerControlledLifetimeManager());
                WmsEnvironment.Init(container.Resolve<IWmsEnvironmentInfoProvider>(),
                    container.Resolve<ILocalData>());
            });
        }

        [Test]
        public void DynamicMapTest()
        {
            using (var session = _factory.OpenSession())
            {
                var methods = GetType().GetMethods().Where(i => i.Name.StartsWith("TestMap_"));
                foreach (var method in methods)
                    method.Invoke(this, new[] {session});
            }
        }

        public void TestMap_TestWmsAddressBook2AddressBook(ISession session)
        {
            var source = session.Query<WmsAddressBook>().First();
            var target = MappingHelper.DynamicMap<AddressBook>(source);
            TestWmsAddressBook2AddressBook(source, target);
        }

        private void TestWmsAddressBook2AddressBook(WmsAddressBook source, AddressBook target)
        {
            if (source == null && target == null)
                return;

            target.ID.ShouldBeEquivalentTo(source.AddressBookID);
            target.Country.ShouldBeEquivalentTo(source.AddressBookCountry);
            target.Index.ShouldBeEquivalentTo(source.AddressBookIndex);
            target.Region.ShouldBeEquivalentTo(source.AddressBookRegion);
            target.City.ShouldBeEquivalentTo(source.AddressBookCity);
            target.District.ShouldBeEquivalentTo(source.AddressBookDistrict);
            target.Street.ShouldBeEquivalentTo(source.AddressBookStreet);
            target.Building.ShouldBeEquivalentTo(source.AddressBookBuilding);
            target.Apartment.ShouldBeEquivalentTo(source.AddressBookApartment);
            target.TypeCode.ShouldBeEquivalentTo(source.AddressBookTypeCode);
            target.Raw.ShouldBeEquivalentTo(source.AddressBookRaw);
            target.Default.ShouldBeEquivalentTo(source.AddressBookDefault);
            target.HostRef.ShouldBeEquivalentTo(source.AddressBookHostRef);
        }

        public void TestMap_TestWmsArt2Art(ISession session)
        {
            var source = session.Query<WmsArt>().First();
            var target = MappingHelper.DynamicMap<Art>(source);

            target.Code.ShouldBeEquivalentTo(source.ArtCode);
            target.Name.ShouldBeEquivalentTo(source.ArtName);
            target.FactoryHostRef.ShouldBeEquivalentTo(source.Factory?.FactoryCode);
            target.MandantCode.ShouldBeEquivalentTo(source.Partner.PartnerCode);
            target.Description.ShouldBeEquivalentTo(source.ArtDesc);
            target.DescriptionExt.ShouldBeEquivalentTo(source.ArtDescExt);
            target.ABCD.ShouldBeEquivalentTo(source.ArtABCD);
            target.Color.ShouldBeEquivalentTo(source.ArtColor);
            target.ColorTone.ShouldBeEquivalentTo(source.ArtColorTone);
            target.Size.ShouldBeEquivalentTo(source.ArtSize);
            target.PickOrder.ShouldBeEquivalentTo(source.ArtPickOrder);
            target.TempMin.ShouldBeEquivalentTo(source.ArtTempMin);
            target.TempMax.ShouldBeEquivalentTo(source.ArtTempMax);
            target.LifeTime.ShouldBeEquivalentTo(source.ArtLifeTime);
            target.LifeTimeMeasure.ShouldBeEquivalentTo(source.ArtLifeTimeMeasure);
            target.IWBType.ShouldBeEquivalentTo(source.ArtIWBType);
            target.DangerLevel.ShouldBeEquivalentTo(source.ArtDangerLevel);
            target.DangerSubLevel.ShouldBeEquivalentTo(source.ArtDangerSubLevel);
            target.HostRef.ShouldBeEquivalentTo(source.ArtHostRef);
            target.CommercTime.ShouldBeEquivalentTo(Convert.ToInt32(source.ArtCommercTime));
            target.CommercTimeMeasure.ShouldBeEquivalentTo(source.ArtCommercTimeMeasure);
            target.Mark.ShouldBeEquivalentTo(source.ArtMark);
            target.Brand.ShouldBeEquivalentTo(source.ArtBrand);
            target.Model.ShouldBeEquivalentTo(source.ArtModel);
            target.Type.ShouldBeEquivalentTo(source.ArtType);
            target.CountryCode.ShouldBeEquivalentTo(source.Country?.CountryCode);
            TestWmsmandant2Mandant(source.ArtManufacturer, target.Manufacturer);
            TestWmsFile2ArtPicture(source.ArtPicture, target.ArtPicture);
        }

        public void TestMap_TestWmsCPV2CPV(ISession session)
        {
            var source = session.Query<WmsCustomParamValue>().First();
            var target = MappingHelper.DynamicMap<CPV>(source);
            TestWmsCPV2CPV(source, target);
        }

        private void TestWmsCPV2CPV(WmsCustomParamValue source, CPV target)
        {
            if (source == null && target == null)
                return;

            target.Name.ShouldBeEquivalentTo(source.CustomParam.CustomParamCode);
            target.Value.ShouldBeEquivalentTo(source.CPVValue);
        }

        private void TestWmsCPVList2CPVList(List<WmsCustomParamValue> source, List<CPV> target)
        {
            source.Count.ShouldBeEquivalentTo(target.Count);
            foreach (var s in source)
                target.First(i => i.Name == s.CustomParam.CustomParamCode && i.Value == s.CPVValue);
        }


        public void TestMap_TestWmsClient2EcomClient(ISession session)
        {
            //var source = session.Query<WmsEci>().First();
            //var target = MappingHelper.DynamicMap<EcomClient>(source);
        }

        public void TestMap_TestWmsFactory2Factory(ISession session)
        {
            var source = session.Query<WmsFactory>().First();
            var target = MappingHelper.DynamicMap<Factory>(source);

            target.FactoryID.ShouldBeEquivalentTo(source.FactoryID);
            target.FactoryCode.ShouldBeEquivalentTo(source.FactoryCode);
            target.FactoryDesc.ShouldBeEquivalentTo(source.FactoryDesc);
            TestWmsmandant2Mandant(source.Partner, target.Partner);
            target.FactoryBatchCode.ShouldBeEquivalentTo(source.FactoryBatchCode);
            target.FactoryHostRef.ShouldBeEquivalentTo(source.FactoryHostRef);
        }

        public void TestMap_TestWmsFile2ArtPicture(ISession session)
        {
            var source = session.Query<WmsFile>().First();
            var target = MappingHelper.DynamicMap<ArtPicture>(source);
            TestWmsFile2ArtPicture(source, target);
        }

        private void TestWmsFile2ArtPicture(WmsFile source, ArtPicture target)
        {
            if (source == null && target == null)
                return;

            target.Name.ShouldBeEquivalentTo(source.FileName);
            target.Description.ShouldBeEquivalentTo(source.FileDesc);
            target.Entity.ShouldBeEquivalentTo(source.EntityName);
            target.FileData.ShouldBeEquivalentTo(source.FileData.ToString());
            target.ID.ShouldBeEquivalentTo(source.FileID);
            target.Key.ShouldBeEquivalentTo(source.FileKey);
            target.Link.ShouldBeEquivalentTo(source.FileLink);
            target.Size.ShouldBeEquivalentTo(source.FileSize);
            target.Version.ShouldBeEquivalentTo(source.FileVersion);
        }

        public void TestMap_TestIsoCountry2IsoCountry(ISession session)
        {
            var source = session.Query<Model.Entities.IsoCountry>().First();
            var target = MappingHelper.DynamicMap<Common.Entities.IsoCountry>(source);

            target.CountryCode.ShouldBeEquivalentTo(source.CountryCode);
            target.CountryNameEng.ShouldBeEquivalentTo(source.CountryNameEng);
            target.CountryNameRus.ShouldBeEquivalentTo(source.CountryNameRus);
            target.CountryAlpha2.ShouldBeEquivalentTo(source.CountryAlpha2);
            target.CountryNumeric.ShouldBeEquivalentTo(source.CountryNumeric);
        }

        public void TestMap_TestWmsIWB2IWB(ISession session)
        {
            var source = session.Query<WmsIWB>().First(i => i.IWBID == 7505);
            var target = MappingHelper.DynamicMap<IWB>(source);

            target.ID.ShouldBeEquivalentTo(source.IWBID);
            target.MandantCode.ShouldBeEquivalentTo(source.Partner.PartnerCode);
            target.Name.ShouldBeEquivalentTo(source.IWBName);
            target.Description.ShouldBeEquivalentTo(source.IWBDesc);
            target.Priority.ShouldBeEquivalentTo(source.IWBPriority);
            target.StatusCode.ShouldBeEquivalentTo(source.Status.StatusCode);
            target.InDatePlan.ShouldBeEquivalentTo(source.IWBInDatePlan);
            target.SenderHostRef.ShouldBeEquivalentTo(source.IWBSender?.PartnerHostRef);
            target.PayerHostRef.ShouldBeEquivalentTo(source.IWBPayer?.PartnerHostRef);
            target.Recipient.ShouldBeEquivalentTo(source.IWBRecipient?.PartnerHostRef);
            target.CMRNumber.ShouldBeEquivalentTo(source.IWBCMRNumber);
            target.CMRDate.ShouldBeEquivalentTo(source.IWBCMRDate);
            target.FactoryHostRef.ShouldBeEquivalentTo(source.Factory?.FactoryHostRef);
            target.TypeCode.ShouldBeEquivalentTo(source.IWBType);
            target.HostRef.ShouldBeEquivalentTo(source.IWBHostRef);
            target.Group.ShouldBeEquivalentTo(source.IWBGroup);
            // TODO нет аналога в WMS
            //target.OrderReturn.ShouldBeEquivalentTo(source.OrderReturn);
            if (source.IWB_WmsIWBPos_List == null)
                target.IWBPosList.Should().NotBeNull();
            else
            {
                source.IWB_WmsIWBPos_List.Count.ShouldBeEquivalentTo(target.IWBPosList.Count);
                foreach (var pos in source.IWB_WmsIWBPos_List)
                    TestWmsIWBPos2IWBPos(pos, target.IWBPosList.First(i => i.ID == pos.IWBPosID));
            }
            if (source.CPV_List == null)
                target.CPVList.Should().NotBeNull();
            else TestWmsCPVList2CPVList(source.CPV_List.Select(c => (WmsCustomParamValue) c).ToList(), target.CPVList);
        }

        public void TestMap_TestWmsIWBPos2IWBPos(ISession session)
        {
            var source = session.Query<WmsIWBPos>().First();
            var target = MappingHelper.DynamicMap<IWBPos>(source);

            TestWmsIWBPos2IWBPos(source, target);
        }

        private void TestWmsIWBPos2IWBPos(WmsIWBPos source = null, IWBPos target = null)
        {
            if (source == null && target == null)
                return;

            target.ID.ShouldBeEquivalentTo(source.IWBPosID);
            target.Line.ShouldBeEquivalentTo(source.IWBPosNumber);
            target.ArtName.ShouldBeEquivalentTo(source.SKU.Art.ArtName);
            target.ArtHostRef.ShouldBeEquivalentTo(source.SKU.Art.ArtHostRef);
            target.MeasureCode.ShouldBeEquivalentTo(source.SKU.Measure.MeasureCode);
            target.Count.ShouldBeEquivalentTo(source.IWBPosCount);
            target.Count2SKU.ShouldBeEquivalentTo(source.IWBPosCount2SKU);
            target.StatusCode.ShouldBeEquivalentTo(source.Status.StatusCode);
            target.Color.ShouldBeEquivalentTo(source.IWBPosColor);
            target.Tone.ShouldBeEquivalentTo(source.IWBPosTone);
            target.Size.ShouldBeEquivalentTo(source.IWBPosSize);
            target.Batch.ShouldBeEquivalentTo(source.IWBPosBatch);
            target.Lot.ShouldBeEquivalentTo(source.IWBPosLot);
            target.ExpiryDate.ShouldBeEquivalentTo(source.IWBPosExpiryDate);
            target.ProductDate.ShouldBeEquivalentTo(source.IWBPosProductDate);
            target.SerialNumber.ShouldBeEquivalentTo(source.IWBPosSerialNumber);
            target.FactoryHostRef.ShouldBeEquivalentTo(source.Factory?.FactoryHostRef);
            target.QLFCode.ShouldBeEquivalentTo(source.QLF?.QLFCode);
            // TODO нет аналога в WMS
            //target.QLFDetailCode.ShouldBeEquivalentTo(source.Detail);
            target.PriceValue.ShouldBeEquivalentTo(source.IWBPosPriceValue);
            target.IsManual.ShouldBeEquivalentTo(source.IWBPosManual);
            target.TECode.ShouldBeEquivalentTo(source.IWBPosTE);
            target.BatchCode.ShouldBeEquivalentTo(source.IWBBatchCode);
            target.BoxNumber.ShouldBeEquivalentTo(source.IWBPosBoxNumber);
            target.KitArtName.ShouldBeEquivalentTo(source.IWBPosKitArtName);
            target.Owner.ShouldBeEquivalentTo(source.IWBPosOwner.PartnerCode);
            target.InvoiceNumber.ShouldBeEquivalentTo(source.IWBPosInvoiceNumber);
            target.InvoiceDate.ShouldBeEquivalentTo(source.IWBPosInvoiceDate);
            target.ProductCount.ShouldBeEquivalentTo(source.IWBPosProductCount);
            target.Priority.ShouldBeEquivalentTo(source.IWBPosProductPriority);
            target.GTD.ShouldBeEquivalentTo(source.IWBPosGTD);
            target.HostRef.ShouldBeEquivalentTo(source.IWBPosHostRef);
            if (source.CPV_List == null)
                target.CPVList.Should().NotBeNull();
            else TestWmsCPVList2CPVList(source.CPV_List.Select(c => (WmsCustomParamValue) c).ToList(), target.CPVList);
        }

        public void TestMap_WmsTE2CargoSpace(ISession session)
        {
            var source = session.Query<WmsTE>().First();
            var target = MappingHelper.DynamicMap<CargoSpace>(source);

            target.Code.ShouldBeEquivalentTo(source.TECode);
            target.TypeCode.ShouldBeEquivalentTo(source.TEType.TETypeCode);
            target.CarrierBaseCode.ShouldBeEquivalentTo(source.TECarrierBaseCode);
            target.CarrierStreakCode.ShouldBeEquivalentTo(source.TECarrierStreakCode);
            target.CurrentPlace.ShouldBeEquivalentTo(source.TECurrentPlace.Code);
            target.CreationPlace.ShouldBeEquivalentTo(source.TECreationPlace);
            target.Length.ShouldBeEquivalentTo(source.TELength);
            target.Width.ShouldBeEquivalentTo(source.TEWidth);
            target.Height.ShouldBeEquivalentTo(source.TEHeight);
            target.StatusCode.ShouldBeEquivalentTo(source.Status.StatusCode);
            target.PackStatus.ShouldBeEquivalentTo(source.TEPackStatus);
            target.Weight.ShouldBeEquivalentTo(source.TEWeight);
            target.MaxWeight.ShouldBeEquivalentTo(source.TEMaxWeight);
            target.TareWeight.ShouldBeEquivalentTo(source.TETareWeight);
            target.HostRef.ShouldBeEquivalentTo(source.TEHostRef);
        }
      
        public void TestMap_TestWmsmandant2Mandant(ISession session)
        {
            var source = session.Query<WmsMandant>().First();
            var target = MappingHelper.DynamicMap<Mandant>(source);
            TestWmsmandant2Mandant(source, target);
        }

        private void TestWmsmandant2Mandant(WmsMandant source, Mandant target)
        {
            if (source == null && target == null)
                return;

            target.PartnerID.ShouldBeEquivalentTo(source.PartnerID);
            target.PartnerCode.ShouldBeEquivalentTo(source.PartnerCode);
            target.PartnerName.ShouldBeEquivalentTo(source.PartnerName);
            target.PartnerFullName.ShouldBeEquivalentTo(source.PartnerFullName);
            target.PartnerKind.ShouldBeEquivalentTo(source.PartnerKind);
            target.PartnerLocked.ShouldBeEquivalentTo(source.PartnerLocked);
            target.PartnerContract.ShouldBeEquivalentTo(source.PartnerContract);
            target.PartnerDateContract.ShouldBeEquivalentTo(source.PartnerDateContract);
            target.PartnerPhone.ShouldBeEquivalentTo(source.PartnerPhone);
            target.PartnerFax.ShouldBeEquivalentTo(source.PartnerFax);
            target.PartnerEmail.ShouldBeEquivalentTo(source.PartnerEmail);
            target.PartnerINN.ShouldBeEquivalentTo(source.PartnerINN);
            target.PartnerKPP.ShouldBeEquivalentTo(source.PartnerKPP);
            target.PartnerOGRN.ShouldBeEquivalentTo(source.PartnerOGRN);
            target.PartnerOKPO.ShouldBeEquivalentTo(source.PartnerOKPO);
            target.PartnerOKVED.ShouldBeEquivalentTo(source.PartnerOKVED);
            target.PartnerSettlementAccount.ShouldBeEquivalentTo(source.PartnerSettlementAccount);
            target.PartnerCorrespondentAccount.ShouldBeEquivalentTo(source.PartnerCorrespondentAccount);
            target.PartnerBIK.ShouldBeEquivalentTo(source.PartnerBIK);
            target.PartnerCommercTime.ShouldBeEquivalentTo(Convert.ToInt32(source.PartnerCommercTime));
            target.PartnerCommercTimeMeasure.ShouldBeEquivalentTo(source.PartnerCommercTimeMeasure);
            target.PartnerHostRef.ShouldBeEquivalentTo(source.PartnerHostRef);
        }

        public void TestMap_TestWmsProduct2Product(ISession session)
        {
            var source = session.Query<WmsProduct>().First();
            var target = MappingHelper.DynamicMap<Product>(source);

            target.ID.ShouldBeEquivalentTo(source.ProductID);
            target.TECode.ShouldBeEquivalentTo(source.TE.TECode);
            target.ArtHostRef.ShouldBeEquivalentTo(source.Art.ArtHostRef);
            target.MeasureCode.ShouldBeEquivalentTo(source.SKU.Measure.MeasureCode);
            target.Count.ShouldBeEquivalentTo(source.ProductCountSKU);
            target.Count2SKU.ShouldBeEquivalentTo(source.ProductCount);
            target.TTEQuantity.ShouldBeEquivalentTo(source.ProductTTEQuantity);
            target.QLFCode.ShouldBeEquivalentTo(source.QLF?.QLFCode);
            target.QLFDetailCode.ShouldBeEquivalentTo(source.QLFDetail?.QLFDetailCode);
            target.InputDate.ShouldBeEquivalentTo(source.ProductInputDate);
            target.ProductDate.ShouldBeEquivalentTo(source.ProductDate);
            target.Pack.ShouldBeEquivalentTo(source.ProductPack);
            target.PackCountSKU.ShouldBeEquivalentTo(source.ProductPackCountSKU);
            target.ExpiryDate.ShouldBeEquivalentTo(source.ProductExpiryDate);
            target.Batch.ShouldBeEquivalentTo(source.ProductBatch);
            target.Lot.ShouldBeEquivalentTo(source.ProductLot);
            target.SerialNumber.ShouldBeEquivalentTo(source.ProductSerialNumber);
            target.Color.ShouldBeEquivalentTo(source.ProductColor);
            target.Tone.ShouldBeEquivalentTo(source.ProductTone);
            target.Size.ShouldBeEquivalentTo(source.ProductSize);
            target.ArtName.ShouldBeEquivalentTo(source.Art.ArtName);
            target.MandantCode.ShouldBeEquivalentTo(source.Partner.PartnerCode);
            target.FactoryHostRef.ShouldBeEquivalentTo(source.Factory?.FactoryHostRef);
            target.StatusCode.ShouldBeEquivalentTo(source.Status.StatusCode);
            target.BatchCode.ShouldBeEquivalentTo(source.ProductBatchCode);
            target.BoxNumber.ShouldBeEquivalentTo(source.ProductBoxNumber);
            target.HostRef.ShouldBeEquivalentTo(source.ProductHostRef);
            target.KitArtName.ShouldBeEquivalentTo(source.ProductKitArtName);
            target.OwnerCode.ShouldBeEquivalentTo(source.ProductOwner.PartnerCode);
            target.Priority.ShouldBeEquivalentTo(source.ProductPriority);
            target.CountryCode.ShouldBeEquivalentTo(source.Country?.CountryCode);
            target.GTD.ShouldBeEquivalentTo(source.ProductGTD);

            // TODO до выхода нового релиза AutoMapper
            //target.Line.ShouldBeEquivalentTo(source.OWBPos?.OWBPosNumber);
            //target.IWBPosID.ShouldBeEquivalentTo(source.IWBPos?.IWBPosID);
            //target.OWBPosID.ShouldBeEquivalentTo(source.OWBPos?.OWBPosID);

        }

        public void TestMap_TestWmsPartner2Mandant(ISession session)
        {
            var source = session.Query<WmsPartner>().First();
            var target = MappingHelper.DynamicMap<Mandant>(source);

            target.PartnerID.ShouldBeEquivalentTo(source.PartnerID);
            target.PartnerCode.ShouldBeEquivalentTo(source.PartnerCode);
            target.PartnerName.ShouldBeEquivalentTo(source.PartnerName);
            target.PartnerFullName.ShouldBeEquivalentTo(source.PartnerFullName);
            target.PartnerKind.ShouldBeEquivalentTo(source.PartnerKind);
            target.PartnerLocked.ShouldBeEquivalentTo(source.PartnerLocked);
            target.PartnerContract.ShouldBeEquivalentTo(source.PartnerContract);
            target.PartnerDateContract.ShouldBeEquivalentTo(source.PartnerDateContract);
            target.PartnerPhone.ShouldBeEquivalentTo(source.PartnerPhone);
            target.PartnerFax.ShouldBeEquivalentTo(source.PartnerFax);
            target.PartnerEmail.ShouldBeEquivalentTo(source.PartnerEmail);
            target.PartnerINN.ShouldBeEquivalentTo(source.PartnerINN);
            target.PartnerKPP.ShouldBeEquivalentTo(source.PartnerKPP);
            target.PartnerOGRN.ShouldBeEquivalentTo(source.PartnerOGRN);
            target.PartnerOKPO.ShouldBeEquivalentTo(source.PartnerOKPO);
            target.PartnerOKVED.ShouldBeEquivalentTo(source.PartnerOKVED);
            target.PartnerSettlementAccount.ShouldBeEquivalentTo(source.PartnerSettlementAccount);
            target.PartnerCorrespondentAccount.ShouldBeEquivalentTo(source.PartnerCorrespondentAccount);
            target.PartnerBIK.ShouldBeEquivalentTo(source.PartnerBIK);
            target.PartnerCommercTime.ShouldBeEquivalentTo(Convert.ToInt32(source.PartnerCommercTime));
            target.PartnerCommercTimeMeasure.ShouldBeEquivalentTo(source.PartnerCommercTimeMeasure);
            target.PartnerHostRef.ShouldBeEquivalentTo(source.PartnerHostRef);
        }

        public void TestMap_TestWmsPartner2Partner(ISession session)
        {
            var source = session.Query<WmsPartner>().First();
            var target = MappingHelper.DynamicMap<Partner>(source);

            target.Name.ShouldBeEquivalentTo(source.PartnerName);
            target.FullName.ShouldBeEquivalentTo(source.PartnerFullName);
            target.Kind.ShouldBeEquivalentTo(source.PartnerKind);
            target.Contract.ShouldBeEquivalentTo(source.PartnerContract);
            target.DateContract.ShouldBeEquivalentTo(source.PartnerDateContract);
            target.Phone.ShouldBeEquivalentTo(source.PartnerPhone);
            target.Fax.ShouldBeEquivalentTo(source.PartnerFax);
            target.Email.ShouldBeEquivalentTo(source.PartnerEmail);
            target.INN.ShouldBeEquivalentTo(source.PartnerINN);
            target.KPP.ShouldBeEquivalentTo(source.PartnerKPP);
            target.OGRN.ShouldBeEquivalentTo(source.PartnerOGRN);
            target.OKPO.ShouldBeEquivalentTo(source.PartnerOKPO);
            target.OKVED.ShouldBeEquivalentTo(source.PartnerOKVED);
            target.SettlementAccount.ShouldBeEquivalentTo(source.PartnerSettlementAccount);
            target.CorrespondentAccount.ShouldBeEquivalentTo(source.PartnerCorrespondentAccount);
            target.BIK.ShouldBeEquivalentTo(source.PartnerBIK);
            target.HostRef.ShouldBeEquivalentTo(source.PartnerHostRef);

            if (!source.WmsAddressBook_List.Any())
                return;

            target.AddressList.Count().ShouldBeEquivalentTo(source.WmsAddressBook_List.Count());
            foreach (var adr in source.WmsAddressBook_List)
                TestWmsAddressBook2AddressBook(adr, target.AddressList.First(i => i.ID == adr.AddressBookID));
        }

        public void TestMap_TestWmsOWB2OWB(ISession session)
        {
            var source = session.Query<WmsOWB>().First();
            var target = MappingHelper.DynamicMap<OWB>(source);

            target.ID.ShouldBeEquivalentTo(source.OWBID);
            target.MandantCode.ShouldBeEquivalentTo(source.Partner.PartnerCode);
            target.Name.ShouldBeEquivalentTo(source.OWBName);
            target.Priority.ShouldBeEquivalentTo(source.OWBPriority);
            target.StatusCode.ShouldBeEquivalentTo(source.Status.StatusCode);
            target.OutDatePlan.ShouldBeEquivalentTo(source.OWBOutDatePlan);
            target.RecipientHostRef.ShouldBeEquivalentTo(source.OWBRecipient?.PartnerHostRef);
            target.PayerHostRef.ShouldBeEquivalentTo(source.OWBPayer?.PartnerHostRef);
            target.ClientRecipient.ShouldBeEquivalentTo(source.OWBClientRecipient);
            target.PlannedDeliveryDate.ShouldBeEquivalentTo(source.OWBPlannedDeliveryDate);
            target.ClientPayerHostRef.ShouldBeEquivalentTo(source.OWBClientRecipient?.ClientHostRef);
            target.Description.ShouldBeEquivalentTo(source.OWBDesc);
            target.FactoryHostRef.ShouldBeEquivalentTo(source.Factory?.FactoryHostRef);
            target.ProxyNumber.ShouldBeEquivalentTo(source.OWBProxyNumber);
            target.ProxyDate.ShouldBeEquivalentTo(source.OWBProxyDate);
            target.HostRefDate.ShouldBeEquivalentTo(source.OWBHostRefDate);
            target.TypeCode.ShouldBeEquivalentTo(source.OWBType);
            target.RoutePlan.ShouldBeEquivalentTo(source.OWBRoutePlan);
            target.HostRef.ShouldBeEquivalentTo(source.OWBHostRef);
            target.OwnerCode.ShouldBeEquivalentTo(source.OWBOwner?.PartnerCode);
            target.Group.ShouldBeEquivalentTo(source.OWBGroup);
            target.Carrier.ShouldBeEquivalentTo(source.OWBCarrier);
            target.PartnerOrder.ShouldBeEquivalentTo(source.OWBPartnerOrder);
            //TODO адрес не мапиться - разобраться
            //TestWmsAddressBook2AddressBook(source.AddressBook, target.Address);
            if (source.CPV_List == null)
                target.CPVList.Should().NotBeNull();
            else
            {
                source.CPV_List.Count.ShouldBeEquivalentTo(target.CPVList.Count);
                foreach (var s in source.CPV_List)
                {
                    target.CPVList.First(i => i.Name == s.CustomParam.CustomParamCode && i.Value == s.CPVValue);
                }
            }
            if (source.OWB_WmsOWBPos_List == null)
                target.OWBPosList.Should().NotBeNull();
            else
            {
                source.OWB_WmsOWBPos_List.Count.ShouldBeEquivalentTo(target.OWBPosList.Count);
                foreach (var pos in source.OWB_WmsOWBPos_List)
                    TestWmsOWBPos2OWBPos(pos, target.OWBPosList.First(i => i.ID == pos.OWBPosID));
            }
        }

        public void TestMap_TestWmsOWBPos2OWBPos(ISession session)
        {
            var source = session.Query<WmsOWBPos>().First();
            var target = MappingHelper.DynamicMap<OWBPos>(source);

            TestWmsOWBPos2OWBPos(source, target);
        }

        private void TestWmsOWBPos2OWBPos(WmsOWBPos source, OWBPos target)
        {
            if (source == null && target == null)
                return;

            target.ID.ShouldBeEquivalentTo(source.OWBPosID);
            target.Line.ShouldBeEquivalentTo(source.OWBPosNumber);
            target.ArtName.ShouldBeEquivalentTo(source.OWBPosArtName);
            target.ArtDesc.ShouldBeEquivalentTo(source.SKU.Art.ArtDesc);
            target.ArtHostRef.ShouldBeEquivalentTo(source.SKU.Art.ArtHostRef);
            target.MeasureCode.ShouldBeEquivalentTo(source.OWBPosMeasure);
            target.Count.ShouldBeEquivalentTo(source.OWBPosCount);
            target.Count2SKU.ShouldBeEquivalentTo(source.OWBPosCount2SKU);
            target.StatusCode.ShouldBeEquivalentTo(source.Status.StatusCode);
            target.Color.ShouldBeEquivalentTo(source.OWBPosColor);
            target.Tone.ShouldBeEquivalentTo(source.OWBPosTone);
            target.Size.ShouldBeEquivalentTo(source.OWBPosSize);
            target.Batch.ShouldBeEquivalentTo(source.OWBPosBatch);
            target.Lot.ShouldBeEquivalentTo(source.OWBPosLot);
            target.ExpiryDate.ShouldBeEquivalentTo(source.OWBPosExpiryDate);
            target.ProductDate.ShouldBeEquivalentTo(source.OWBPosProductDate);
            target.SerialNumber.ShouldBeEquivalentTo(source.OWBPosSerialNumber);
            target.FactoryHostRef.ShouldBeEquivalentTo(source.Factory?.FactoryHostRef);
            target.QLFCode.ShouldBeEquivalentTo(source.QLF?.QLFCode);
            target.QLFDetailCode.ShouldBeEquivalentTo(source.QLFDetailCode_r);
            target.PriceValue.ShouldBeEquivalentTo(source.OWBPosPriceValue);
            target.PriceValueVAT.ShouldBeEquivalentTo(source.OWBPosPriceValueVAT);
            target.Reserved.ShouldBeEquivalentTo(source.OWBPosReserved);
            target.BoxNumber.ShouldBeEquivalentTo(source.OWBPosBoxNumber);
            target.KitArtName.ShouldBeEquivalentTo(source.OWBPosKitArtName);
            target.Owner.ShouldBeEquivalentTo(source.OWBPosOwner?.PartnerCode);
            target.HostRef.ShouldBeEquivalentTo(source.OWBPosHostRef);
            if (source.CPV_List == null)
                target.CPVList.Should().NotBeNull();
            else TestWmsCPVList2CPVList(source.CPV_List.Select(c => (WmsCustomParamValue) c).ToList(), target.CPVList);
        }
    }
}