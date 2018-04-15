using System;
using System.Globalization;
using System.Linq;
using System.IO;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using MLC.Eps.Config;

namespace MLC.Eps.Impl
{
    /// <summary>
    /// Задание сервиса EPS.
    /// </summary>
    public class EpsJob : IEpsJob
    {
        #region .  Fields  .
        private readonly IEpsJobConfig _config;
        private readonly IEpsConfiguration _epsConfiguration;
        private readonly IEpsTaskFactory _taskFactory;
        private readonly IEpsReportFactory _reportFactory; 
        #endregion

        #region .  Properties  .

        /// <summary>
        /// Перечень отчетов, которые экспортируются данным Job-ом
        /// </summary>
        public IEpsReport[] Reports { get; private set; }

        /// <summary>
        /// Перечень задач, которые выполняет данный Job
        /// </summary>
        public IEpsTask[] Tasks { get; private set; }

        #endregion

        public EpsJob(IEpsJobConfig config,
            IEpsConfiguration epsConfiguration,
            IEpsTaskFactory taskFactory,
            IEpsReportFactory reportFactory)
        {
            Contract.Requires(config != null);
            Contract.Requires(epsConfiguration != null);
            Contract.Requires(taskFactory != null);
            Contract.Requires(reportFactory != null);

            _config = config;
            _epsConfiguration = epsConfiguration;
            _taskFactory = taskFactory;
            _reportFactory = reportFactory;

            // проверяем
            var tasks = config.Tasks;
            if (tasks.Length == 0)
                throw new Exception(string.Format("Can't find any task for job {0}.", _config.JobId));

            var unsupportedTypes = tasks.Where(i =>
                    i.TaskExecutorType == EpsTaskExecutorTypes.None ||
                    i.TaskExecutorType == EpsTaskExecutorTypes.ARCH ||
                    i.TaskExecutorType == EpsTaskExecutorTypes.DCL ||
                    i.TaskExecutorType == EpsTaskExecutorTypes.WF)
                    .Select(i => i.TaskExecutorType)
                    .Distinct()
                    .ToArray();

            if (unsupportedTypes.Length > 0)
                throw new Exception(string.Format("Job {0} contains unsupported task types {1}.", _config.JobId, string.Join(";", unsupportedTypes)));

            //TODO: разобаться зачем была нужна сортировка TASK-ов по TaskOrder (где это использовалось)
            Tasks = tasks.Select(i => _taskFactory.CreateTask(i)).ToArray();
            Reports = _config.Reports.Select(i => _reportFactory.CreateReport(i)).ToArray();

            CheckWorkingFolder(_config.JobId);

            var exportTypes = Tasks.Where(i => i.ExportType != null).Select(i => i.ExportType).Distinct();

            // отмечаем форматы, в которые выгружаем
            foreach (var exportType in exportTypes)
                foreach (var report in Reports)
                    report.AddExportType(exportType);
        }

        #region .  Methods  .

        public void Execute()
        {
            foreach (var p in Reports)
            {
                p.Prepare();
                p.Export();
            }

            foreach (var taskGroup in Tasks.GroupBy(x => x.TaskOrder).OrderBy(g => g.Key))
            {
                // если в группе одно задание - запускаем в текущем потоке
                if (taskGroup.Count() == 1)
                {
                    ExecuteTask(taskGroup.First(), Reports);
                }
                else
                {
                    // иначе все параллельно
                    var tasks = taskGroup.Select(i => Task.Factory.StartNew(() => ExecuteTask(i, Reports))).ToArray();
                    Task.WaitAll(tasks);
                }
            }
        }

        private static void ExecuteTask(IEpsTask task, IEpsReport[] reports)
        {
            task.Execute(reports);
        }

        private void CheckWorkingFolder(int jobId)
        {
            var isNeedReserveCopy = Tasks.Any(i => i.IsNeedReserveCopy);
            if (!isNeedReserveCopy)
                return;

            var currentDate = DateTime.Now;
            var jobFolder = Path.Combine(_epsConfiguration.ArchPath,
                currentDate.Year.ToString(CultureInfo.InvariantCulture),
                currentDate.Month.ToString(CultureInfo.InvariantCulture),
                currentDate.Day.ToString(CultureInfo.InvariantCulture),
                jobId.ToString());

            if (!Directory.Exists(jobFolder))
                Directory.CreateDirectory(jobFolder);
        }

        public void Dispose()
        {
            if (Tasks != null)
            {
                //foreach (var task in Tasks)
                //    task.Dispose();
                Tasks = null;
            }

            if (Reports != null)
            {
                foreach (var report in Reports)
                    report.Dispose();
                Reports = null;
            }
        }

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(Reports != null);
            Contract.Invariant(Tasks != null);
        }

        #endregion
    }
}