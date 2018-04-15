namespace MLC.Eps.Config
{
    public interface IEpsConfiguration
    {
        string OdbcConnectionString { get; }
        string OdacConnectionString { get; }
        string ReportPath { get; }
        string ArchPath { get; }
        string TmpPath { get; }
    }
}