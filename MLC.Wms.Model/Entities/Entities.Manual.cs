using System;
using System.Collections.Generic;
using System.Linq;

namespace MLC.Wms.Model.Entities
{
    public partial class WmsReportCPV
    {
        public const string ReportUseODACParameter = "ReportUseODAC";
    }

    [Serializable]
    public partial class WmsUser : BaseEntity
    {
        public virtual String UserCode { get; set; }
        public virtual String UserLastName { get; set; }
        public virtual String UserName { get; set; }
        public virtual String UserMiddleName { get; set; }
        public virtual Boolean UserMultipleDeviceEntry { get; set; }
        public virtual Boolean UserAuthentication { get; set; }
        public virtual String Login { get; set; }
        public virtual String UserPassword { get; set; }
        public virtual String LangCode_r { get; set; }
        public virtual String UserDepartment { get; set; }
        public virtual String UserDomain { get; set; }
        public virtual String UserEmail { get; set; }
        public virtual Boolean UserLocked { get; set; }
        public virtual String UserOfficialCapacity { get; set; }
        public virtual String UserWorkPhone { get; set; }
        public virtual String UserIns { get; set; }
        public virtual DateTime DateIns { get; set; }
        public virtual String UserUpd { get; set; }
        public virtual DateTime DateUpd { get; set; }
        public virtual Int32 Transact { get; set; }
        private ISet<WmsUser2Mandant> _wmsUser2Mandant_List = new HashSet<WmsUser2Mandant>();
        public virtual ISet<WmsUser2Mandant> WmsUser2Mandant_List { get { return _wmsUser2Mandant_List; } set { _wmsUser2Mandant_List = value; } }
        /// <summary>
        /// Список прав
        /// </summary>
        private ISet<Right> _right_List = new HashSet<Right>();
        public virtual ISet<Right> Right_List { get { return _right_List; } set { _right_List = value; } }
    }

    [Serializable]
    public partial class WmsMandant : BaseEntity
    {
        public virtual Int32 PartnerID { get; set; }
        public virtual String PartnerCode { get; set; }
        public virtual String PartnerName { get; set; }
        public virtual String PartnerFullName { get; set; }
        public virtual String PartnerKind { get; set; }
        public virtual Boolean PartnerLocked { get; set; }
        public virtual String PartnerContract { get; set; }
        public virtual DateTime? PartnerDateContract { get; set; }
        public virtual String PartnerPhone { get; set; }
        public virtual String PartnerFax { get; set; }
        public virtual String PartnerEmail { get; set; }
        public virtual String PartnerINN { get; set; }
        public virtual String PartnerKPP { get; set; }
        public virtual String PartnerOGRN { get; set; }
        public virtual String PartnerOKPO { get; set; }
        public virtual String PartnerOKVED { get; set; }
        public virtual String PartnerSettlementAccount { get; set; }
        public virtual String PartnerCorrespondentAccount { get; set; }
        public virtual String PartnerBIK { get; set; }
        public virtual Int32? PartnerCommercTime { get; set; }
        public virtual String PartnerCommercTimeMeasure { get; set; }
        public virtual String PartnerHostRef { get; set; }
        public virtual String UserIns { get; set; }
        public virtual DateTime? DateIns { get; set; }
        public virtual String UserUpd { get; set; }
        public virtual DateTime? DateUpd { get; set; }
        public virtual Int32 Transact { get; set; }
    }

    /// <summary>
    /// Право
    /// </summary>
    [Serializable]
    public class Right : BaseEntity
    {
        /// <summary>
        /// Код
        /// </summary>
        public virtual String RightCode { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public virtual String RightDesc { get; set; }
        /// <summary>
        /// Список пользователей
        /// </summary>
        private ISet<WmsUser> _user_List = new HashSet<WmsUser>();
        public virtual ISet<WmsUser> User_List { get { return _user_List; } set { _user_List = value; } }
    }

    public partial class YPurposeVisit
    {
        public const string LOADING_CODE = "Loading";
        public const string UNLOADING_CODE = "Unloading";
    }

    /// <summary>
    /// Монитор внутренних рейсов wmsMLC-11105
    /// </summary>
    [Serializable]
    public class YInternalTrafficMonitor : BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 InternalTrafficID { get; set; }
        /// <summary>
        /// Внутренний рейс
        /// </summary>
        public virtual YInternalTraffic InternalTraffic { get; set; }
    }

    /// <summary>
    /// Внутренний рейс
    /// </summary>
    public partial class YInternalTraffic
    {
        /// <summary>
        /// Монитор внутренних рейсов wmsMLC-11105
        /// </summary>
        public virtual YInternalTrafficMonitor InternalTrafficMonitor{ get; set; }
    }

