using System;
using System.Data;
using System.IO;
using System.Xml.Serialization;
using FluentAssertions;
using NUnit.Framework;
using WebClient.Common.Metamodel.Impl.Dynamic.Readers;

namespace MLC.Wms.Model.Tests
{
    [TestFixture]
    public class MetamodelDataSetReaderTests
    {
        [Test]
        public void PerformanceTest()
        {
            string fileName = Path.Combine(TestContext.CurrentContext.TestDirectory, "Metamodel.xml");

            DataSet dataSet;
            var ser = new XmlSerializer(typeof (DataSet));
            using (TextReader r = new StreamReader(fileName))
                dataSet = (DataSet) ser.Deserialize(r);

            Action action = () => {
                var reader = new MetamodelDataSetReader(dataSet);
                var propOwners = reader.ReadPropertiesOwners();
                var bindings = reader.ReadBindings();
            };
            action.ExecutionTime().ShouldNotExceed(TimeSpan.FromSeconds(30));
        }
    }
}