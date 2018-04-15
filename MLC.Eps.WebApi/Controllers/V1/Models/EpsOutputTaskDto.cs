using System.Collections.Generic;

namespace MLC.Eps.WebApi.Controllers.V1.Models
{
    public class EpsOutputTaskDto
    {
        public int OutputTaskID { get; set; }
        public string OutputTaskCode { get; set; }
        public string OutputTaskStatus { get; set; }
        public List<EpsOutputParamDto> OutputTask_EpsOutputParam_List { get; set; }
    }
}
