using Cosmo.MockDatabase.Seeding.Analyzers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockDatabase.Tests
{
    [TestClass]
    public class AnalyzerTests
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PropertyAnalyzerFactory_Throws_Exception_For_Null_Input()
        {
            var result = PropertyAnalyzerFactory.GetAnalyzedObject(null, null);
        }

        [TestMethod]
        public void AnalyzerFactory_Always_Returns_Value_For_Valid_Parameters()
        {
            var intResult = PropertyAnalyzerFactory.GetAnalyzedObject(typeof(int), "Test");
            var stringResult = PropertyAnalyzerFactory.GetAnalyzedObject(typeof(string), "Test");

            var objResult = PropertyAnalyzerFactory.GetAnalyzedObject(typeof(object), "Test");
            var guidResult = PropertyAnalyzerFactory.GetAnalyzedObject(typeof(Guid), "Test");


            Assert.IsNotNull(intResult);
            Assert.IsNotNull(stringResult);
            Assert.IsNotNull(objResult);
            Assert.IsNotNull(guidResult);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PropertyAnalyzerFactory_Throws_Exception_For_Abstract_Type()
        {
            var result = PropertyAnalyzerFactory.GetAnalyzedObject(typeof(ValueType), "Test");

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PropertyAnalyzerFactory_Throws_Exception_For_Interface_Type()
        {
            var result = PropertyAnalyzerFactory.GetAnalyzedObject(typeof(IEnumerable), "Test");
        }
    }
}
