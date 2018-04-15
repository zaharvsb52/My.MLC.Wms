namespace MLC.Wms.Integration.Common
{
    /// <summary>
    /// Выгрузка объекта в XML
    /// </summary>
    public static class DebugDumps
    {
        public static string DumpToXML(this object obj)
        {
            return SerializationHelper.SerializeToXmlDocument(obj).InnerXml;
        }
    }
}