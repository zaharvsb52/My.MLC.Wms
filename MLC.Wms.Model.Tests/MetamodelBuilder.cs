using System.Configuration;
using System.IO;
using MLC.Wms.Bootstrap.Metamodel;
using NUnit.Framework;

namespace MLC.Wms.Model.Tests
{
    [TestFixture]
    public class MetamodelBuilder
    {
        public const string FileName = @"..\..\Metamodel.xml";

        [Test]
        public void SaveMetamodel()
        {
            var fileName = Path.Combine(TestContext.CurrentContext.TestDirectory, FileName);
            var connectionString = ConfigurationManager.ConnectionStrings["wms"];
            var persister = new LocalMetadataPersister();
            persister.Save(fileName, connectionString.ConnectionString);
        }
    }
}