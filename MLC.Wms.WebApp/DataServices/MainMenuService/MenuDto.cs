using System.Collections.Generic;
using Newtonsoft.Json;

namespace MLC.Wms.WebApp.DataServices.MainMenuService
{
    public class MenuDto
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("order")]
        public int? Order { get; set; }

        [JsonProperty("command")]
        public string Command { get; set; }

        [JsonProperty("parentCode")]
        public string ParentCode { get; set; }

        [JsonProperty("children")]
        public List<MenuDto> Children { get; set; }

        [JsonProperty("leaf")]
        public bool Leaf { get; set; }

        [JsonProperty("iconCls")]
        public string IconCls { get; set; }
    }
}