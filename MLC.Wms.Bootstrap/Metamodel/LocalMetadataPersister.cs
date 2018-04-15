using System.Data;
using System.Diagnostics.Contracts;
using System.IO;
using System.Xml.Serialization;
using Oracle.ManagedDataAccess.Client;

namespace MLC.Wms.Bootstrap.Metamodel
{
    public class LocalMetadataPersister
    {
        public virtual DataSet Load(string fileName)
        {
            Contract.Requires(fileName != null);
            Contract.Ensures(Contract.Result<DataSet>() != null);

            var ser = new XmlSerializer(typeof(DataSet));
            using (TextReader reader = new StreamReader(fileName))
                return (DataSet)ser.Deserialize(reader);
        }

        public virtual void Save(string fileName, string connectionString)
        {
            Contract.Requires(fileName != null);
            Contract.Requires(connectionString != null);

            var dataSet = new DataSet();

            new OracleDataAdapter("select * from SYSPROPERTIESOWNER", connectionString).Fill(dataSet.Tables.Add("SYSPROPERTIESOWNER"));
            new OracleDataAdapter("select * from SYSPROPERTY", connectionString).Fill(dataSet.Tables.Add("SYSPROPERTY"));
            new OracleDataAdapter("select * from SYSASSOCIATION", connectionString).Fill(dataSet.Tables.Add("SYSASSOCIATION"));
            new OracleDataAdapter("select * from SYSVALIDATOR", connectionString).Fill(dataSet.Tables.Add("SYSVALIDATOR"));
            //new OracleDataAdapter("select * from SYSFIELDBINDING", connectionString).Fill(dataSet.Tables.Add("SYSFIELDBINDING"));
            new OracleDataAdapter("select * from SYSPROPERTYBINDING", connectionString).Fill(dataSet.Tables.Add("SYSPROPERTYBINDING"));
            new OracleDataAdapter("select * from SYSSYNCTABLE", connectionString).Fill(dataSet.Tables.Add("SYSSYNCTABLE"));
            new OracleDataAdapter("select * from SYSPOLICY", connectionString).Fill(dataSet.Tables.Add("SYSPOLICY"));

            var ser = new XmlSerializer(typeof(DataSet));
            using (TextWriter writer = new StreamWriter(fileName))
                ser.Serialize(writer, dataSet);
        }
    }

}