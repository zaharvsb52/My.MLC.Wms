using System;
using System.Collections.Generic;
using System.Xml.Linq;
using WebClient.Common.Metamodel.Impl.Dynamic.MappingEntities;
using WebClient.Common.Utils;
using WebClient.Nh.Mapping;

namespace MLC.Wms.Bootstrap
{
    public class WmsMappingBuilder : StaticMappingBuilder
    {
        protected override XElement BuildIdGenerator(Primitive id)
        {
            var idDataType = id.DataType.GetNonNullableType();
            var generator =
                idDataType == typeof (Guid)
                    ? "guid.comb"
                    : idDataType == typeof (Int32)
                        ? "trigger-identity"
                        : "assigned";
            return new XElement(DefaultNamespace + "generator", new XAttribute("class", generator));
        }

        protected override string GetPrimitiveMappingType(Primitive primitive)
        {
            if (primitive.DateTimePrecision == DateTimePrecision.Milliseconds)
                return "Timestamp";

            return base.GetPrimitiveMappingType(primitive);
        }

        protected override IEnumerable<XElement> BuildEntities(IEnumerable<Entity> entities)
        {
            var entityElements = base.BuildEntities(entities);
            var res = new List<XElement>(entityElements);
            var namedQueries = GetNamedQueries();
            if (namedQueries.Length > 0)
                res.AddRange(BuildNamedQueries(namedQueries));
            return res;
        }

        protected virtual IEnumerable<XElement> BuildNamedQueries(IEnumerable<SysNamedQuery> queries)
        {
            if (queries == null)
                yield break;

            foreach (var query in queries)
            {
                yield return BuildNamedQuery(query);
            }
        }

        protected virtual XElement BuildNamedQuery(SysNamedQuery query)
        {
            return new XElement(DefaultNamespace + "sql-query",
                new XAttribute("name", query.Name),
                BuildNamedQueryReturns(query),
                BuildNamedQueryParameters(query),
                new XText(query.Query));
        }

        protected virtual IEnumerable<XElement> BuildNamedQueryParameters(SysNamedQuery query)
        {
            if (query.Parameters == null)
                yield break;

            foreach (var parameter in query.Parameters)
                yield return BuildNamedQueryParameter(parameter);
        }

        protected virtual XElement BuildNamedQueryParameter(SysNamedQueryParameter parameter)
        {
            return new XElement(DefaultNamespace + "query-param",
                new XAttribute("name", parameter.Name),
                new XAttribute("type", parameter.Type));
        }

        protected virtual IEnumerable<XElement> BuildNamedQueryReturns(SysNamedQuery query)
        {
            if (query.ReturnParameters == null)
                yield break;

            foreach (var returnParameter in query.ReturnParameters)
            {
                var scalar = returnParameter as SysNamedQueryReturnScalar;
                if (scalar != null)
                {
                    yield return BuildScalarReturnParameter(scalar);
                    continue;
                }

                var join = returnParameter as SysNamedQueryReturnJoin;
                if (join != null)
                {
                    yield return BuildJoinReturnParameter(join);
                    continue;
                }

                var res = returnParameter as SysNamedQueryReturn;
                if (res != null)
                {
                    yield return BuildReturnParameter(res);
                    continue;
                }

                throw new NotSupportedException(string.Format("Return parameter with type '{0}' is not supported.",
                    returnParameter));
            }
        }

        protected virtual XElement BuildReturnParameter(SysNamedQueryReturn res)
        {
            throw new NotImplementedException();
        }

        protected virtual XElement BuildJoinReturnParameter(SysNamedQueryReturnJoin joinParameter)
        {
            throw new NotImplementedException();
        }

        protected virtual XElement BuildScalarReturnParameter(SysNamedQueryReturnScalar scalarParameter)
        {
            return new XElement(DefaultNamespace + "return-scalar",
                new XAttribute("column", scalarParameter.Column),
                new XAttribute("type", scalarParameter.Type));
        }

