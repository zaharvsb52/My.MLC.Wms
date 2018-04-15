using System;
using System.Linq;
using AutoMapper;
using MLC.Wms.Integration.Common.Entities;
using MLC.Wms.Model.Entities;

namespace MLC.Wms.Bootstrap.Mapping
{
    public class WmsAddressBookMappingProfile : Profile
    {
        public WmsAddressBookMappingProfile()
        {
            RecognizePrefixes("AddressBook");
            CreateMap<WmsAddressBook, AddressBook>();
        }
    }

    public class WmsArtMappingProfile : Profile
    {
        public WmsArtMappingProfile()
        {
            RecognizePrefixes("Art");
            CreateMap<WmsArt, Art>()
                .ForMember(i => i.FactoryHostRef, i => i.MapFrom(j => j.Factory == null ? null : j.Factory.FactoryHostRef))
                .ForMember(i => i.MandantCode, i => i.MapFrom(j => j.Partner.PartnerCode))
                .ForMember(i => i.Description, i => i.MapFrom(j => j.ArtDesc))
                .ForMember(i => i.DescriptionExt, i => i.MapFrom(j => j.ArtDescExt))
                .ForMember(i => i.CountryCode, i => i.MapFrom(j => j.Country == null ? null : j.Country.CountryCode))
                .ForMember(i => i.CommercTime, i => i.MapFrom(j => Convert.ToInt32(j.ArtCommercTime)))
                .ForMember(i => i.Manufacturer, i => i.MapFrom(j => Mapper.Map<WmsMandant, Mandant>(j.ArtManufacturer)));
        }
    }

    public class WmsFactoryMappingProfile : Profile
    {
        public WmsFactoryMappingProfile()
        {
            CreateMap<WmsFactory,Factory>()
                .ForMember(i => i.Partner, i => i.MapFrom(j => Mapper.Map<WmsMandant, Mandant>(j.Partner)));
        }
    }

    public class WmsFileMappingProfile : Profile
    {
        public WmsFileMappingProfile()
        {
            RecognizePrefixes("File");
            CreateMap<WmsFile, ArtPicture>()
                .ForMember(i => i.Entity, i => i.MapFrom(j => j.EntityName))
                .ForMember(i => i.Description, i => i.MapFrom(j => j.FileDesc))
                .ForMember(i => i.FileData, i => i.MapFrom(j => j.FileData.ToString()));
        }
    }

    public class WmsCustomParamValueMappingProfile : Profile
    {
        public WmsCustomParamValueMappingProfile()
        {
            CreateMap<WmsCustomParamValue, CPV>()
                .ForMember(i => i.Name, i => i.MapFrom(j => j.CustomParam.CustomParamCode))
                .ForMember(i => i.Value, i => i.MapFrom(j => j.CPVValue));
            CreateMap<WmsArtCPV, CPV>().
                IncludeBase<WmsCustomParamValue, CPV>();
            CreateMap<WmsIWBCPV, CPV>().
                IncludeBase<WmsCustomParamValue, CPV>();
            CreateMap<WmsIWBPosCPV, CPV>().
                IncludeBase<WmsCustomParamValue, CPV>();
            CreateMap<WmsOWBPosCPV, CPV>().
                IncludeBase<WmsCustomParamValue, CPV>();
            CreateMap<WmsWorkerCPV, CPV>().
                IncludeBase<WmsCustomParamValue, CPV>();
            CreateMap<YExternalTrafficCPV, CPV>().
                IncludeBase<WmsCustomParamValue, CPV>();
            CreateMap<YMgRouteDateSelectCPV, CPV>().
                IncludeBase<WmsCustomParamValue, CPV>();
            CreateMap<WmsMMUseCPV, CPV>().
                IncludeBase<WmsCustomParamValue, CPV>();
            CreateMap<WmsPartnerCPV, CPV>().
                IncludeBase<WmsCustomParamValue, CPV>();
            CreateMap<EpsJobCPV, CPV>().
                IncludeBase<WmsCustomParamValue, CPV>();
            CreateMap<WmsReportCPV, CPV>().
                IncludeBase<WmsCustomParamValue, CPV>();

            // WmsCustomParamValueOWB, т.к. при создании нового инстанса OWB сущности нужно записать данные (и, соответственно, считать) из другой таблицы
            CreateMap<WmsCustomParamValueOWB, CPV>()
                .ForMember(i => i.Name, i => i.MapFrom(j => j.CustomParam.CustomParamCode))
                .ForMember(i => i.Value, i => i.MapFrom(j => j.CPVValue));
            CreateMap<WmsOWBCPV, CPV>().
                IncludeBase<WmsCustomParamValueOWB, CPV>();

        }
    }

