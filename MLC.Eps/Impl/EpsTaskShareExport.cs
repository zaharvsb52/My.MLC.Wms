using System.IO;
using MLC.Eps.Config;

namespace MLC.Eps.Impl
{
    public class EpsTaskShareExport : EpsTask
    {
        public EpsTaskShareExport(IEpsTaskConfig config, IEpsConfiguration epsConfiguration, Archiver archiver)
            : base(config, epsConfiguration, archiver)
        {
        }

        protected override void ProcessFiles(FileContainer[] files)
        {
            var targetFolder = GetRequiredParameterValue<string>(EpsTaskParameterTypes.TargetFolder);
            // пытаемся создать папку - если не получится - тут и упадем
            if (!Directory.Exists(targetFolder))
                Directory.CreateDirectory(targetFolder);

            // проверяем

            // пишем отчеты
            foreach (var file in files)
            {
                var fullTargetFileName = Path.Combine(targetFolder, file.FileName);
                // NOTE: если файл уже существует - он будет перезаписан
                File.WriteAllBytes(fullTargetFileName, file.Data);
            }
        }
    }
}