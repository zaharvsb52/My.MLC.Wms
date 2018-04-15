using System;
using System.Collections.Concurrent;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace MLC.Wms.Integration.Common
{
    public static class NamespaceHelper
    {
        public const string V1Namespace = "http://wms.my.ru/services/v1/";
        public const string V1EntitiesNamespace = "http://wms.my.ru/services/v1/entities";

        static readonly ConcurrentDictionary<Type, DataContractSerializer> Serializers = new ConcurrentDictionary<Type, DataContractSerializer>();
        
        public static XmlDocument SerializeToXmlDocument(object obj)
        {
            

            using (var stream = new MemoryStream())
            {
                var ser = GetSerializer(obj.GetType());
                ser.WriteObject(stream, obj);
                var res = new XmlDocument();
                res.LoadXml(Encoding.UTF8.GetString(stream.GetBuffer()));
                return res;
            }
        }

        public static byte[] SerializeToBytes(object obj)
        {
            var xml = SerializeToXmlDocument(obj);
            return Encoding.UTF8.GetBytes(xml.OuterXml);
        }

        private static DataContractSerializer GetSerializer(Type type)
        {
            return Serializers.GetOrAdd(type, new DataContractSerializer(type));
        }
    }
}
