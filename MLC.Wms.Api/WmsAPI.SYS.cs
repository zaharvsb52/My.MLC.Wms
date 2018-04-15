using System;
using System.Activities;
using System.Data;
using System.Linq;
using MLC.Wms.Model.Entities;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace MLC.Wms.Api
{
    public partial class WmsAPI
    {
        /// <summary>
        /// Получение параметров подключения DCL к SDCL
        /// </summary>
        /// <param name="clientCode">Код клиента (имя машины)</param>
        /// <param name="prevServiceCode">Код предыдущего SDCL. Если подключаемся впервые - пусто</param>
        /// <param name="timeout">Timeout операции подключения</param>
        /// <returns>
        /// Анонимный объект вида new { Endpoint, Code };
        /// </returns>
        public object GetSdclEndPoint(string clientCode, string prevServiceCode, int? timeout)
        {
            using (var session = SessionFactory.OpenSession())
            {
                using (var command = (OracleCommand)session.Connection.CreateCommand())
                {
                    command.CommandText = "pkgBpProcess.bpgetSDCLEndPoint";
                    command.CommandType = CommandType.StoredProcedure;
                    if (timeout.HasValue)
                        command.CommandTimeout = timeout.Value;

                    var res = command.Parameters.Add("res", OracleDbType.Varchar2, ParameterDirection.ReturnValue);
                    res.Size = 4000;

                    var pClientCode = command.Parameters.Add("pClientCode", OracleDbType.Varchar2, ParameterDirection.Input);
                    pClientCode.Value = clientCode;

                    var pPrevServiceCode = command.Parameters.Add("pPrevServiceCode", OracleDbType.Varchar2, ParameterDirection.InputOutput);
                    pPrevServiceCode.Size = 4000;
                    pPrevServiceCode.Value = string.IsNullOrEmpty(prevServiceCode)
                        ? DBNull.Value
                        : (object) prevServiceCode;

                    command.ExecuteNonQuery();

                    Func<object, string> getValueHanler =
                        outparvalue =>
                            (outparvalue == null || outparvalue == DBNull.Value) ? null : outparvalue.ToString();

                    return new
                    {
                        Endpoint = getValueHanler(res.Value),
                        Code = getValueHanler(pPrevServiceCode.Value)
                    };
                }
            }
        }

        /// <summary>
        /// Получение маппинга wms и wms.web по наименованию wms сущности.
        /// </summary>
        /// <param name="wmsEntityName">Сущность wms</param>
        /// <returns>Анонимный объект вида new { WebEntity, WebPk }</returns>
        public object GetEntityMappingByWmsEntity(string wmsEntityName)
        {
            var result =
                SysObjectMapping.GetSysObjectEntities().SingleOrDefault(s => s.SysObjectEntityName == wmsEntityName);
            return result == null
                ? null
                : new
                {
                    WebEntity = result.HibernateEntityName,
                    WebPk = result.PrimaryKeyColumnName
                };
        }

        /// <summary>
        /// Получение "тела" Workflow
        /// </summary>
        /// <param name="package"></param>
        /// <param name="name"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        public string GetWorkflow(string package, string name, string version)
        {
            var wfIdentity = new WorkflowIdentity(name, new Version(version), package);
            return Loader.Load(wfIdentity);
        }

        public bool ValidatePlace(string placeCode, string teCode, bool raiseError, bool checkCapacity, int? timeout)
        {
            using (var session = SessionFactory.OpenSession())
            {
                using (var command = (OracleCommand)session.Connection.CreateCommand())
                {
                    command.CommandText = "pkgBP_api.checkPlaceByTECode";
                    command.CommandType = CommandType.StoredProcedure;
                    if (timeout.HasValue)
                        command.CommandTimeout = timeout.Value;

                    var res = command.Parameters.Add("res", OracleDbType.Decimal, ParameterDirection.ReturnValue);

                    var pPlaceCode = command.Parameters.Add("pPlaceCode", OracleDbType.Varchar2, ParameterDirection.Input);
                    pPlaceCode.Value = placeCode;

                    var pTECode = command.Parameters.Add("pTECode", OracleDbType.Varchar2, ParameterDirection.Input);
                    if (!string.IsNullOrEmpty(teCode))
                        pTECode.Value = teCode;

                    var pRaiseError = command.Parameters.Add("pRaiseError", OracleDbType.Int32, ParameterDirection.Input);
                    pRaiseError.Value = raiseError ? 1 : 0;

                    var pCheckCapacity = command.Parameters.Add("pCheckCapacity", OracleDbType.Int32, ParameterDirection.Input);
                    pCheckCapacity.Value = checkCapacity ? 1 : 0;

                    command.ExecuteNonQuery();

                    var result = false;
                    if (res.Value != null && res.Value != DBNull.Value)
                    {
                        var orares = (OracleDecimal) res.Value;
                        if (!orares.IsNull)
                            result = Convert.ToBoolean(orares.Value);
                    }

                    return result;
                }
            }
        }
    }
}