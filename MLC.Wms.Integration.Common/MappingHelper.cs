using AutoMapper;

namespace MLC.Wms.Integration.Common
{
    public static class MappingHelper
    {
        public static TDestination DynamicMap<TDestination>(object source)
        {
            return Mapper.Map<TDestination>(source);
        }
    }
}
