using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using log4net;
using MLC.Eps.Config;

namespace MLC.Eps.Impl
{
    /// <summary>
    /// Задача сервиса EPS
    /// </summary>
    public abstract class EpsTask : IEpsTask
    {
        #region .  Fields  .

        protected readonly ILog Log;
        protected readonly IEpsTaskConfig _config;
        private readonly IEpsConfiguration _epsConfiguration;
        private readonly Archiver _archiver;

        #endregion

        #region .  Properties  .
        public ExportType ExportType
        {
            get { return _config.ExportType; }
        }

        public int TaskOrder { get { return _config.TaskOrder; } }

        public bool IsNeedReserveCopy { get { return _config.IsNeedReserveCopy; } }

        public bool IsNeedZip { get { return _config.IsNeedZip; } } 
        #endregion

        public EpsTask(IEpsTaskConfig config,
            IEpsConfiguration epsConfiguration,
            Archiver archiver)
        {
            Contract.Requires(config != null);
            Contract.Requires(epsConfiguration != null);
            Contract.Requires(archiver != null);

            Log = LogManager.GetLogger(GetType());
            _config = config;
            _epsConfiguration = epsConfiguration;
            _archiver = archiver;

            CheckConfig();
        }

        protected virtual void CheckConfig()
        {
            if (_config.HandleTaskComplete == null)
                throw new Exception("Handler for task complete processing is not set. Please, check task config class.");
        }

        public void Execute(IEpsReport[] reports)
        {
            var sw = new Stopwatch();
            sw.Start();
            Exception exception = null;
            try
            {
                ExecuteInternal(reports);
            }
            catch (Exception ex)
            {
                exception = ex;
                throw;
            }
            finally
            {
                sw.Stop();
                _config.HandleTaskComplete(_config.TaskId, exception, sw.Elapsed);
            }
        }

        protected virtual void ExecuteInternal(IEpsReport[] reports)
        {
            var files = PrepareFiles(reports);

            ProcessFiles(files);

            if (IsNeedReserveCopy)
                MakeReserveCopies(files);
        }

        protected virtual FileContainer[] PrepareFiles(IEpsReport[] reports)
        {
            var res = new List<FileContainer>();
            foreach (var report in reports)
            {
                var reportFileName = GetReportFileName(report);
                var fileContainer = new FileContainer
                {
                    FileName = reportFileName,
                    Data = GetReportData(report, reportFileName),
                    IsArchived = IsNeedZip
                };
                res.Add(fileContainer);
            }
            return res.ToArray();
        }

        protected virtual string GetReportFileName(IEpsReport report)
        {
            var extension = GetReportFileExtension(report);
            return report.ReportResultFileName + "." + extension;
        }

        private string GetReportFileExtension(IEpsReport report)
        {
            // если определили явно - доклеиваем
            var fileExtensionParameter = GetNotRequiredParameterValue<string>(EpsTaskParameterTypes.FileExtension, null);
            if (fileExtensionParameter != null)
                return fileExtensionParameter;

            // иначе берем из форматера
            var container = report.GetExportContainer(ExportType);
            if (container == null)
                throw new Exception(string.Format("Can't find export container for export type {0}.", ExportType.GetKey()));

            return container.DefaultExtension;
        }

        protected virtual byte[] GetReportData(IEpsReport report, string fileName)
        {
            var container = report.GetExportContainer(ExportType);
            var data = container.Bytes;
            if (IsNeedZip)
                data = _archiver.Archive(data, fileName);
            return data;
        }

        protected abstract void ProcessFiles(FileContainer[] files);

        protected virtual void MakeReserveCopies(FileContainer[] files)
        {
            foreach (var file in files)
            {
                var fileName = Path.Combine(_epsConfiguration.ArchPath, _config.TaskId + "_" + file.FileName);
                if (!File.Exists(fileName))
                    File.WriteAllBytes(fileName, file.Data);
            }
        }

        protected T GetRequiredParameterValue<T>(string code, string subValue = null)
        {
            var parameter = _config.Parameters.FirstOrDefault(i => i.Code == code && (subValue == null || string.Equals(i.Subvalue, subValue)));
            if (parameter == null || parameter.Value == null)
                throw new Exception(string.Format("Required parameter '{0}' is not defined.", code));

            return ConvertValue<T>(parameter.Value);
        }

        protected T GetNotRequiredParameterValue<T>(string code, string subValue = null, T defaultValue = default(T))
        {
            var parameter = _config.Parameters.FirstOrDefault(i => i.Code == code && (subValue == null || string.Equals(i.Subvalue, subValue)));
            if (parameter == null || parameter.Value == null)
                return defaultValue;

            return ConvertValue<T>(parameter.Value);
        }

        private T ConvertValue<T>(object value)
        {
            var sourceType = value.GetType();
            var targetType = typeof (T).GetNonNullableType();
            var targetValue = value;
            if (sourceType == typeof (string))
            {
                var strValue = (string) value;
                if (targetType == typeof (bool))
                    targetValue = (strValue == "1" || strValue.ToLower() == "true");
                else if (targetType == typeof (int))
                    targetValue = int.Parse(strValue);
            }
            return (T) targetValue;
        }

        protected T GetNotRequiredParameterValue<T>(string code, T defaultValue = default(T))
        {
            return GetNotRequiredParameterValue(code, null, defaultValue);
        }
    }
}
