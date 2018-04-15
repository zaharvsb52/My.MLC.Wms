using System;
using Newtonsoft.Json;

namespace MLC.Wms.WebApp.DataServices.ReqCustoms
{
    public class MandantDto
    {
        public Guid? Id { get; set; }

        [JsonProperty("partnerName")]
        public string PartnerName { get; set; }

        [JsonProperty("partnerFullName")]
        public string PartnerFullName { get; set; }

    }
}