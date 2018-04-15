using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using MLC.Wms.Common;
using MLC.Wms.Model.Entities;
using Newtonsoft.Json.Linq;
using NHibernate;
using NHibernate.Linq;
using WebClient.Common.Data.Saving;
using WebClient.Common.DataServices;
using WebClient.Common.ExtDirect;
using WebClient.Common.Serialization.Data;
using WebClient.Common.Serialization.Querying;
using WebClient.Common.Types;
using WebClient.Nh.Saving;

namespace MLC.Wms.WebApp.DataServices.ExternalTrafficCreate
{
    [ExtDirectService]
    public class DataService : MultiStructuredDataService
    {
        public DataService(
            ClientQueryDeserializer queryDeserializer,
            IChangeSetApplier changeSetApplier,
            ChangeSetDeserializer changeSetDeserializer,
            CustomUnitOfWorkFactory unitOfWorkFactory,
            ExternalTrafficCreateStructureDataProvider externalTrafficCreateStructureDataProvider,
            InternalTrafficCreateStructureDataProvider internalTrafficCreateStructureDataProvider
            )
            : base(queryDeserializer, changeSetDeserializer, changeSetApplier, unitOfWorkFactory)
        {
            StructureDataProviders.Add(externalTrafficCreateStructureDataProvider);
            StructureDataProviders.Add(internalTrafficCreateStructureDataProvider);

            CommittableBindingsProvider.Register(externalTrafficCreateStructureDataProvider);
            CommittableBindingsProvider.Register(internalTrafficCreateStructureDataProvider);
        }

        public override void Commit(JObject jsChangeSet)
        {
            Contract.Requires(!CommittableBindingsProvider.IsEmpty,
                "CommitableBindingsProvider пуст, поэтому ни одна сущность не может быть сохранена. Скорее в конструкторе в него забыли добавить FieldBinding-и на структуры, которые можно сохранять");

            var changeSet = ChangeSetDeserializer.Deserialize(jsChangeSet,
                CommittableBindingsProvider.ComposeDataContextModel(StructureDataProviders));

            using (var uow = UnitOfWorkFactory.StartNew())
            {
                var cuow = (CustomUnitOfWork)uow;

                // применяем
                ChangeSetApplier.Apply(changeSet, CommittableBindingsProvider, uow);

                // запускаем логику обработки
                ProcessSavingLogic(cuow);
                uow.Commit();
            }
        }

        private void ProcessSavingLogic(CustomUnitOfWork uow)
        {
            // проверяем текущего работника
            var strWorkerId = WmsEnvironment.LocalData.GetValueFor<string>("WorkerID");
            if (string.IsNullOrEmpty(strWorkerId))
                throw new LogicException("Не указан текущий работник");

            // получаем рейс
            var newExtTraffics = uow.NewItems.OfType<YExternalTraffic>().ToList();
            if (newExtTraffics.Count == 0)
                throw new LogicException("Ожидалось добавление нового рейса");
            if (newExtTraffics.Count > 1)
                throw new LogicException("Ожидалось добавление только одного нового рейса");
            var newExternalTraffic = newExtTraffics[0];

            // проверяем внешние рейсы
            var newInternalTraffics = uow.NewItems.OfType<YInternalTraffic>().ToArray();
            CheckInternalTraffic(newInternalTraffics);

            // водитель, машина уже должны быть заполнены
            if (newExternalTraffic.ExternalTrafficDriver == null)
                throw new LogicException("Не указан водитель");
            if (newExternalTraffic.Vehicle == null)
                throw new LogicException("Не указан автмобиль");

            // заполняем обязательные поля рейса
            newExternalTraffic.Status =
                uow.Session.Query<YExternalTrafficStatus>().Single(i => i.StatusCode == "CAR_PLAN");
            newExternalTraffic.ExternalTrafficVerified = false;

            // регистрируем, чтобы появилась id
            uow.Session.Save(newExternalTraffic);

            // обрабатываем внутренние рейсы
            foreach (var newInternalTraffic in newInternalTraffics)
                AddInternalTraffic(newExternalTraffic, newInternalTraffic, uow);

            var cpvPassWorkerL1 = new YExternalTrafficCPV()
            {
                CustomParam = uow.Session.Query<WmsCustomParam>().Single(i => i.CustomParamCode == "PassWorkerL1"),
                EXTERNALTRAFFIC = newExternalTraffic
            };
            // регистрируем, чтобы появилась id
            uow.Session.Save(cpvPassWorkerL1);

            var cpvPassWorkerWritePassL2 = new YExternalTrafficCPV()
            {
                CustomParam =
                    uow.Session.Query<WmsCustomParam>().Single(i => i.CustomParamCode == "PassWorkerAcceptEntryL2"),
                EXTERNALTRAFFIC = newExternalTraffic,
                Parent = cpvPassWorkerL1,
                CPVValue = strWorkerId
            };
            uow.RegisterNew(cpvPassWorkerWritePassL2);
        }

