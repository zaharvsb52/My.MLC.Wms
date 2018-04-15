using System;
using System.Data;
using System.Linq;
using Microsoft.Practices.Unity;
using MLC.Wms.Bootstrap;
using MLC.Wms.Common;
using MLC.Wms.Common.Environment;
using MLC.Wms.Common.Environment.Impl;
using MLC.Wms.Common.LocalStorage;
using NHibernate;
using NUnit.Framework;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace MLC.Wms.Api.Tests
{
    [TestFixture]
    public class WmsAppTest
    {
        [Test]
        public void AppTest()
        {
            UnityConfig.RegisterComponents(container =>
            {
                var factory = container.Resolve<ISessionFactory>();

                container.RegisterType<IWmsEnvironmentInfoProvider, SvcWmsEnvironmentInfoProvider>(
                    new ContainerControlledLifetimeManager());
                container.RegisterType<ILocalData, ThreadStaticLocalData>(new ContainerControlledLifetimeManager());
                WmsEnvironment.Init(container.Resolve<IWmsEnvironmentInfoProvider>(), container.Resolve<ILocalData>());

                using (var session = factory.OpenSession())
                {
                    var intType = OracleDbType.Int32;
                    var stringType = OracleDbType.Varchar2;
                    var dateType = OracleDbType.Date;
                    var dataInt = new int[] { 1, 2, 3 };
                    var dataString = new string[] { "test1", "test2", "test3" };
                    var dataDate = new DateTime[] { DateTime.Now, DateTime.Now.AddDays(1), DateTime.Now.AddDays(2) };

                    #region . OutParam . 

                    var cmd = (OracleCommand)session.Connection.CreateCommand();
                    cmd.CommandText = "pkgAppTest.bpTestOutParam";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var pCount = cmd.Parameters.Add("pCount", intType);
                    pCount.Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    var valueOut = cmd.Parameters[0].Value;

                    if (!(valueOut is OracleDecimal))
                        throw new Exception("Error bpTestOutParam");

                    var oraDecimal = (OracleDecimal)valueOut;
                    ((int)oraDecimal.Value).CompareTo(100);

                    #endregion

                    #region . IntArray . 

                    cmd = (OracleCommand)session.Connection.CreateCommand();
                    cmd.CommandText = "pkgAppTest.bpTestArrayIntParam";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var pArray = cmd.Parameters.Add("pArray", intType);
                    pArray.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    pArray.Size = dataInt.Length;
                    pArray.Value = dataInt;
                    var pSum = cmd.Parameters.Add("pSum", intType);
                    pSum.Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    var valueSum = cmd.Parameters[1].Value;

                    if (!(valueSum is OracleDecimal))
                        throw new Exception("Error bpTestArrayIntParam");

                    oraDecimal = (OracleDecimal)valueSum;
                    ((int)oraDecimal.Value).CompareTo(dataInt.Sum());

                    #endregion

                    #region . Array Other Type . 

                    cmd = (OracleCommand)session.Connection.CreateCommand();
                    cmd.CommandText = "pkgAppTest.bpTestArrayParam";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var pInt = cmd.Parameters.Add("pInt", intType);
                    pInt.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    pInt.Size = dataInt.Count();
                    pInt.Value = dataInt;

                    var pString = cmd.Parameters.Add("pString", stringType);
                    pString.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    pString.Size = dataString.Count();
                    pString.Value = dataString;

                    var pDate = cmd.Parameters.Add("pDate", dateType);
                    pDate.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
                    pDate.Size = dataString.Count();
                    pDate.Value = dataDate;

                    var pCountParam = cmd.Parameters.Add("pCountParam", intType);
                    pCountParam.Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    var valueCount = cmd.Parameters[3].Value;

                    if (!(valueCount is OracleDecimal))
                        throw new Exception("Error bpTestArrayParam");

                    oraDecimal = (OracleDecimal)valueCount;
                    ((int)oraDecimal.Value).CompareTo(dataInt.Count() + dataString.Count() + dataDate.Count());

                    #endregion
                }
            });
        }
    }
}