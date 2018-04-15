using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace MLC.Wms.Api
{
    public partial class WmsAPI
    {
        public int ProductAutoCancellation(string mandant, string reason, int? timeout)
        {
            using (var session = SessionFactory.OpenSession())
            {
                var query = session.GetNamedQuery("bpProductAutoCancellation");
                if (timeout.HasValue)
                    query.SetTimeout(timeout.Value);

                var res = query
                    .SetAnsiString("pMandantCode", mandant)
                    .SetAnsiString("pAdjustmentReasonCode", reason)
                    .ExecuteUpdate();
                return res;
            }
        }
        
        /// <summary>
        /// API "Перемещение"
        /// <exception cref="ApiException">
        /// Возникшая ошибока в DB API будет обернута в ApiException
        /// </exception>
        /// </summary>
        /// <param name="teCode"></param>
        /// <param name="destPlaceCode"></param>
        /// <param name="strategy"></param>
        /// <param name="destTECode"></param>
        /// <param name="transportTaskID">ID Созданного ЗНТ</param>
        /// /// <param name="productID"></param>
        /// <returns>ID ЗНТ</returns>
        public decimal MoveManyTE2Place(string teCode, string destPlaceCode, string strategy, string destTECode, decimal? productID, int isManual)
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                using (var cmd = (OracleCommand)session.Connection.CreateCommand())
                {
                    cmd.CommandText = "pkgAppTest.bpTestMove";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var pTECode = cmd.Parameters.Add("pTECode", OracleDbType.Varchar2, teCode, ParameterDirection.Input);
                    var pDestPlaceCode = cmd.Parameters.Add("pDestPlaceCode", OracleDbType.Varchar2, destPlaceCode, ParameterDirection.Input);
                    var pStrategy = cmd.Parameters.Add("pStrategy", OracleDbType.Varchar2, strategy, ParameterDirection.Input);
                    var pDestTECode = cmd.Parameters.Add("pDestTECode", OracleDbType.Varchar2, destTECode, ParameterDirection.Input);
                    var pTransportTaskID = cmd.Parameters.Add("pTransportTaskID", OracleDbType.Decimal, ParameterDirection.Output);
                    pTransportTaskID.DbType = DbType.Decimal;
                    var pProductID = cmd.Parameters.Add("pProductID", OracleDbType.Decimal, productID, ParameterDirection.Input);
                    var pIsManual = cmd.Parameters.Add("pIsManual", OracleDbType.Int32, isManual, ParameterDirection.Input);

                    cmd.ExecuteNonQuery();

                    return (decimal) pTransportTaskID.Value;
                }
            }
            catch (DbException ex)
            {
                // TODO: вычленять сообщение ORA
                throw;
            }
            catch (Exception ex)
            {
                throw new ApiException(string.Format("Неизвестная ошибка при перемещении {0}. ", ex.Message), ex);
            }
        }

        /// <summary>
        /// API "Перемещение"
        /// <exception cref="ApiException">
        /// Возникшая ошибока в DB API будет обернута в ApiException
        /// </exception>
        /// </summary>
        /// <param name="strategy"></param>
        /// <param name="sourceTECode"></param>
        /// <returns>Коллекция кодов мест</returns>
        public List<string> GetPlaceLstByStrategy(string strategy, string sourceTECode, int sizeResultList)
        {
            try
            {
                using (var session = SessionFactory.OpenSession())
                using (var cmd = (OracleCommand)session.Connection.CreateCommand())
                {
                    cmd.CommandText = "pkgAppTest.bpTestGetPlaceStrategy";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("pStrategy", OracleDbType.Varchar2, strategy, ParameterDirection.Input);
                    cmd.Parameters.Add("pSourceTECode", OracleDbType.Varchar2, sourceTECode, ParameterDirection.Input);
                    var pPlaceCodeList = cmd.Parameters.Add("pPlaceCodeList", OracleDbType.Varchar2, ParameterDirection.Output);
                    pPlaceCodeList.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    pPlaceCodeList.Size = sizeResultList;
                    pPlaceCodeList.ArrayBindSize = Enumerable.Repeat(255, sizeResultList).ToArray();

                    cmd.ExecuteNonQuery();

                    if (pPlaceCodeList.Value == null || pPlaceCodeList.Value == DBNull.Value)
                        return null;
                    
                    return ((OracleString[])pPlaceCodeList.Value).Select(i => i.ToString()).ToList();
                }
            }
            catch (DbException ex)
            {
                // TODO: вычленять сообщение ORA
                throw;
            }
            catch (Exception ex)
            {
                throw new ApiException(string.Format("Неизвестная ошибка при перемещении {0}. ", ex.Message), ex);
            }
        }
    }
}
