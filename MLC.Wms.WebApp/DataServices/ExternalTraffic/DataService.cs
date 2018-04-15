using System.Linq;
using MLC.Wms.Model.Entities;
using NHibernate;
using NHibernate.Linq;
using WebClient.Common.Data.Saving;
using WebClient.Common.DataServices;
using WebClient.Common.ExtDirect;
using WebClient.Common.Serialization.Data;
using WebClient.Common.Serialization.Querying;
using WebClient.Common.Types;

namespace MLC.Wms.WebApp.DataServices.ExternalTraffic
{
    [ExtDirectService]
    public class DataService : MultiStructuredDataService
    {
        private readonly ISessionFactory _factory;

        public DataService(
            ClientQueryDeserializer queryDeserializer,
            IChangeSetApplier changeSetApplier,
            ChangeSetDeserializer changeSetDeserializer,
            IUnitOfWorkFactory unitOfWorkFactory,
            ExternalTrafficStructureDataProvider externalTrafficStructureDataProvider,
            InternalTrafficSubListStructureDataProvider internalTrafficSubListStructureDataProvider,
            ISessionFactory factory
            )
            : base(queryDeserializer, changeSetDeserializer, changeSetApplier, unitOfWorkFactory)
        {
            _factory = factory;
            StructureDataProviders.Add(externalTrafficStructureDataProvider);
            StructureDataProviders.Add(internalTrafficSubListStructureDataProvider);

            CommittableBindingsProvider.Register(externalTrafficStructureDataProvider);
            CommittableBindingsProvider.Register(internalTrafficSubListStructureDataProvider);
        }

        public object GetWorkerExtendedInfo(int driverId)
        {
            using (var session = _factory.OpenSession())
            {
                return session.Query<WmsWorker>()
                        .Where(i => i.WorkerID == driverId)
                        .Select(x => new
                        {
                            ExternalTrafficDriver_WorkerPhoneMobile = x.WorkerPhoneMobile,
                            ExternalTrafficDriver_WorkerBirthday = x.WorkerBirthday,
                            ExternalTrafficDriver_WorkerPhoto = x.WorkerPhoto,
                            ExternalTrafficDriver_IsInBL = x.VIsInBlackList
                        }).FirstOrDefault();
            }
        }

        public object GetLastVehicle(int driverId)
        {
            using (var session = _factory.OpenSession())
            {
                var ret = session.Query<YExternalTraffic>()
                    .Where(i => i.ExternalTrafficDriver.WorkerID == driverId)
                    .OrderByDescending(k => k.ExternalTrafficFactDeparted)
                    .ThenByDescending(k => k.ExternalTrafficID)
                    .Select(x => new EntityReference(x.Vehicle.VehicleID, "YVehicle", new[]
                    {
                        new EntityReferenceFieldValue("VRnMarkModel",x.Vehicle.VRnMarkModel), 
                    } )).FirstOrDefault();

                return ret;
            }
        }

        public object GetLastWorker(int vehicleId)
        {
            using (var session = _factory.OpenSession())
            {
                var ret = session.Query<YExternalTraffic>()
                    .Where(i => i.Vehicle.VehicleID == vehicleId)
                    .OrderByDescending(k => k.ExternalTrafficFactDeparted)
                    .ThenByDescending(k => k.ExternalTrafficID)
                    .Select(x => new EntityReference(x.ExternalTrafficDriver.WorkerID, "WmsWorker", new[]
                    {
                        new EntityReferenceFieldValue("WorkerLastName", x.ExternalTrafficDriver.WorkerLastName),
                        new EntityReferenceFieldValue("WorkerName", x.ExternalTrafficDriver.WorkerName ),
                        new EntityReferenceFieldValue("WorkerMiddleName", x.ExternalTrafficDriver.WorkerMiddleName ),
                        new EntityReferenceFieldValue("WorkerID", x.ExternalTrafficDriver.WorkerID )
                    })).FirstOrDefault();

                return ret;
            }
        }
     
        public object GetVehicleExtendedInfo(int vehicleId)
        {
            using (var session = _factory.OpenSession())
            {
                var ret = session.Query<YVehicle>()
                        .Where(i => i.VehicleID == vehicleId)
                        .Select(x => new
                        {
                            Vehicle_VehicleRN = x.VehicleRN,
                            Vehicle_VehicleVIN = x.VehicleVIN,
                            Vehicle_VehicleColor_UserEnumName = x.VehicleColor.UserEnumName,
                            Vehicle_VehicleOwnerLegal_PartnerName = x.VehicleOwnerLegal.PartnerName,
                            Vehicle_VehicleType_UserEnumName = x.VehicleType.UserEnumName,
                            Vehicle_VehicleMaxWeight = x.VehicleMaxWeight,
                            Vehicle_VehicleEmptyWeight = x.VehicleEmptyWeight,
                            Vehicle_VehiclePerson_WorkerLastName = x.VehiclePerson.WorkerLastName,
                           }).FirstOrDefault();

                return ret;
            }
        }
    }
}