using System;
using System.Collections.Generic;

namespace MLC.Wms.Model.Entities 
{
    public partial class WmsOWB
    {
        private ISet<WmsOWBPos> _oWB_WmsOWBPos_List = new HashSet<WmsOWBPos>();
        public virtual ISet<WmsOWBPos> OWB_WmsOWBPos_List { get { return _oWB_WmsOWBPos_List;} set { _oWB_WmsOWBPos_List = value; } }
    }

    public partial class WmsIWB
    {
        private ISet<WmsIWBPos> _iWB_WmsIWBPos_List = new HashSet<WmsIWBPos>();
        public virtual ISet<WmsIWBPos> IWB_WmsIWBPos_List { get { return _iWB_WmsIWBPos_List;} set { _iWB_WmsIWBPos_List = value; } }
    }

    public partial class CstReqCustoms
    {
        private ISet<CstReqCustomsPos> _reqCustoms_CstReqCustomsPos_List = new HashSet<CstReqCustomsPos>();
        public virtual ISet<CstReqCustomsPos> ReqCustoms_CstReqCustomsPos_List { get { return _reqCustoms_CstReqCustomsPos_List;} set { _reqCustoms_CstReqCustomsPos_List = value; } }
    }

    public partial class CstReqCustoms
    {
        private ISet<CstReqCustoms2WB> _reqCustoms_CstReqCustoms2WB_List = new HashSet<CstReqCustoms2WB>();
        public virtual ISet<CstReqCustoms2WB> ReqCustoms_CstReqCustoms2WB_List { get { return _reqCustoms_CstReqCustoms2WB_List;} set { _reqCustoms_CstReqCustoms2WB_List = value; } }
    }

    public partial class WmsOWB
    {
        public virtual CstReqCustoms2WB CstReqCustoms2WB { get; set; }
    }

    public partial class CstReqCustoms
    {
        private ISet<CstTransportContract> _reqCustoms_CstTransportContract_List = new HashSet<CstTransportContract>();
        public virtual ISet<CstTransportContract> ReqCustoms_CstTransportContract_List { get { return _reqCustoms_CstTransportContract_List;} set { _reqCustoms_CstTransportContract_List = value; } }
    }

    public partial class CstReqCustoms
    {
        private ISet<CstTransportDocument> _reqCustoms_CstTransportDocument_List = new HashSet<CstTransportDocument>();
        public virtual ISet<CstTransportDocument> ReqCustoms_CstTransportDocument_List { get { return _reqCustoms_CstTransportDocument_List;} set { _reqCustoms_CstTransportDocument_List = value; } }
    }

    public partial class WmsWorker
    {
        public virtual WmsWorkerPass WorkerPass { get; set; }
    }

    public partial class YExternalTraffic
    {
        private ISet<YInternalTraffic> _externalTraffic_YInternalTraffic_List = new HashSet<YInternalTraffic>();
        public virtual ISet<YInternalTraffic> ExternalTraffic_YInternalTraffic_List { get { return _externalTraffic_YInternalTraffic_List;} set { _externalTraffic_YInternalTraffic_List = value; } }
    }

    public partial class WmsTEType
    {
        private ISet<WmsSKU2TTE> _tEType_WmsSKU2TTE_List = new HashSet<WmsSKU2TTE>();
        public virtual ISet<WmsSKU2TTE> TEType_WmsSKU2TTE_List { get { return _tEType_WmsSKU2TTE_List;} set { _tEType_WmsSKU2TTE_List = value; } }
    }

    public partial class WmsPartner
    {
        private ISet<WmsEmployee> _partner_WmsEmployee_List = new HashSet<WmsEmployee>();
        public virtual ISet<WmsEmployee> Partner_WmsEmployee_List { get { return _partner_WmsEmployee_List;} set { _partner_WmsEmployee_List = value; } }
    }