    /// <summary>
    /// Значения пользовательских параметров OWB
    /// </summary>
    [Serializable]
    public partial class WmsCustomParamValueOWB : BaseEntity
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public virtual Int32 CPVID { get; set; }
        /// <summary>
        /// Параметр
        /// </summary>
        public virtual WmsCustomParam CustomParam { get; set; }
        /// <summary>
        /// Значение
        /// </summary>
        public virtual String CPVValue { get; set; }
        /// <summary>
        /// Владелец
        /// </summary>
        public virtual WmsCustomParamValueOWB Parent { get; set; }
        /// <summary>
        /// Добавил
        /// </summary>
        public virtual String UserIns { get; set; }
        /// <summary>
        /// Добавлено
        /// </summary>
        public virtual DateTime? DateIns { get; set; }
        /// <summary>
        /// Изменил
        /// </summary>
        public virtual String UserUpd { get; set; }
        /// <summary>
        /// Изменено
        /// </summary>
        public virtual DateTime? DateUpd { get; set; }
        /// <summary>
        /// #
        /// </summary>
        public virtual Int32 Transact { get; set; }
    }

    /// <summary>
    /// Накладные в заявке на декларирование
    /// </summary>
    public partial class CstReqCustoms2WB
    {
        /// <summary>
        /// Вид
        /// </summary>
        public virtual String VWayBillKind { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public virtual Int32 VWayBillId { get; set; }
        /// <summary>
        /// Номер
        /// </summary>
        public virtual String VWayBillName { get; set; }
        /// <summary>
        /// Тип
        /// </summary>
        public virtual String VWayBillType { get; set; }
    }

    /// <summary>
    /// Места
    /// </summary>
    public partial class WmsPlace
    {
        /// <summary>
        /// Код
        /// </summary>
        public virtual String Code { get; set; }
    }

    /// <summary>
    /// Партнёр
    /// </summary>
    public partial class WmsPartner
    {
        /// <summary>
        /// Таможенный пост
        /// </summary>
        public virtual Boolean VIsCustomsPost { get; set; }
    }

    public static partial class SysObjectMapping
    {
        public static SysObjectEntity GetEntityMappingByName(string sysObjectEntityName)
        {
            return GetSysObjectEntities().Single(s => s.SysObjectEntityName == sysObjectEntityName);
        }
    }

    public class SysObjectEntity
    {
        public string SysObjectEntityName;
        public string HibernateEntityName;
        public string PrimaryKeyColumnName;
    }

    public static class Strateges
    {
        public const string PLACE_FIX_LOAD = "PLACE_FIX_LOAD";
        public const string PLACE_FIX = "PLACE_FIX";
        public const string PLACE_FREE = "PLACE_FREE";
    }

    public static class Operations
    {
        public const string OP_MOVE_TE = "OP_MOVE_TE";
        public const string OP_PRODUCT_PART_LOAD = "OP_PRODUCT_PART_LOAD";
    }

    public partial class WmsIWBPosCPV
    {
        public const string IWBPosTNVD = "IWBPosTNVD";
        public const string IWBPosWeightGross = "IWBPosWeightGross";
    }

    public partial class WmsArtCPV
    {
        public const string ARTTNVD = "ARTTNVD";
    }

    public static class YExternalTrafficStatuses
    {
        public const string CAR_ARRIVED = "CAR_ARRIVED";
        public const string CAR_TRANSITTERRITORY = "CAR_TRANSITTERRITORY";
        public const string CAR_DEPARTED = "CAR_DEPARTED";
    }

    [Serializable]
	public class wmsEventDetailPRD : BaseEntity
    {
        #region sql
        /*
        select '        public virtual '||
               case when data_type = 'NUMBER' and data_precision > 0 then 'Double?'
                    when data_type = 'NUMBER' and data_precision is null then 'Int32?'
                    when data_type = 'DATE' then 'DateTime?'
                    when data_type = 'RAW' then 'Guid?'
                    when instr(data_type, 'CHAR') > 0 then 'String'
               end||' '||column_name||' { get; set; }'      
          from user_tab_columns
         where table_name = 'VWEVENTDETAILPRD_T'
         order by column_name;
         */
        #endregion sql
        public virtual String ARTCODE_R { get; set; }
        public virtual Int32? CARGOOWBID_R { get; set; }
        public virtual Int32? COMMACTID_R { get; set; }
        public virtual String COUNTRYCODE_R { get; set; }
        public virtual DateTime? DATEINS { get; set; }
        public virtual Int32? EVENTDETAILID { get; set; }
        public virtual Int32? EVENTHEADERID_R { get; set; }
        public virtual DateTime? EVENTHEADERSTARTTIME { get; set; }
        public virtual String EVENTKINDCODE_R { get; set; }
        public virtual Int32? FACTORYID_R { get; set; }
        public virtual Int32? HISTORYID_R { get; set; }
        public virtual Int32? INVTASKID_R { get; set; }
        public virtual Int32? IWBID_R { get; set; }
        public virtual String IWBNAME_R { get; set; }
        public virtual Int32? IWBPOSID_R { get; set; }
        public virtual Int32? IWBPOSNUMBER_R { get; set; }
        public virtual String OLDARTCODE_R { get; set; }
        public virtual String OLDCOUNTRYCODE_R { get; set; }
        public virtual Int32? OLDHISTORYID_R { get; set; }
        public virtual Int32? OLDIWBID_R { get; set; }
        public virtual String OLDIWBNAME_R { get; set; }
        public virtual Int32? OLDIWBPOSID_R { get; set; }
        public virtual Int32? OLDIWBPOSNUMBER_R { get; set; }
        public virtual Int32? OLDOWBID_R { get; set; }
        public virtual String OLDOWBNAME_R { get; set; }
        public virtual Int32? OLDOWBPOSID_R { get; set; }
        public virtual Int32? OLDOWBPOSNUMBER_R { get; set; }
        public virtual Int32? OLDPLID_R { get; set; }
        public virtual Int32? OLDPLPOSID_R { get; set; }
        public virtual String OLDPRODUCTBATCH { get; set; }
        public virtual String OLDPRODUCTBATCHCODE { get; set; }
        public virtual String OLDPRODUCTBOXNUMBER { get; set; }
        public virtual Double? OLDPRODUCTCOUNT { get; set; }
        public virtual Int32? OLDPRODUCTCOUNTSKU { get; set; }
        public virtual DateTime? OLDPRODUCTEXPIRYDATE { get; set; }
        public virtual String OLDPRODUCTHOSTREF { get; set; }
        public virtual Int32? OLDPRODUCTID_R { get; set; }
        public virtual DateTime? OLDPRODUCTINPUTDATE { get; set; }
        public virtual String OLDPRODUCTKITARTNAME { get; set; }
        public virtual String OLDPRODUCTLOT { get; set; }
        public virtual Int32? OLDPRODUCTOWNER { get; set; }
        public virtual String OLDPRODUCTPACK { get; set; }
        public virtual Int32? OLDPRODUCTPACKCOUNTSKU { get; set; }
        public virtual Int32? OLDPRODUCTPRIORITY { get; set; }
        public virtual Int32? OLDPRODUCTROOT { get; set; }
        public virtual String OLDPRODUCTSERIALNUMBER { get; set; }
        public virtual String OLDQLFCODE_R { get; set; }
        public virtual String OLDQLFDETAILCODE_R { get; set; }
        public virtual Int32? OLDSKUID_R { get; set; }
        public virtual String OLDTECODE_R { get; set; }
        public virtual String OLDTEPACKSTATUS { get; set; }
        public virtual String OLDTETYPECODE_R { get; set; }
        public virtual Int32? OWBID_R { get; set; }
        public virtual String OWBNAME_R { get; set; }
        public virtual Int32? OWBPOSID_R { get; set; }
        public virtual Int32? OWBPOSNUMBER_R { get; set; }
        public virtual Int32? PARTNERID_R { get; set; }
        public virtual Int32? PLID_R { get; set; }
        public virtual Int32? PLPOSID_R { get; set; }
        public virtual String PRODUCTBATCH { get; set; }
        public virtual String PRODUCTBATCHCODE { get; set; }
        public virtual String PRODUCTBOXNUMBER { get; set; }
        public virtual Double? PRODUCTCOUNT { get; set; }
        public virtual Int32? PRODUCTCOUNTSKU { get; set; }
        public virtual DateTime? PRODUCTEXPIRYDATE { get; set; }
        public virtual String PRODUCTHOSTREF { get; set; }
        public virtual Int32? PRODUCTID_R { get; set; }
        public virtual DateTime? PRODUCTINPUTDATE { get; set; }
        public virtual String PRODUCTKITARTNAME { get; set; }
        public virtual String PRODUCTLOT { get; set; }
        public virtual Int32? PRODUCTOWNER { get; set; }
        public virtual String PRODUCTPACK { get; set; }
        public virtual Int32? PRODUCTPACKCOUNTSKU { get; set; }
        public virtual Int32? PRODUCTPRIORITY { get; set; }
        public virtual Int32? PRODUCTROOT { get; set; }
        public virtual String PRODUCTSERIALNUMBER { get; set; }
        public virtual String QLFCODE_R { get; set; }
        public virtual String QLFDETAILCODE_R { get; set; }
        public virtual String QLFDETAILLIST { get; set; }
        public virtual Int32? SKUID_R { get; set; }
        public virtual String STATUSCODE_R { get; set; }
        public virtual String TECODE_R { get; set; }
        public virtual String TEPACKSTATUS { get; set; }
        public virtual String TETYPECODE_R { get; set; }
        public virtual String USERINS { get; set; }
    }
}
