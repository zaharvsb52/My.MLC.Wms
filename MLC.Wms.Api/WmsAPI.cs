using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using MLC.WF.Core.Common;
using NHibernate;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace MLC.Wms.Api
{
    public partial class WmsAPI
    {
        public WmsAPI(ISessionFactory sessionFactory,
            IWmsXmlConverter converter,
            IWorkflowLoader loader)
        {
            Contract.Requires(sessionFactory != null);
            Contract.Requires(converter != null);
            Contract.Requires(loader != null);

            SessionFactory = sessionFactory;
            Converter = converter;
            Loader = loader;
        }

        protected ISessionFactory SessionFactory { get; private set; }
        protected IWmsXmlConverter Converter { get; private set; }
        protected IWorkflowLoader Loader { get; private set; }

        public string Echo(string sourceMessage)
        {
            return sourceMessage;
        }

        /// <summary>
        /// API APP 'Заявка на декларирование'.
        /// </summary>
        public int Application4Declaration(IEnumerable<decimal> iwbidList)
        {
            if (iwbidList == null || !iwbidList.Any())
                throw new ArgumentNullException(nameof(iwbidList));

            using (var session = SessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            using (var cmd = (OracleCommand)session.Connection.CreateCommand())
            {
                cmd.CommandText = "pkgBpInput.bpApplication4Declaration";
                cmd.CommandType = CommandType.StoredProcedure;

                var intType = OracleDbType.Int32;

                var pIWBLst = cmd.Parameters.Add("pIWBLst", intType);
                pIWBLst.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                pIWBLst.Size = iwbidList.Count();
                //pIWBLst.Value = iwbidList.Select(i => decimal.ToInt32(i)).ToArray();
                pIWBLst.Value = iwbidList.ToArray();

                var pSum = cmd.Parameters.Add("pIWBGroup", intType);
                pSum.Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                var iwbGroup = cmd.Parameters[1].Value;

                if (!(iwbGroup is OracleDecimal))
                    throw new Exception("Error bpApplication4Declaration");

                var oraDecimal = (OracleDecimal)iwbGroup;

                transaction.Commit();
                return ((int)oraDecimal.Value);
            }
        }
    }

    /// <summary>
    /// Список именовыных запросов, доступных для вызова
    /// </summary>
    public static class NamedQueries
    {
        //public const string ChangeOwbRoute = "ChangeOwbRoute";
    }
}