    public partial class WmsOWB
    {
        private ISet<WmsEmployee2OWB> _oWB_WmsEmployee2OWB_List = new HashSet<WmsEmployee2OWB>();
        public virtual ISet<WmsEmployee2OWB> OWB_WmsEmployee2OWB_List { get { return _oWB_WmsEmployee2OWB_List;} set { _oWB_WmsEmployee2OWB_List = value; } }
    }

    public partial class EpsJob
    {
        private ISet<EpsTask2Job> _job_EpsTask2Job_List = new HashSet<EpsTask2Job>();
        public virtual ISet<EpsTask2Job> Job_EpsTask2Job_List { get { return _job_EpsTask2Job_List;} set { _job_EpsTask2Job_List = value; } }
    }

    public partial class EpsOutput
    {
        private ISet<EpsOutputParam> _output_EpsOutputParam_List = new HashSet<EpsOutputParam>();
        public virtual ISet<EpsOutputParam> Output_EpsOutputParam_List { get { return _output_EpsOutputParam_List;} set { _output_EpsOutputParam_List = value; } }
    }

    public partial class EpsOutputTask
    {
        private ISet<EpsOutputParam> _outputTask_EpsOutputParam_List = new HashSet<EpsOutputParam>();
        public virtual ISet<EpsOutputParam> OutputTask_EpsOutputParam_List { get { return _outputTask_EpsOutputParam_List;} set { _outputTask_EpsOutputParam_List = value; } }
    }

    public partial class EpsOutput
    {
        private ISet<EpsOutputTask> _output_EpsOutputTask_List = new HashSet<EpsOutputTask>();
        public virtual ISet<EpsOutputTask> Output_EpsOutputTask_List { get { return _output_EpsOutputTask_List;} set { _output_EpsOutputTask_List = value; } }
    }

    public partial class SchJob
    {
        private ISet<SchJobParam> _job_SchJobParam_List = new HashSet<SchJobParam>();
        public virtual ISet<SchJobParam> Job_SchJobParam_List { get { return _job_SchJobParam_List;} set { _job_SchJobParam_List = value; } }
    }

    public partial class SchJob
    {
        private ISet<SchTrigger> _job_SchTrigger_List = new HashSet<SchTrigger>();
        public virtual ISet<SchTrigger> Job_SchTrigger_List { get { return _job_SchTrigger_List;} set { _job_SchTrigger_List = value; } }
    }

    public partial class WmsTruck
    {
        private ISet<WmsMotionAreaGroup> _wmsMotionAreaGroup_List = new HashSet<WmsMotionAreaGroup>();
        public virtual ISet<WmsMotionAreaGroup> WmsMotionAreaGroup_List { get { return _wmsMotionAreaGroup_List;} set { _wmsMotionAreaGroup_List = value; } }
    }

    public partial class WmsMotionAreaGroup
    {
        private ISet<WmsTruck> _wmsTruck_List = new HashSet<WmsTruck>();
        public virtual ISet<WmsTruck> WmsTruck_List { get { return _wmsTruck_List;} set { _wmsTruck_List = value; } }
    }

    public partial class WmsOWB
    {
        private ISet<WmsCargoOWB> _wmsCargoOWB_List = new HashSet<WmsCargoOWB>();
        public virtual ISet<WmsCargoOWB> WmsCargoOWB_List { get { return _wmsCargoOWB_List;} set { _wmsCargoOWB_List = value; } }
    }

    public partial class WmsCargoOWB
    {
        private ISet<WmsOWB> _wmsOWB_List = new HashSet<WmsOWB>();
        public virtual ISet<WmsOWB> WmsOWB_List { get { return _wmsOWB_List;} set { _wmsOWB_List = value; } }
    }

    public partial class WmsIWB
    {
        private ISet<WmsCargoIWB> _wmsCargoIWB_List = new HashSet<WmsCargoIWB>();
        public virtual ISet<WmsCargoIWB> WmsCargoIWB_List { get { return _wmsCargoIWB_List;} set { _wmsCargoIWB_List = value; } }
    }

