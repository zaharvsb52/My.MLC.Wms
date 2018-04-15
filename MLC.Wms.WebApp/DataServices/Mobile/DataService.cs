using System;
using System.Linq;
using MLC.Wms.Api;
using MLC.Wms.Common.Helpers;
using MLC.Wms.Model.Entities;
using NHibernate;
using NHibernate.Linq;
using WebClient.Common.ExtDirect;

namespace MLC.Wms.WebApp.DataServices.Mobile
{
    [ExtDirectService]
    public class DataService
    {
        private readonly ISessionFactory _sessionFactory;

        public DataService(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public bool IsPinValid(string pin)
        {
            try
            {
                using (var session = _sessionFactory.OpenSession())
                    return GetWorkerByPin(pin, session) != null;
            }
            catch
            {
                return false;
            }
        }

        public void CarDeparture(string passNumber, string pin)
        {
            if (string.IsNullOrEmpty(passNumber))
                throw new ArgumentNullException("passNumber");

            if (string.IsNullOrEmpty(passNumber))
                throw new ArgumentNullException("pin");

            using (var session = _sessionFactory.OpenSession())
            {
                var extTrafficList = session.Query<YExternalTraffic>()
                    .Where(i => i.ExternalTrafficPassNumber == passNumber)
                    .ToList();

                if (extTrafficList.Count > 1)
                    throw new LogicalException(
                        $"По пропуску с номером '{passNumber}' найдено более одного рейса. Обратитесь в бюро пропусков.");
                if (extTrafficList.Count == 0)
                    throw new LogicalException($"Пропуск с номером '{passNumber}' не найден. Проверьте введенный номер.");

                var targetTraffic = extTrafficList[0];
                if (targetTraffic.Status.StatusCode != YExternalTrafficStatuses.CAR_ARRIVED &&
                    targetTraffic.Status.StatusCode != YExternalTrafficStatuses.CAR_TRANSITTERRITORY)
                    throw new LogicalException(
                        $"По пропуску с номером '{passNumber}' транспронтое средство в состоянии '{targetTraffic.Status.StatusName}'. Обратитесь в бюро пропусков");

                var notCompleteInternalTraffics = targetTraffic.ExternalTraffic_YInternalTraffic_List
                    .Where(i => new[] { "Unloading", "Loading" }.Contains(i.PurposeVisit.PurposeVisitCode) &&
                                i.InternalTrafficFactDeparted == null)
                    .ToList();

                if (notCompleteInternalTraffics.Any())
                    throw new LogicalException(
                        string.Format(
                            "По пропуску с номером '{1}' водитель не отметился в ОДО об убытии.{0}{2}{0}Обратитесь в бюро пропусков."
                            , Environment.NewLine, passNumber,
                            string.Join(Environment.NewLine,
                                notCompleteInternalTraffics.Select(
                                    i => $"{i.Partner.PartnerName}: {i.PurposeVisit.PurposeVisitName}"))));

                if (targetTraffic.ExternalTraffic_YInternalTraffic_List.Any(x => x.Partner.PartnerCode == "DTL"))
                {
                    var driver = targetTraffic.ExternalTrafficDriver;
                    //session.Get<WmsWorker>(targetTraffic.ExternalTrafficDriver.WorkerID);
                    var isShowSecurity = driver.CPV_List == null ||
                                         //worker.CPV_List.All(i => i.CustomParam.CustomParamCode != "IsDriverSecurityChecked") ||
                                         driver.CPV_List.Any(
                                             i =>
                                                 i.CustomParam.CustomParamCode == "IsDriverSecurityChecked" &&
                                                 i.CPVValue == "0");
                    if (isShowSecurity)
                        throw new LogicalException("Требуется проверить водителя в службе безопасности!");
                }

                var worker = GetWorkerByPin(pin, session);
                targetTraffic.ExternalTrafficFactDeparted = DateTime.Now;
                targetTraffic.Status =
                    session.Query<YExternalTrafficStatus>().Single(i => i.StatusCode == YExternalTrafficStatuses.CAR_DEPARTED);

                // пишем CPV
                var cpvParent = session.Query<YExternalTrafficCPV>()
                    .FirstOrDefault(i => i.CustomParam.CustomParamCode.Equals("PassWorkerL1") && i.EXTERNALTRAFFIC == targetTraffic);
                if (cpvParent == null)
                {
                    cpvParent = new YExternalTrafficCPV()
                    {
                        CustomParam =
                            session.Query<WmsCustomParam>().Single(i => i.CustomParamCode.Equals("PassWorkerL1")),
                        EXTERNALTRAFFIC = targetTraffic
                    };
                    session.Save(cpvParent);
                }
                var cpvCustom = new YExternalTrafficCPV()
                {
                    CustomParam =
                        session.Query<WmsCustomParam>().Single(i => i.CustomParamCode.Equals("PassWorkerClosePass")),
                    EXTERNALTRAFFIC = targetTraffic,
                    CPVValue = worker.WorkerID.ToString(),
                    Parent = cpvParent
                };
                session.Save(cpvCustom);

                // обновим заявки
                var notCompletedRequests = session.Query<YPassRequest>().Where(i => i.PassNumber == passNumber).ToList();
                foreach (var item in notCompletedRequests)
                    item.State = PassRequestStates.PASSREQUEST_DEPARTED;

                using (var transaction = session.BeginTransaction())
                    transaction.Commit();
            }
        }

        private WmsWorker GetWorkerByPin(string pin, ISession session)
        {
            var criptedPin = HashHelper.Sha512(pin);
            var workerList = session.Query<WmsWorker>().Where(i => i.WorkerPIN == criptedPin).ToList();

            if (workerList.Count > 1)
                throw new LogicalException("Не удалось однозначно определить сотрудника. Необходимо обратиться в службу поддержки.");
            if (workerList.Count == 0)
                throw new LogicalException("PIN в системе не зарегистрирован.");

            return workerList[0];
        }
    }
}