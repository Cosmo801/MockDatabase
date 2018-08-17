using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockDatabase.Tests.Context;
using MockDatabase.Tests.Context.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmo.MockDatabase.Seeding;
using Cosmo.MockDatabase.Seeding.Analyzers;
using System;

namespace MockDatabase.Tests
{
    [TestClass]
    public class SeedingTests
    {
        [TestMethod]
        public void ContextSeeder_Creates_Data()
        {
            var seeder = new ContextSeeder<SimpleContext>();
            SimpleContext db = seeder.SeedDatabase();

            Assert.IsTrue(db.Customers.Count == 30);

        }

        [TestMethod]
        public void ClassSeeder_Creates_Data()
        {
            var classSeeder = new ClassSeeder(typeof(Customer));
            var data = (Customer)classSeeder.SeedClass();

            Assert.IsNotNull(data);
            Assert.IsTrue(data.FirstName != null);

            
        }

        [TestMethod]
        public void DefaultPropertySeeder_Creates_Data()
        {
            var propertySeeder = new DefaultPropertySeeder("Number", typeof(Int32));
            var result = propertySeeder.GetInstance();

            Assert.IsTrue(result.PropertyInstance.GetType() == typeof(int));
            Assert.IsTrue(result.PropertyName == "Number");
        }

        [TestMethod]
        public void ContextSeeder_Uses_Correct_Default_Class_Seeders_With_SimpleContext()
        {
            var seeder = new ContextSeeder<SimpleContext>();
            var db = seeder.SeedDatabase(1);

            Assert.IsTrue(seeder.ClassSeeders.ContainsKey("Customers"));
            Assert.IsTrue(seeder.ClassSeeders.ContainsKey("Products"));
            Assert.IsTrue(seeder.ClassSeeders.Count == 2);
        }

        [TestMethod]
        public void ClassSeeder_Loads_Correct_Default_IPropertySeeders_For_Customer()
        {
            var classSeeder = new ClassSeeder(typeof(Customer));
            var data = classSeeder.SeedClass();


            Assert.IsTrue(classSeeder.PropertySeeders.ContainsKey("Id"));
            Assert.IsTrue(classSeeder.PropertySeeders.ContainsKey("FirstName"));
            Assert.IsTrue(classSeeder.PropertySeeders["Id"].GetInstance().PropertyInstance.GetType() == typeof(int));
            Assert.IsTrue(classSeeder.PropertySeeders["FirstName"].GetInstance().PropertyInstance.GetType() == typeof(string));

        }



    }
}
