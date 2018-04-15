using MLC.Eps.Config;

namespace MLC.Eps.Impl
{
    public class EpsTaskPrintExport : EpsTask
    {
        public EpsTaskPrintExport(IEpsTaskConfig config, IEpsConfiguration epsConfiguration, Archiver archiver)
            : base(config, epsConfiguration, archiver)
        {
        }

        protected override void ExecuteInternal(IEpsReport[] reports)
        {
            var physicalPrinter = GetRequiredParameterValue<string>(EpsTaskParameterTypes.PhysicalPrinter);

            //TODO: исправить текущее поведение - кол-во копий должно задаваться для каждого отчета отдельно
            var copies = GetNotRequiredParameterValue(EpsTaskParameterTypes.Copies, 1);

            foreach (var report in reports)
            {
                //var copies = GetNotRequiredParameterValue(EpsTaskParameterTypes.Copies, report.ReportName, 1);
                report.Print(physicalPrinter, copies);
            }

            // Базовый код не вызываем. у нас нечего экпортировать или архивировать
            //base.ExecuteInternal(reports);
        }

        protected override void ProcessFiles(FileContainer[] files) { }
    }
}