        private SysNamedQuery[] GetNamedQueries()
        {
            return new[]
            {
                new SysNamedQuery
                {
                    Name = "getAvailablePickListCount",
                    Query = "select pkgBPPick.getPickListCount(:pTruckCode) as res from dual",
                    ReturnParameters = new List<IReturnParameter>()
                    {
                        new SysNamedQueryReturnScalar
                        {
                            Column = "res",
                            Type = "System.Int32"
                        }
                    },
                    Parameters = new List<SysNamedQueryParameter>()
                    {
                        new SysNamedQueryParameter()
                        {
                            Name = "pTruckCode",
                            Type = "System.String"
                        }
                    }
                },
                new SysNamedQuery
                {
                    Name = "getAvailableTransportTaskCount",
                    Query =
                        "select TTASKTYPECODE_R as TransportTypeCode, count(1) Cnt from vwTTask2Reserv group by TTASKTYPECODE_R"
                },
                new SysNamedQuery
                {
                    Name = "bpProductAutoCancellation",
                    Query = "call pkgBPProduct.bpProductAutoCancellation(:pMandantCode, :pAdjustmentReasonCode)",
                    Parameters = new List<SysNamedQueryParameter>()
                    {
                        new SysNamedQueryParameter()
                        {
                            Name = "pMandantCode",
                            Type = "System.String"
                        },
                        new SysNamedQueryParameter()
                        {
                            Name = "pAdjustmentReasonCode",
                            Type = "System.String"
                        }
                    }
                }
            };
        }
    }

    public class SysNamedQuery
    {
        public SysNamedQuery()
        {
            Parameters = new List<SysNamedQueryParameter>();
            ReturnParameters = new List<IReturnParameter>();
        }

        public Guid Id { get; set; }

        /// <summary>
        /// Map to 'name' attribute
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Map to 'resultset-ref' attribute
        /// </summary>
        public string ResultsetRef { get; set; }

        /// <summary>
        /// Map to 'flush-mode' attribute
        /// Valid values: auto, never, always
        /// </summary>
        public string FlushMode { get; set; }

        /// <summary>
        /// Map to 'cacheable' attribute
        /// </summary>
        public bool Cacheable { get; set; }

        /// <summary>
        /// Map to 'cache-region' attribute
        /// </summary>
        public string CacheRegion { get; set; }

        /// <summary>
        /// Map to 'fetch-size' attribute
        /// </summary>
        public int FetchSize { get; set; }

        /// <summary>
        /// Map to 'timeout' attribute
        /// </summary>
        public uint Timeout { get; set; }

        /// <summary>
        /// Map to 'cache-mode' attribute
        /// Valid values: get, ignore, normal, put, refresh
        /// </summary>
        public string CacheMode { get; set; }

        /// <summary>
        /// Map to 'read-only' attribute
        /// </summary>
        public bool ReadOnly { get; set; }

        /// <summary>
        /// Map to 'comment' attribute
        /// </summary>
        public string Description { get; set; } // -> comment

        /// <summary>
        /// Map to 'callable' attribute
        /// </summary>
        public bool Callable { get; set; }

        public string Query { get; set; }

        public List<SysNamedQueryParameter> Parameters { get; set; }
        public List<IReturnParameter> ReturnParameters { get; set; }
    }

    public class SysNamedQueryParameter
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }

    public interface IReturnParameter
    {
    }

    public class SysNamedQueryReturnScalar : IReturnParameter
    {
        public string Column { get; set; }
        public string Type { get; set; }
    }

    public class SysNamedQueryReturnJoin : IReturnParameter
    {
        public string Alias { get; set; }
        public string Property { get; set; }

        /// <summary>
        /// Map to 'lock-mode' attribute
        /// Valid values: none, version, dirty, all
        /// </summary>
        public string LockMode { get; set; }

        public List<SysNamedQueryReturnProperty> Properties { get; set; }
    }

    public class SysNamedQueryReturn : IReturnParameter
    {
        public string Alias { get; set; }

        /// <summary>
        /// Map to 'entity-name' attribute
        /// </summary>
        public string EntityName { get; set; }

        public string Class { get; set; }

        /// <summary>
        /// Map to 'lock-mode' attribute
        /// Valid values: none, version, dirty, all
        /// </summary>
        public string LockMode { get; set; }

        public SysNamedQueryReturnDescriminator Descriminator { get; set; }

        public List<SysNamedQueryReturnProperty> Properties { get; set; }
    }

    public class SysNamedQueryReturnDescriminator
    {
        public string Column { get; set; }
    }

    public class SysNamedQueryReturnProperty
    {
        public string Name { get; set; }
        public string Column { get; set; }
        public List<SysNamedQueryReturnColumn> Columns { get; set; }
    }

    public class SysNamedQueryReturnColumn
    {
        public string Name { get; set; }
    }
}