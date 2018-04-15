using System.Collections.Generic;

namespace MLC.Eps.WebApi.Controllers.V1.Models
{
    public class EpsOutputDto
    {
        public int OutputID { get; set; }
        public string Login_r { get; set; }
        public string Host_r { get; set; }
        public int EpsHandler { get; set; }
        public string ReportFileSubFolder_r { get; set; }
        public string OutputStatus { get; set; }
        public List<EpsOutputParamDto> Output_EpsOutputParam_List { get; set; }
        public List<EpsOutputTaskDto> Output_EpsOutputTask_List { get; set; }
    }
}