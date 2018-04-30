using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockDatabase.API;
using MockDatabase.Tests.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockDatabase.Tests
{
    [TestClass]
    public class UnitTests
    {

        [TestMethod]
        public void TestDefaults()
        {
            var builder = new SeedingConfigurationBuilder<SimpleContext>();
            var db = builder.Build();

            Assert.IsTrue(db.Customers.Any(c => c != null));
        }


        [TestMethod]
        public void TestSimpleContext()
        {
            var builder = new SeedingConfigurationBuilder<SimpleContext>();
            builder.AddSeedingProfile(s => s.Products)
                        .AddPropertySeeder(p => p.Name, o => o.UseRandomDataPropertySeeder(new List<string> { "Apple", "Banana", "Orange" }))
                        .AddPropertySeeder(p => p.Quantity, o => o.UseRandomDataPropertySeeder(new List<int> { 25, 35, 45 }));

            var db = builder.Build();

            Assert.IsInstanceOfType(db, typeof(SimpleContext));

            //Default count is 30
            Assert.IsTrue(db.Customers.Count == 30);
            Assert.IsTrue(db.Products.Count == 30);


            Assert.IsTrue(db.Products.Select(p => p.Name).Any(n => n == "Apple" || n == "Banana" || n == "Orange"));
            Assert.IsTrue(db.Products.Select(p => p.Quantity).Any(q => q == 25|| q == 35 || q == 45));
           


        }
    }
}
