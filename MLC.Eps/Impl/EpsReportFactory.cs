using System.Diagnostics.Contracts;
using MLC.Eps.Config;
using MLC.Eps.ExportFormat;

namespace MLC.Eps.Impl
{
    public class EpsReportFactory : IEpsReportFactory
    {
        private readonly IEpsConfiguration _configuration;
        private readonly IReportExporterFactory _reportExporterFactory;

        public EpsReportFactory(IEpsConfiguration configuration, IReportExporterFactory reportExporterFactory)
        {
            Contract.Requires(configuration != null);
            Contract.Requires(reportExporterFactory != null);

            _configuration = configuration;
            _reportExporterFactory = reportExporterFactory;
        }

        public virtual IEpsReport CreateReport(IEpsReportConfig config)
        {
            return new EpsFastReport(config, _configuration, _reportExporterFactory);
        }
    }
}