    public partial class WmsCargoIWB
    {
        private ISet<WmsIWB> _wmsIWB_List = new HashSet<WmsIWB>();
        public virtual ISet<WmsIWB> WmsIWB_List { get { return _wmsIWB_List;} set { _wmsIWB_List = value; } }
    }

    public partial class WmsRes
    {
        private ISet<WmsSupplyChain> _wmsSupplyChain_List = new HashSet<WmsSupplyChain>();
        public virtual ISet<WmsSupplyChain> WmsSupplyChain_List { get { return _wmsSupplyChain_List;} set { _wmsSupplyChain_List = value; } }
    }

    public partial class WmsSupplyChain
    {
        private ISet<WmsRes> _wmsRes_List = new HashSet<WmsRes>();
        public virtual ISet<WmsRes> WmsRes_List { get { return _wmsRes_List;} set { _wmsRes_List = value; } }
    }

    public partial class WmsWorker
    {
        private ISet<WmsAddressBook> _wmsAddressBook_List = new HashSet<WmsAddressBook>();
        public virtual ISet<WmsAddressBook> WmsAddressBook_List { get { return _wmsAddressBook_List;} set { _wmsAddressBook_List = value; } }
    }

    public partial class WmsAddressBook
    {
        private ISet<WmsWorker> _wmsWorker_List = new HashSet<WmsWorker>();
        public virtual ISet<WmsWorker> WmsWorker_List { get { return _wmsWorker_List;} set { _wmsWorker_List = value; } }
    }

    public partial class WmsWorkerGroup
    {
        private ISet<WmsWorker> _wmsWorker_List = new HashSet<WmsWorker>();
        public virtual ISet<WmsWorker> WmsWorker_List { get { return _wmsWorker_List;} set { _wmsWorker_List = value; } }
    }

    public partial class WmsWorker
    {
        private ISet<WmsWorkerGroup> _wmsWorkerGroup_List = new HashSet<WmsWorkerGroup>();
        public virtual ISet<WmsWorkerGroup> WmsWorkerGroup_List { get { return _wmsWorkerGroup_List;} set { _wmsWorkerGroup_List = value; } }
    }

    public partial class WmsWorking
    {
        private ISet<WmsWork2Entity> _wmsWork2Entity_List = new HashSet<WmsWork2Entity>();
        public virtual ISet<WmsWork2Entity> WmsWork2Entity_List { get { return _wmsWork2Entity_List;} set { _wmsWork2Entity_List = value; } }
    }

    public partial class WmsWork2Entity
    {
        private ISet<WmsWorking> _wmsWorking_List = new HashSet<WmsWorking>();
        public virtual ISet<WmsWorking> WmsWorking_List { get { return _wmsWorking_List;} set { _wmsWorking_List = value; } }
    }

    public partial class WmsMotionAreaGroup
    {
        private ISet<WmsMotionArea> _wmsMotionArea_List = new HashSet<WmsMotionArea>();
        public virtual ISet<WmsMotionArea> WmsMotionArea_List { get { return _wmsMotionArea_List;} set { _wmsMotionArea_List = value; } }
    }

    public partial class WmsMotionArea
    {
        private ISet<WmsMotionAreaGroup> _wmsMotionAreaGroup_List = new HashSet<WmsMotionAreaGroup>();
        public virtual ISet<WmsMotionAreaGroup> WmsMotionAreaGroup_List { get { return _wmsMotionAreaGroup_List;} set { _wmsMotionAreaGroup_List = value; } }
    }

    public partial class BillScale
    {
        private ISet<BillOperation2Contract> _billOperation2Contract_List = new HashSet<BillOperation2Contract>();
        public virtual ISet<BillOperation2Contract> BillOperation2Contract_List { get { return _billOperation2Contract_List;} set { _billOperation2Contract_List = value; } }
    }

