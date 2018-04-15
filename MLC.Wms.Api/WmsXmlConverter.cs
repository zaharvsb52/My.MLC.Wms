using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml;
using MLC.Wms.Model.Entities;
using NHibernate;

namespace MLC.Wms.Api
{
    public class WmsXmlConverter : IWmsXmlConverter
    {
        private const string TrueString = "1";
        private const string FalseString = "0";
        private const string FloatPointSeparator = ".";

        private const string EventDetailEntityName = "EVENTDETAIL";

        private readonly ISessionFactory _sessionFactory;
        private readonly Dictionary<string, string> _entityToXml;

        public WmsXmlConverter(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;

            _entityToXml = new Dictionary<string, string>
            {
                {
                    typeof (WmsEventHeader).Name,
                    @"<TENTEVENTHEADER><EVENTHEADERID /><EVENTKINDCODE_R /><CLIENTTYPECODE_R /><OPERATIONCODE_R /><PROCESSCODE_R /><EVENTHEADEROPERATIONBUSINESS /><EVENTHEADERINSTANCE /><STATUSCODE_R>EVENT_CREATED</STATUSCODE_R><EVENTHEADERBILLSTATUS /><MANDANTID /><EVENTHEADERSTARTTIME /><EVENTHEADERENDTIME /><WORKID_R /><WORKINGID_R /><CLIENTSESSIONID_R /><USERINS /><DATEINS /><USERUPD /><DATEUPD /><TRANSACT /><VSTATUSNAME /><VCLIENTTYPENAME /><VOPERATIONBUSINESSNAME /><VEHSTATUSNAME /></TENTEVENTHEADER>"
                },
                {
                    EventDetailEntityName,
                    @"<TENTEVENTDETAIL><EVENTDETAILID/><EVENTHEADERID_R/><USERINS/><DATEINS/><EVENTKINDCODE_R/><STATUSCODE_R/><PARTNERID_R/><EXTERNALTRAFFICID_R/><INTERNALTRAFFICID_R/><EXTERNALTRAFFICDRIVER_R/><VEHICLEID_R/><VEHICLERN_R/><CARGOIWBID_R/><COMMACTID_R/><IWBID_R/><IWBNAME_R/><IWBPOSID_R/><IWBPOSNUMBER_R/><FACTORYID_R/><OWBID_R/><OWBNAME_R/><OWBSTATUSCODE_R/><QRESID_R/><WORKID_R/><WORKFROM_R/><WORKTILL_R/><WTVID_R/><WTVCOUNTSKU/><OLDWTVCOUNTSKU/><HISTORYID_R/><OLDHISTORYID_R/><PRODUCTID_R/><TTASKID_R/><PLACECODE_R/><RECEIVEAREACODE_R/><MOTIONAREACODE_R/><SUPPLYAREACODE_R/><OLDPLACECODE_R/><OLDRECEIVEAREACODE_R/><OLDMOTIONAREACODE_R/><OLDSUPPLYAREACODE_R/><MSCCODE_R/><MSCTYPECODE_R/><MSCFROM/><MSCTO/><MSCFINAL/><TECARRIERBASECODE/><OLDTECARRIERBASECODE/><PLID_R/><PLPOSID_R/><INVTASKID_R/><OLDPRODUCTID_R/><QLFDETAILLIST/></TENTEVENTDETAIL>"
                },
                {
                    typeof(WmsTE).Name,
                    @"<TENTTE><TECODE /><TETYPECODE_R /><TECARRIERBASECODE /><TECARRIERSTREAKCODE /><TECURRENTPLACE /><TECREATIONPLACE /><TELENGTH /><TEWIDTH /><TEHEIGHT /><STATUSCODE_R /><TEPACKSTATUS /><TEWEIGHT /><TEMAXWEIGHT /><TETAREWEIGHT /><TEHOSTREF /><CARGOOWBID_R /><SUPPLYCHAINID_R /><USERINS /><DATEINS /><USERUPD /><DATEUPD /><TE2BLOCK><TENTTE2BLOCKING><TE2BLOCKINGID /><TECODE_R /><BLOCKINGCODE_R /><TE2BLOCKINGDESC /><USERINS /><DATEINS /><USERUPD /><DATEUPD /><TRANSACT /></TENTTE2BLOCKING></TE2BLOCK><TRANSACT /><MANDANTID /><TETYPECODE_R_NAME /><TECURRENTPLACE_NAME /><TECREATIONPLACE_NAME /><STATUSCODE_R_NAME /><VTEPACKSTATUSNAME /><VCARGOOWBID /><VMANDANTCODE /><VOWB /><VSKUNAMECOUNT /><V_CALC /><V_CALC2 /></TENTTE>"
                }
            };
        }

        public string DefaultDateTimeStringFormat => "yyyyMMdd HH:mm:ss";

        public XmlDocument ConvertFrom(BaseEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            var xml = GetXml(entity);
            if (string.IsNullOrEmpty(xml))
                throw new NotImplementedException(string.Format("Convert entity '{0}' to xml is not implemented yet.",
                    entity.GetType().Name));

            var res = ConverToXmlDoc(entity, xml);
            return res;
        }