        private void CheckInternalTraffic(YInternalTraffic[] newInternalTraffics)
        {
            if (newInternalTraffics.Length == 0)
                throw new LogicException("Цель визита не задана");

            if (newInternalTraffics.Any(i => !i.InternalTrafficOrder.HasValue))
                throw new LogicException("В списке пристуствуют цели без указания очереди");

            var sb = new StringBuilder();
            foreach (var item in newInternalTraffics)
            {
                var fields = new List<string>();

                if (item.Partner == null)
                    fields.Add("Мандант");
                if (item.PurposeVisit == null)
                    fields.Add("Цель");

                if (fields.Count > 0)
                    sb.AppendLine(string.Format("Для цели с очередью '{0}' не указаны обязательные поля: '{1}'.", item.InternalTrafficOrder,
                        string.Join("','", fields)));
            }
            var err = sb.ToString();
            if (!string.IsNullOrEmpty(err))
                throw new LogicException(err);
        }

        private void AddInternalTraffic(YExternalTraffic newExternalTraffic, YInternalTraffic newInternalTraffic,
            CustomUnitOfWork uow)
        {
            newInternalTraffic.ExternalTraffic = newExternalTraffic;
            newInternalTraffic.Status =
                uow.Session.Query<YInternalTrafficStatus>().Single(i => i.StatusCode == "VISITOR_PLAN");

            // есть разгрузка - создаем груз на приход
            if (newInternalTraffic.PurposeVisit.PurposeVisitCode.ToUpper() == "UNLOADING")
            {
                var cargoIwb = new WmsCargoIWB
                {
                    InternalTraffic = newInternalTraffic,
                    CargoIWBStampState = "NORMAL"
                };
                uow.RegisterNew(cargoIwb);
            }

            // есть погрузка - создаем груз на расход
            if (newInternalTraffic.PurposeVisit.PurposeVisitCode.ToUpper() == "LOADING")
            {
                var cargoOwb = new WmsCargoOWB
                {
                    InternalTraffic = newInternalTraffic
                };
                uow.RegisterNew(cargoOwb);
            }
        }
    }

    public class CustomUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IUnitOfWorkFactory _innerfactory;

        public CustomUnitOfWorkFactory(IUnitOfWorkFactory factory)
        {
            Contract.Requires(factory != null);

            _innerfactory = factory;
        }

        public IUnitOfWork StartNew()
        {
            return new CustomUnitOfWork(_innerfactory.StartNew());
        }
    }

    public class CustomUnitOfWork : IUnitOfWork
    {
        private readonly IUnitOfWork _innerUnitOfWork;

        public List<object> NewItems { get; private set; }
        public List<object> DirtyItems { get; private set; }
        public List<object> DeletedItems { get; private set; }

        public CustomUnitOfWork(IUnitOfWork innerUnitOfWork)
        {
            Contract.Requires(innerUnitOfWork != null);

            _innerUnitOfWork = innerUnitOfWork;

            NewItems = new List<object>();
            DirtyItems = new List<object>();
            DeletedItems = new List<object>();
        }

        public ISession Session
        {
            get { return ((NhUnitOfWork)_innerUnitOfWork).Session; }
        }

        public object FindById(EntityId id)
        {
            return _innerUnitOfWork.FindById(id);
        }

        public void RegisterNew(object entity)
        {
            //_innerUnitOfWork.RegisterNew(entity);
            NewItems.Add(entity);
        }

        public void RegisterDirty(object entity)
        {
            //_innerUnitOfWork.RegisterDirty(entity);
            DirtyItems.Add(entity);
        }

        public void RegisterDeleted(object entity)
        {
            //_innerUnitOfWork.RegisterDeleted(entity);
            DeletedItems.Add(entity);
        }

        public void Commit()
        {
            foreach (var item in NewItems)
                if (!Session.Contains(item))
                    _innerUnitOfWork.RegisterNew(item);

            foreach (var item in DirtyItems)
                _innerUnitOfWork.RegisterDirty(item);

            foreach (var item in DeletedItems)
                _innerUnitOfWork.RegisterDeleted(item);

            _innerUnitOfWork.Commit();
            ClearChanges();
        }

        public void Dispose()
        {
            ClearChanges();
            _innerUnitOfWork.Dispose();
        }

        private void ClearChanges()
        {
            NewItems.Clear();
            DirtyItems.Clear();
            DeletedItems.Clear();
        }
    }

    public class LogicException : Exception
    {
        public const string DefaultTitle = "Ошибка";

        public string Title { get; set; }

        #region .  ctors  .
        public LogicException()
        {
        }

        public LogicException(string message)
            : base(message)
        {
        }

        public LogicException(string message, string title)
            : base(message)
        {
            Title = title;
        }

        protected LogicException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public LogicException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public LogicException(string message, string title, Exception innerException)
            : base(message, innerException)
        {
            Title = title;
        } 
        #endregion

        public override string ToString()
        {
            return string.IsNullOrEmpty(Title) ? DefaultTitle : Title;
        }
    }
}