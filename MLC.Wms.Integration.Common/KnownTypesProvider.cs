using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;

namespace MLC.Wms.Integration.Common
{
    public static class KnownTypesProvider
    {
        public const string GetKnownTypesMethodName = "GetKnownTypes";

        private static readonly HashSet<Type> KnownTypes = new HashSet<Type>();

        public static void RegisterKnownTypes(IEnumerable<Type> types)
        {
            foreach (var type in types)
                KnownTypes.Add(type);
        }

        public static Type[] GetKnownTypes(ICustomAttributeProvider provider)
        {
            return KnownTypes.ToArray();
        }

        public static void FillClientProxy<TChannel>(ClientBase<TChannel> client)
            where TChannel : class
        {
            var knownTypes = GetKnownTypes(null);
            foreach (var operation in client.Endpoint.Contract.Operations)
                foreach (var type in knownTypes)
                    operation.KnownTypes.Add(type);
        }
    }
}
