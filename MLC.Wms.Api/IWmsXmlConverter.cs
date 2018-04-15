using System.Xml;
using MLC.Wms.Model.Entities;

namespace MLC.Wms.Api
{
    public interface IWmsXmlConverter
    {
        string DefaultDateTimeStringFormat { get; }
        XmlDocument ConvertFrom(BaseEntity entity);
    }
}