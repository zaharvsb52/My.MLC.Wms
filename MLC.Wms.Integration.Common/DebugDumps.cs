namespace MLC.Wms.Integration.Common
{
    /// <summary>
    /// �������� ������� � XML
    /// </summary>
    public static class DebugDumps
    {
        public static string DumpToXML(this object obj)
        {
            return SerializationHelper.SerializeToXmlDocument(obj).InnerXml;
        }
    }
}