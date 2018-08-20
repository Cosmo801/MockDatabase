using Cosmo.MockDatabase.Builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockDatabase.Tests.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockDatabase.Tests
{
    [TestClass]
    public class Sample
    {
        [TestMethod]
        public void MyTestMethod()
        {
            var builder = new MockContextBuilder<SimpleContext>();
            var meme = builder.CustomizeClassSeeder(c => c.Customers);
        }
    }
}