    public partial class BillOperation2Contract
    {
        private ISet<BillScale> _billScale_List = new HashSet<BillScale>();
        public virtual ISet<BillScale> BillScale_List { get { return _billScale_List;} set { _billScale_List = value; } }
    }

    public partial class WmsEventHeader
    {
        private ISet<BillBiller> _billBiller_List = new HashSet<BillBiller>();
        public virtual ISet<BillBiller> BillBiller_List { get { return _billBiller_List;} set { _billBiller_List = value; } }
    }

    public partial class BillBiller
    {
        private ISet<WmsEventHeader> _wmsEventHeader_List = new HashSet<WmsEventHeader>();
        public virtual ISet<WmsEventHeader> WmsEventHeader_List { get { return _wmsEventHeader_List;} set { _wmsEventHeader_List = value; } }
    }

    public partial class BillWorkAct
    {
        private ISet<BillOperation2Contract> _billOperation2Contract_List = new HashSet<BillOperation2Contract>();
        public virtual ISet<BillOperation2Contract> BillOperation2Contract_List { get { return _billOperation2Contract_List;} set { _billOperation2Contract_List = value; } }
    }

    public partial class BillOperation2Contract
    {
        private ISet<BillWorkAct> _billWorkAct_List = new HashSet<BillWorkAct>();
        public virtual ISet<BillWorkAct> BillWorkAct_List { get { return _billWorkAct_List;} set { _billWorkAct_List = value; } }
    }

    public partial class WmsMandant
    {
        private ISet<BillBiller> _billBiller_List = new HashSet<BillBiller>();
        public virtual ISet<BillBiller> BillBiller_List { get { return _billBiller_List;} set { _billBiller_List = value; } }
    }

    public partial class BillBiller
    {
        private ISet<WmsMandant> _wmsMandant_List = new HashSet<WmsMandant>();
        public virtual ISet<WmsMandant> WmsMandant_List { get { return _wmsMandant_List;} set { _wmsMandant_List = value; } }
    }

    public partial class WmsPartnerGroup
    {
        private ISet<WmsPartner> _wmsPartner_List = new HashSet<WmsPartner>();
        public virtual ISet<WmsPartner> WmsPartner_List { get { return _wmsPartner_List;} set { _wmsPartner_List = value; } }
    }

    public partial class WmsPartner
    {
        private ISet<WmsPartnerGroup> _wmsPartnerGroup_List = new HashSet<WmsPartnerGroup>();
        public virtual ISet<WmsPartnerGroup> WmsPartnerGroup_List { get { return _wmsPartnerGroup_List;} set { _wmsPartnerGroup_List = value; } }
    }

    public partial class WmsPartner
    {
        private ISet<WmsAddressBook> _wmsAddressBook_List = new HashSet<WmsAddressBook>();
        public virtual ISet<WmsAddressBook> WmsAddressBook_List { get { return _wmsAddressBook_List;} set { _wmsAddressBook_List = value; } }
    }

    public partial class WmsAddressBook
    {
        private ISet<WmsPartner> _wmsPartner_List = new HashSet<WmsPartner>();
        public virtual ISet<WmsPartner> WmsPartner_List { get { return _wmsPartner_List;} set { _wmsPartner_List = value; } }
    }

    public partial class WmsQLFDetail
    {
        private ISet<WmsMandant> _wmsMandant_List = new HashSet<WmsMandant>();
        public virtual ISet<WmsMandant> WmsMandant_List { get { return _wmsMandant_List;} set { _wmsMandant_List = value; } }
    }

    public partial class WmsMandant
    {
        private ISet<WmsQLFDetail> _wmsQLFDetail_List = new HashSet<WmsQLFDetail>();
        public virtual ISet<WmsQLFDetail> WmsQLFDetail_List { get { return _wmsQLFDetail_List;} set { _wmsQLFDetail_List = value; } }
    }

