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
            // �������� ������� ����� - ���� �� ��������� - ��� � ������
            if (!Directory.Exists(targetFolder))
                Directory.CreateDirectory(targetFolder);

            // ���������

            // ����� ������
            foreach (var file in files)
            {
                var fullTargetFileName = Path.Combine(targetFolder, file.FileName);
                // NOTE: ���� ���� ��� ���������� - �� ����� �����������
                File.WriteAllBytes(fullTargetFileName, file.Data);
            }
        }
    }
}