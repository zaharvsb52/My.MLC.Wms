using System;

namespace MLC.Wms.Common.Helpers
{
    public static class EnumHelper
    {
        public static TEnum ParseEnum<TEnum>(string source, TEnum defaultValue)
          where TEnum : struct
        {
            TEnum res;
            return Enum.TryParse(source, true, out res) ? res : defaultValue;
        }
    }
}