    public partial class WmsQLF
    {
        private ISet<WmsMandant> _wmsMandant_List = new HashSet<WmsMandant>();
        public virtual ISet<WmsMandant> WmsMandant_List { get { return _wmsMandant_List;} set { _wmsMandant_List = value; } }
    }

    public partial class WmsMandant
    {
        private ISet<WmsQLF> _wmsQLF_List = new HashSet<WmsQLF>();
        public virtual ISet<WmsQLF> WmsQLF_List { get { return _wmsQLF_List;} set { _wmsQLF_List = value; } }
    }

    public partial class YExternalTraffic
    {
        public virtual String VDriverPass { get; set; }
    }

    public partial class YExternalTraffic
    {
        public virtual String VDriverAddress { get; set; }
    }

    public partial class WmsWorker
    {
        public virtual Boolean? VIsInBlackList { get; set; }
    }

    public partial class WmsWorker
    {
        public virtual String VFio { get; set; }
    }

    public partial class WmsWorker
    {
        public virtual Boolean VSecurityCheckPassed { get; set; }
    }

    public partial class YVehicle
    {
        public virtual String VRnMarkModel { get; set; }
    }

    public partial class WmsWorkerPass
    {
        public virtual String VTypeName { get; set; }
    }

    public partial class WmsProduct
    {
        public virtual String VArtGroupName { get; set; }
    }

    [Serializable]
    public partial class WmsOWBCPV : WmsCustomParamValueOWB
    {
        public virtual WmsOWB OWB { get; set; }
    }

    public partial class WmsOWB
    {
        private ISet<WmsOWBCPV> _cpv_List = new HashSet<WmsOWBCPV>();
        public virtual ISet<WmsOWBCPV> CPV_List { get { return _cpv_List;} set { _cpv_List = value; } }
    }

    [Serializable]
    public partial class WmsIWBCPV : WmsCustomParamValue
    {
        public virtual WmsIWB IWB { get; set; }
    }

    public partial class WmsIWB
    {
        private ISet<WmsIWBCPV> _cpv_List = new HashSet<WmsIWBCPV>();
        public virtual ISet<WmsIWBCPV> CPV_List { get { return _cpv_List;} set { _cpv_List = value; } }
    }

    [Serializable]
    public partial class WmsIWBPosCPV : WmsCustomParamValue
    {
        public virtual WmsIWBPos IWBPOS { get; set; }
    }

    public partial class WmsIWBPos
    {
        private ISet<WmsIWBPosCPV> _cpv_List = new HashSet<WmsIWBPosCPV>();
        public virtual ISet<WmsIWBPosCPV> CPV_List { get { return _cpv_List;} set { _cpv_List = value; } }
    }

    [Serializable]
    public partial class WmsOWBPosCPV : WmsCustomParamValue
    {
        public virtual WmsOWBPos OWBPOS { get; set; }
    }

    public partial class WmsOWBPos
    {
        private ISet<WmsOWBPosCPV> _cpv_List = new HashSet<WmsOWBPosCPV>();
        public virtual ISet<WmsOWBPosCPV> CPV_List { get { return _cpv_List;} set { _cpv_List = value; } }
    }

    [Serializable]
    public partial class WmsWorkerCPV : WmsCustomParamValue
    {
        public virtual WmsWorker WORKER { get; set; }
    }

    public partial class WmsWorker
    {
        private ISet<WmsWorkerCPV> _cpv_List = new HashSet<WmsWorkerCPV>();
        public virtual ISet<WmsWorkerCPV> CPV_List { get { return _cpv_List;} set { _cpv_List = value; } }
    }

    [Serializable]
    public partial class YExternalTrafficCPV : WmsCustomParamValue
    {
        public virtual YExternalTraffic EXTERNALTRAFFIC { get; set; }
    }