    public class WmsIWBMappingProfile : Profile
    {
        public WmsIWBMappingProfile()
        {
            RecognizePrefixes("IWB");
            CreateMap<WmsIWB, IWB>()
                .ForMember(i => i.Description, i => i.MapFrom(j => j.IWBDesc))
                .ForMember(i => i.MandantCode, i => i.MapFrom(j => j.Partner.PartnerCode))
                .ForMember(i => i.StatusCode, i => i.MapFrom(j => j.Status.StatusCode))
                .ForMember(i => i.FactoryHostRef, i => i.MapFrom(j => j.Factory == null ? null : j.Factory.FactoryHostRef))
                .ForMember(i => i.SenderHostRef, i => i.MapFrom(j => j.IWBSender == null ? null : j.IWBSender.PartnerHostRef))
                .ForMember(i => i.PayerHostRef, i => i.MapFrom(j => j.IWBPayer == null ? null : j.IWBPayer.PartnerHostRef))
                .ForMember(i => i.Recipient, i => i.MapFrom(j => j.IWBRecipient == null ? null : j.IWBRecipient.PartnerHostRef))
                .ForMember(i => i.TypeCode, i => i.MapFrom(j => j.IWBType))
                .ForMember(i => i.IWBPosList, i => i.MapFrom(j => j.IWB_WmsIWBPos_List))
                .ForMember(i => i.CPVList, i => i.MapFrom(j => j.CPV_List));
        }
    }

    public class WmsIWBPosMappingProfile : Profile
    {
        public WmsIWBPosMappingProfile()
        {
            RecognizePrefixes("IWBPos");
            CreateMap<WmsIWBPos, IWBPos>()
                .ForMember(i => i.Line, i => i.MapFrom(j => j.IWBPosNumber))
                .ForMember(i => i.ArtName, i => i.MapFrom(j => j.SKU.Art.ArtName))
                .ForMember(i => i.ArtHostRef, i => i.MapFrom(j => j.SKU.Art.ArtHostRef))
                .ForMember(i => i.StatusCode, i => i.MapFrom(j => j.Status.StatusCode))
                .ForMember(i => i.FactoryHostRef, i => i.MapFrom(j => j.Factory == null ? null : j.Factory.FactoryHostRef))
                .ForMember(i => i.MeasureCode, i => i.MapFrom(j => j.SKU.Measure.MeasureCode))
                .ForMember(i => i.IsManual, i => i.MapFrom(j => j.IWBPosManual))
                .ForMember(i => i.TECode, i => i.MapFrom(j => j.IWBPosTE))
                .ForMember(i => i.Owner, i => i.MapFrom(j => j.IWBPosOwner.PartnerCode))
                .ForMember(i => i.Priority, i => i.MapFrom(j => j.IWBPosProductPriority))
                .ForMember(i => i.QLFCode, i => i.MapFrom(j => j.QLF == null ? null : j.QLF.QLFCode))
                .ForMember(i => i.CPVList, i => i.MapFrom(j => j.CPV_List));
        }
    }

    public class WmsOwbMappingProfile : Profile
    {
        public WmsOwbMappingProfile()
        {
            RecognizePrefixes("OWB");
            CreateMap<WmsOWB, OWB>()
                .ForMember(i => i.MandantCode, i => i.MapFrom(j => j.Partner.PartnerCode))
                .ForMember(i => i.StatusCode, i => i.MapFrom(j => j.Status.StatusCode))
                .ForMember(i => i.RecipientHostRef, i => i.MapFrom(j => j.OWBRecipient == null ? null : j.OWBRecipient.PartnerHostRef))
                .ForMember(i => i.PayerHostRef, i => i.MapFrom(j => j.OWBPayer == null ? null : j.OWBPayer.PartnerHostRef))
                .ForMember(i => i.Description, i => i.MapFrom(j => j.OWBDesc))
                .ForMember(i => i.FactoryHostRef, i => i.MapFrom(j => j.Factory == null ? null : j.Factory.FactoryHostRef))
                .ForMember(i => i.TypeCode, i => i.MapFrom(j => j.OWBType))
                .ForMember(i => i.OwnerCode, i => i.MapFrom(j => j.OWBOwner == null ? null : j.OWBOwner.PartnerCode))
                .ForMember(i => i.ClientPayerHostRef, i => i.MapFrom(j => j.OWBClientRecipient == null ? null : j.OWBClientRecipient.ClientHostRef))
                .ForMember(i => i.CPVList, i => i.MapFrom(j => j.CPV_List))
                .ForMember(i => i.OWBPosList, i => i.MapFrom(j => j.OWB_WmsOWBPos_List))
                .ForMember(i => i.Address, i => i.MapFrom(j => Mapper.Map<WmsAddressBook, AddressBook>(j.AddressBook)));
        }
    }