        private string GetXml(BaseEntity entity)
        {
            var entityName = entity.GetType().Name;
            if (_entityToXml.ContainsKey(entityName))
                return _entityToXml[entityName];

            if (entityName.ToUpper().Contains(EventDetailEntityName))
                return _entityToXml[EventDetailEntityName];

            return null;
        }

        private XmlDocument ConverToXmlDoc(object obj, string xml)
        {
            if (obj == null || string.IsNullOrEmpty(xml))
                return null;

            var xmldoc = new XmlDocument();
            xmldoc.LoadXml(xml);

            var entityname = obj.GetType().Name;
            var classMetadata = _sessionFactory.GetClassMetadata(entityname) as NHibernate.Persister.Entity.AbstractEntityPersister;
            if (classMetadata == null)
                throw new Exception(string.Format("Internal error in IWmsXmlConverter: no metadata founds for entity '{0}'.", entityname));

            var properties = TypeDescriptor.GetProperties(obj.GetType()).Cast<PropertyDescriptor>().ToArray();
            var keycols = classMetadata.KeyColumnNames;

            //colname, PropertyDescriptor
            var cols = new Dictionary<string, PropertyDescriptor>();

            //Получаем атрибуты сущности. Внимание, атрибуты сущности не всегда равны атрибутам tent сущности
            foreach (var prop in properties)
            {
                string col;
                try
                {
                    col = classMetadata.GetSubclassPropertyColumnNames(prop.Name).FirstOrDefault();
                }
                catch (ArgumentNullException)
                {
                    //Если нет такого столбца
                    continue;
                }

                if (string.IsNullOrEmpty(col))
                    continue;
                cols[col.ToUpper()] = prop;
            }

            foreach (XmlNode node in xmldoc.FirstChild.ChildNodes)
            {
                if (node.HasChildNodes)
                    continue;

                var nodename = node.Name;
                if (!cols.ContainsKey(nodename))
                {
                    //HUCK: MANDANTID
                    if (nodename == "MANDANTID")
                        nodename = "PARTNERID_R";

                    if (!cols.ContainsKey(nodename))
                        continue;
                }

                var property = cols[nodename];
                var value = property.GetValue(obj);
                if (value != null)
                {
                    //Проверка ключевых свойств
                    if (keycols != null && keycols.Length > 0 && keycols.Any(p => p == property.Name) &&
                            Equals(value, GetDefault(property.PropertyType)))
                        continue;

                    if (typeof (BaseEntity).IsAssignableFrom(property.PropertyType))
                    {
                        var keyvalue = GetKey(value);
                        if (keyvalue == null)
                            continue;
                        value = keyvalue;
                    }

                    node.InnerText = GetCorrectStringValue(value);
                }
            }
            
            return xmldoc;
        }

        private object GetKey(object obj)
        {
            //NOTE: К нам может прийти обертка (Proxy). В этом случае разворачиваем до базового класса.
            //      Возможно, придется сделать рекурсивный спуск к первому не IsAutoClass
            var targetType = obj.GetType();
            if (targetType.IsAutoClass && targetType.BaseType != null)
                targetType = targetType.BaseType;

            var classMetadata = _sessionFactory.GetClassMetadata(targetType.Name) as NHibernate.Persister.Entity.AbstractEntityPersister;
            if (classMetadata == null)
                throw new Exception(string.Format("Internal error in IWmsXmlConverter: no metadata founds for entity '{0}'.", targetType.Name));
            var keycols = classMetadata.KeyColumnNames;
            if (keycols == null || keycols.Length == 0 || keycols.Length > 1)
                return null;

            var property = TypeDescriptor.GetProperties(obj.GetType()).Cast<PropertyDescriptor>().ToArray().SingleOrDefault(p => p.Name == keycols[0]);
            if (property == null)
                return null;

            var res = property.GetValue(obj);
            return res;
        }

        private string GetCorrectStringValue(object sourceValue)
        {
            if (sourceValue == null)
                return null;

            if (sourceValue is bool)
                return (bool)sourceValue ? TrueString : FalseString;

            if (sourceValue is DateTime)
            {
                var value = (DateTime)sourceValue;
                return value.ToString(DefaultDateTimeStringFormat);
            }

            if (sourceValue is Guid)
                return ((Guid)sourceValue).ToString("N").ToUpper();

            if (IsFloatType(sourceValue.GetType()))
                return sourceValue.ToString().Replace(".", FloatPointSeparator).Replace(",", FloatPointSeparator);

            var res = sourceValue.ToString();
            return res;
        }

        private bool IsFloatType(Type type)
        {
            return type == typeof (float) ||
                   type == typeof (float?) ||
                   type == typeof (double) ||
                   type == typeof (double?) ||
                   type == typeof (decimal) ||
                   type == typeof (decimal?);
        }

        private object GetDefault(Type type)
        {
            if (type.IsValueType)
                return Activator.CreateInstance(type);
            return null;
        }
    }
}
