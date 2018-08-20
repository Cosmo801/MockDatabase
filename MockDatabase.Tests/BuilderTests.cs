using Cosmo.MockDatabase.Builders;
using Cosmo.MockDatabase.Seeding;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockDatabase.Tests.Context;
using MockDatabase.Tests.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockDatabase.Tests
{
    [TestClass]
    public class BuilderTests
    {

        [TestMethod]
        public void MockContextBuilder_Creates_Default_Context()
        {
            var builder = new MockContextBuilder<SimpleContext>();
            var db = builder.BuildDatabase();

            Assert.IsTrue(db.Customers != null);
            Assert.IsTrue(db.Products != null);

        }

        [TestMethod]
        public void MockContextBuilder_Creates_Correct_Number_Entries()
        {
            var builder = new MockContextBuilder<SimpleContext>();
            var db = builder.BuildDatabase();

            Assert.IsTrue(db.Customers.Count == 30);
            Assert.IsTrue(db.Products.Count == 30);

        }

        [TestMethod]
        public void MockContextBuilder_Can_Add_RandomDataPropertySeeders()
        {
            var builder = new MockContextBuilder<SimpleContext>();

            builder.CustomizeClassSeeder(c => c.Customers)
                        .UseRandomDataPropertySeeder(r => r.Id, new List<int> { 1001 })
                        .UseRandomDataPropertySeeder(r => r.FirstName, new List<string> { "Name" });


            var db = builder.BuildDatabase();

            Assert.IsTrue(db.Customers.All(i => i.Id == 1001));
            Assert.IsTrue(db.Customers.All(c => c.FirstName == "Name"));
        }

        [TestMethod]
        public void MockContextBuilder_Uses_Last_Custom_PropertySeeder()
        {
            var builder = new MockContextBuilder<SimpleContext>();

            builder.CustomizeClassSeeder(c => c.Customers)
                        .UseRandomDataPropertySeeder(r => r.Id, new List<int> { 100 })
                        .UseRandomDataPropertySeeder(r => r.Id, new List<int> { 999 });

            var db = builder.BuildDatabase();

            Assert.IsTrue(db.Customers.All(c => c.Id == 999));
        }

        [TestMethod]
        public void MockContextBuilder_Uses_Overwrites_ClassSeederBuilder()
        {
            var builder = new MockContextBuilder<SimpleContext>();

            builder.CustomizeClassSeeder(c => c.Customers)
                        .UseRandomDataPropertySeeder(r => r.Id, new List<int> { 100 });

            builder.CustomizeClassSeeder(c => c.Customers)
                        .UseRandomDataPropertySeeder(r => r.Id, new List<int> { 999 });

            var db = builder.BuildDatabase();

            Assert.IsTrue(db.Customers.All(c => c.Id == 999));

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ClassSeederBuilder_Throws_Exception_For_Null__Input()
        {
            var classSeederBuilder = new ClassSeederBuilder<Customer>(new ClassSeeder(typeof(Customer)));

            classSeederBuilder.UseRandomDataPropertySeeder(p => p.FirstName, null);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ClassSeederBuilder_Throws_Exception_For_Empty__Input()

        {
            var classSeederBuilder = new ClassSeederBuilder<Customer>(new ClassSeeder(typeof(Customer)));

            classSeederBuilder.UseRandomDataPropertySeeder(p => p.FirstName, new List<string>());

        }
    }
}