    public partial class YExternalTraffic
    {
        private ISet<YExternalTrafficCPV> _cpv_List = new HashSet<YExternalTrafficCPV>();
        public virtual ISet<YExternalTrafficCPV> CPV_List { get { return _cpv_List;} set { _cpv_List = value; } }
    }

    [Serializable]
    public partial class YMgRouteDateSelectCPV : WmsCustomParamValue
    {
        public virtual YMgRouteDateSelect MGROUTEDATESELECT { get; set; }
    }

    public partial class YMgRouteDateSelect
    {
        private ISet<YMgRouteDateSelectCPV> _cpv_List = new HashSet<YMgRouteDateSelectCPV>();
        public virtual ISet<YMgRouteDateSelectCPV> CPV_List { get { return _cpv_List;} set { _cpv_List = value; } }
    }

    [Serializable]
    public partial class WmsArtCPV : WmsCustomParamValue
    {
        public virtual WmsArt ART { get; set; }
    }

    public partial class WmsArt
    {
        private ISet<WmsArtCPV> _cpv_List = new HashSet<WmsArtCPV>();
        public virtual ISet<WmsArtCPV> CPV_List { get { return _cpv_List;} set { _cpv_List = value; } }
    }

    [Serializable]
    public partial class WmsMMUseCPV : WmsCustomParamValue
    {
        public virtual WmsMMUse MMUSE { get; set; }
    }

    public partial class WmsMMUse
    {
        private ISet<WmsMMUseCPV> _cpv_List = new HashSet<WmsMMUseCPV>();
        public virtual ISet<WmsMMUseCPV> CPV_List { get { return _cpv_List;} set { _cpv_List = value; } }
    }

    [Serializable]
    public partial class WmsPartnerCPV : WmsCustomParamValue
    {
        public virtual WmsPartner PARTNER { get; set; }
    }

    public partial class WmsPartner
    {
        private ISet<WmsPartnerCPV> _cpv_List = new HashSet<WmsPartnerCPV>();
        public virtual ISet<WmsPartnerCPV> CPV_List { get { return _cpv_List;} set { _cpv_List = value; } }
    }

    [Serializable]
    public partial class WmsMandantCPV : WmsCustomParamValue
    {
        public virtual WmsMandant MANDANT { get; set; }
    }

    public partial class WmsMandant
    {
        private ISet<WmsMandantCPV> _cpv_List = new HashSet<WmsMandantCPV>();
        public virtual ISet<WmsMandantCPV> CPV_List { get { return _cpv_List;} set { _cpv_List = value; } }
    }

    [Serializable]
    public partial class EpsJobCPV : WmsCustomParamValue
    {
        public virtual EpsJob EPSJOB { get; set; }
    }

    public partial class EpsJob
    {
        private ISet<EpsJobCPV> _cpv_List = new HashSet<EpsJobCPV>();
        public virtual ISet<EpsJobCPV> CPV_List { get { return _cpv_List;} set { _cpv_List = value; } }
    }

    [Serializable]
    public partial class WmsReportCPV : WmsCustomParamValue
    {
        public virtual WmsReport REPORT { get; set; }
    }

    public partial class WmsReport
    {
        private ISet<WmsReportCPV> _cpv_List = new HashSet<WmsReportCPV>();
        public virtual ISet<WmsReportCPV> CPV_List { get { return _cpv_List;} set { _cpv_List = value; } }
    }

    [Serializable]
    public partial class WmsReportCFG : EpsConfig
    {
         public virtual WmsReport REPORT { get; set; }
    }

    public partial class WmsReport
    {
        private ISet<WmsReportCFG> _cfg_List = new HashSet<WmsReportCFG>();
        public virtual ISet<WmsReportCFG> CFG_List { get { return _cfg_List;} set { _cfg_List = value; } }
    }

    [Serializable]
    public partial class EpsJobCFG : EpsConfig
    {
         public virtual EpsJob JOB { get; set; }
    }

