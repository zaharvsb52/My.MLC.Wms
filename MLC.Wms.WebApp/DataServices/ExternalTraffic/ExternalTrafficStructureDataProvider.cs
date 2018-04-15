using System.Linq;
using MLC.Wms.Model.Entities;
using WebClient.Common.Client.Protocol.DataTransferObjects.LoadResult;
using WebClient.Common.Client.Protocol.DataTransferObjects.Metadata;
using WebClient.Common.Data.DataAccess;
using WebClient.Common.DataServices.DataProviders;
using WebClient.Common.DataServices.DataProviders.AutoForms;
using WebClient.Common.Metamodel.Bindings;
using WebClient.Common.Metamodel.Data;
using WebClient.Common.Serialization.Data;
using WebClient.Common.Server.Bindings;
using WebClient.Common.Types;

namespace MLC.Wms.WebApp.DataServices.ExternalTraffic
{
    public class ExternalTrafficStructureDataProvider : AutoStructureDataProvider, ICardDataLoader
    {
        private readonly IEntitiesLoader _entitiesLoader;
        private readonly JsStructureEnricher _jsStructureEnricher;
        private readonly BindingsCreator _bindingsCreator;

        public ExternalTrafficStructureDataProvider(IMetamodel metamodel,
            FieldsByBindingsFactory fieldsByBindingsFactory,
            JsStructureFactory jsStructureFactory,
            IEntitiesLoader entitiesLoader,
            JsStructureEnricher jsStructureEnricher,
            BindingsCreator bindingsCreator)
            : base(metamodel, fieldsByBindingsFactory, jsStructureFactory)
        {
            _entitiesLoader = entitiesLoader;
            _jsStructureEnricher = jsStructureEnricher;
            _bindingsCreator = bindingsCreator;

            SetEntityType(typeof (YExternalTraffic));
        }

        protected override IFieldBinding[] GetBindings()
        {
            return _bindingsCreator.With<YExternalTraffic>()
                .CreateOrReplace(i => i.ExternalTrafficPassNumber)
                .CreateOrReplace(i => i.ExternalTrafficID)
                .CreateOrReplace(i => i.Status)
                .CreateOrReplace(i => i.ExternalTrafficDriver)
                .CreateOrReplace(i => i.ExternalTrafficDriver.WorkerLastName)
                .CreateOrReplace(i => i.ExternalTrafficDriver.WorkerPhoneMobile)
                .CreateOrReplace(i => i.ExternalTrafficDriver.WorkerBirthday)
                .CreateOrReplace(i => i.WorkerPass)
                .CreateOrReplace(i => i.Vehicle)
                .CreateOrReplace(i => i.Vehicle.VehicleRN)
                .CreateOrReplace(i => i.Vehicle.VehicleVIN)
                .CreateOrReplace(i => i.Vehicle.VehicleColor.UserEnumName)
                .CreateOrReplace(i => i.Vehicle.VehicleOwnerLegal.PartnerName)
                .CreateOrReplace(i => i.Vehicle.VehicleType.UserEnumName)
                .CreateOrReplace(i => i.Vehicle.VehicleMaxWeight)
                .CreateOrReplace(i => i.Vehicle.VehicleEmptyWeight)
                .CreateOrReplace(i => i.Vehicle.VehiclePerson.WorkerLastName)
                .CreateOrReplace(i => i.ExternalTrafficPlanArrived)
                .CreateOrReplace(i => i.ExternalTrafficFactArrived)
                .CreateOrReplace(i => i.ExternalTrafficFactDeparted)
                .CreateOrReplace(i => i.ExternalTrafficHostRef)
                .CreateOrReplace(i => i.ExternalTrafficVerified)
                .CreateOrReplace(i => i.Parking)
                .CreateOrReplace(i => i.ExternalTrafficTrailerRN)
                .CreateOrReplace(i => i.ExternalTrafficDesc)
                .CreateOrReplace(i => i.VDriverPass)
                .CreateOrReplace(i => i.VDriverAddress)
                .CreateOrReplace(i => i.ExternalTrafficDriver.WorkerPhoto)
                .CreateOrReplace(i => i.ExternalTrafficForvarder)
                .CreateOrReplace(i => i.ExternalTrafficCarrier)
                .List();
        }

        protected override string GetStructureName()
        {
            return "ExternalTrafficCard";
        }

        protected override string GetTitle()
        {
            return _jsStructureEnricher.GetEntityCardTitleFormat(EntityDescriptor.EntityType);
        }

        protected override JsStructure GetJsStructure()
        {
            var s = base.GetJsStructure();
            _jsStructureEnricher.EnrichCardStructure(s, EntityDescriptor.EntityType, Bindings);

            foreach (var f in s.Fields)
            {
                f.Persist =
                    (new[]
                    {
                        "Vehicle", "ExternalTrafficDriver", "WorkerPass",
                        "Parking", "ExternalTrafficTrailerRN", "ExternalTrafficDesc", "ExternalTrafficVerified",
                        "ExternalTrafficDriver_WorkerPhoneMobile", "ExternalTrafficDriver_WorkerBirthday",
                        "Vehicle_VehicleRN","ExternalTrafficDriver_WorkerPhoto","ExternalTrafficForvarder",
                        "ExternalTrafficCarrier"
                    })
                        .Contains(f.Name);
            }
            return s;
        }

        public JsStoreData LoadCard(EntityId entityId)
        {
            var source = _entitiesLoader.LoadCard(entityId, Bindings);
            return TableSerializer.Serialize(source, 1);
        }
    }
}