    public class WmsOwbPosMappingProfile : Profile
    {
        public WmsOwbPosMappingProfile()
        {
            RecognizePrefixes("OWBPos");
            CreateMap<WmsOWBPos, OWBPos>()
                .ForMember(i => i.ArtDesc, i => i.MapFrom(j => j.SKU.Art.ArtDesc))
                .ForMember(i => i.ArtHostRef, i => i.MapFrom(j => j.SKU.Art.ArtHostRef))
                .ForMember(i => i.StatusCode, i => i.MapFrom(j => j.Status.StatusCode))
                .ForMember(i => i.FactoryHostRef, i => i.MapFrom(j => j.Factory == null ? null : j.Factory.FactoryHostRef))
                .ForMember(i => i.QLFCode, i => i.MapFrom(j => j.QLF == null ? null : j.QLF.QLFCode))
                .ForMember(i => i.QLFDetailCode, i => i.MapFrom(j => j.QLFDetailCode_r))
                .ForMember(i => i.Owner, i => i.MapFrom(j => j.OWBPosOwner == null ? null : j.OWBPosOwner.PartnerCode))
                .ForMember(i => i.Line, i => i.MapFrom(j => j.OWBPosNumber))
                .ForMember(i => i.CPVList, i => i.MapFrom(j => j.CPV_List));
        }
    }

    public class WmsPartnerMappingProfile : Profile
    {
        public WmsPartnerMappingProfile()
        {
            RecognizePrefixes("Partner");
            CreateMap<WmsPartner, Partner>()
                .ForMember(i => i.AddressList, i => i.MapFrom(j => j.WmsAddressBook_List));
            CreateMap<WmsPartner, Mandant>()
                .ForMember(i => i.PartnerCommercTime, i => i.MapFrom(j => Convert.ToInt32(j.PartnerCommercTime)));
            CreateMap<WmsMandant, Mandant>()
               .ForMember(i => i.PartnerCommercTime, i => i.MapFrom(j => Convert.ToInt32(j.PartnerCommercTime))); ;
        }
    }

    public class WmsProductMappingProfile : Profile
    {
        public WmsProductMappingProfile()
        {
            RecognizePrefixes("Product");
            CreateMap<WmsProduct, Product>()
                .ForMember(i => i.ArtHostRef, i => i.MapFrom(j => j.Art.ArtHostRef))
                .ForMember(i => i.ArtName, i => i.MapFrom(j => j.Art.ArtName))
                .ForMember(i => i.Count, i => i.MapFrom(j => j.ProductCountSKU))
                .ForMember(i => i.Count2SKU, i => i.MapFrom(j => j.ProductCount))
                .ForMember(i => i.CountryCode, i => i.MapFrom(j => j.Country == null ? null : j.Country.CountryCode))
                .ForMember(i => i.FactoryHostRef, i => i.MapFrom(j => j.Factory == null ? null : j.Factory.FactoryHostRef))
                // TODO до выхода нового релиза AutoMapper
                //.ForMember(i => i.IWBPosID, i => i.MapFrom(s => s.OWBPos != null ? s.OWBPos.OWBPosID : default(int?)))
                //.ForMember(i => i.IWBPosID, i => i.MapFrom(s => s.IWBPos != null ? s.IWBPos.IWBPosID : default(int?)))
                //.ForMember(i => i.Line, i => i.MapFrom(s => s.IWBPos != null ? s.IWBPos.OWBPosNumber : default(int?)))
                .ForMember(i => i.MandantCode, i => i.MapFrom(j => j.Partner.PartnerCode))
                .ForMember(i => i.MeasureCode, i => i.MapFrom(j => j.SKU.Measure.MeasureCode))
                .ForMember(i => i.OwnerCode, i => i.MapFrom(j => j.ProductOwner.PartnerCode))
                .ForMember(i => i.QLFCode, i => i.MapFrom(j => j.QLF == null ? null : j.QLF.QLFCode))
                .ForMember(i => i.QLFDetailCode, i => i.MapFrom(j => j.QLFDetail == null ? null : j.QLFDetail.QLFDetailCode))
                .ForMember(i => i.StatusCode, i => i.MapFrom(j => j.Status.StatusCode))
                .ForMember(i => i.TECode, i => i.MapFrom(j => j.TE.TECode));
        }
    }

    public class WmsTEMappingProfile : Profile
    {
        public WmsTEMappingProfile()
        {
            RecognizePrefixes("TE");

            CreateMap<WmsTE, CargoSpace>()
                .ForMember(i => i.StatusCode, i => i.MapFrom(j => j.Status.StatusCode))
                .ForMember(i => i.TypeCode, i => i.MapFrom(j => j.TEType.TETypeCode))
                .ForMember(i => i.CurrentPlace, i => i.MapFrom(j => j.TECurrentPlace.Code));
        }
    }
}