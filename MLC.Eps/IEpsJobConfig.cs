namespace MLC.Eps
{
    public interface IEpsJobConfig
    {
        int JobId { get; }

        IEpsTaskConfig[] Tasks { get; set; }
        IEpsReportConfig[] Reports { get; set; }
        EpsJobParameter[] Parameters { get; set; }
    }
}