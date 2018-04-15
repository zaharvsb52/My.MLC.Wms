using System;
using Newtonsoft.Json;

namespace MLC.Wms.WebApp.DataServices.WorkerService
{
    public class WorkerDto
    {
        [JsonProperty("workerID")]
        public int WorkerID { get; set; }

        [JsonProperty("workerLastName")]
        public string WorkerLastName { get; set; }

        [JsonProperty("workerName")]
        public string WorkerName { get; set; }

        [JsonProperty("workerMiddleName")]
        public string WorkerMiddleName { get; set; }

        [JsonProperty("workerEmployee")]
        public bool WorkerEmployee { get; set; }

        [JsonProperty("workerPhoneWork")]
        public string WorkerPhoneWork { get; set; }

        [JsonProperty("workerPhoneMobile")]
        public string WorkerPhoneMobile { get; set; }

        [JsonProperty("workerEmailWork")]
        public bool WorkerEmailWork { get; set; }

        [JsonProperty("workerEmailPersonal")]
        public bool WorkerEmailPersonal { get; set; }

        [JsonProperty("workerBirthday")]
        public DateTime? WorkerBirthday { get; set; }
     }
}