    public partial class EpsJob
    {
        private ISet<EpsJobCFG> _cfg_List = new HashSet<EpsJobCFG>();
        public virtual ISet<EpsJobCFG> CFG_List { get { return _cfg_List;} set { _cfg_List = value; } }
    }

    [Serializable]
    public partial class EpsTaskCFG : EpsConfig
    {
         public virtual EpsTask TASK { get; set; }
    }

    public partial class EpsTask
    {
        private ISet<EpsTaskCFG> _cfg_List = new HashSet<EpsTaskCFG>();
        public virtual ISet<EpsTaskCFG> CFG_List { get { return _cfg_List;} set { _cfg_List = value; } }
    }

    [Serializable]
    public partial class WmsInvGroupStatus : WmsStatus { }

    [Serializable]
    public partial class WmsInvTaskStepStatus : WmsStatus { }

    [Serializable]
    public partial class WmsPLStatus : WmsStatus { }

    [Serializable]
    public partial class WmsPLPosStatus : WmsStatus { }

    [Serializable]
    public partial class WmsOWBStatus : WmsStatus { }

    [Serializable]
    public partial class WmsIWBStatus : WmsStatus { }

    [Serializable]
    public partial class WmsIWBPosStatus : WmsStatus { }

    [Serializable]
    public partial class WmsOWBPosStatus : WmsStatus { }

    [Serializable]
    public partial class WmsInvTaskStatus : WmsStatus { }

    [Serializable]
    public partial class WmsInvStatus : WmsStatus { }

    [Serializable]
    public partial class WmsInvTaskGroupStatus : WmsStatus { }

    [Serializable]
    public partial class WmsQSupplyChainStatus : WmsStatus { }

    [Serializable]
    public partial class WmsSupplyChainStatus : WmsStatus { }

    [Serializable]
    public partial class WmsInvReqStatus : WmsStatus { }

    [Serializable]
    public partial class CstReqCustomsStatus : WmsStatus { }

    [Serializable]
    public partial class WmsWorkStatus : WmsStatus { }

    [Serializable]
    public partial class YExternalTrafficStatus : WmsStatus { }

    [Serializable]
    public partial class YInternalTrafficStatus : WmsStatus { }

    [Serializable]
    public partial class WmsCommActStatus : WmsStatus { }

    [Serializable]
    public partial class WmsProductStatus : WmsStatus { }

    [Serializable]
    public partial class WmsPlaceStatus : WmsStatus { }

    [Serializable]
    public partial class WmsEventHeaderStatus : WmsStatus { }

    [Serializable]
    public partial class EventHeaderBillStatus : WmsStatus { }

    [Serializable]
    public partial class WmsTransportTaskStatus : WmsStatus { }

    [Serializable]
    public partial class WmsTEStatus : WmsStatus { }

    [Serializable]
    public partial class SysState2OperationStatus : WmsStatus { }

    [Serializable]
    public partial class SysArchInstStatus : WmsStatus { }

    [Serializable]
    public partial class SYSENUM_ART_FIFO : SysEnum { }

    [Serializable]
    public partial class SYSENUM_BPTRIGGER_MODE : SysEnum { }

    [Serializable]
    public partial class SYSENUM_OPERATION_BUSINESS : SysEnum { }

    [Serializable]
    public partial class USERENUM_CSTTRANSPORTDOC_TYPE : WmsUserEnum { }

    [Serializable]
    public partial class USERENUM_PASSPORTTYPE_TYPE : WmsUserEnum { }

    [Serializable]
    public partial class USERENUM_CAR_PARKINGAREA : WmsUserEnum { }

    [Serializable]
    public partial class USERENUM_CAR_COLOR : WmsUserEnum { }

    [Serializable]
    public partial class USERENUM_CAR_TYPE : WmsUserEnum { }

    [Serializable]
    public partial class USERENUM_VEHICLEDOC_TYPE : WmsUserEnum { }

}
