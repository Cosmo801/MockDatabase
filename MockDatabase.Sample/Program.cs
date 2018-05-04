using MockDatabase.API;
using MockDatabase.Helpers;
using MockDatabase.Loader;
using MockDatabase.Seeding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockDatabase.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var testy = new List<IEnumerable<OtherTestClass>>();
            testy.Add(new List<OtherTestClass>
            {
                new OtherTestClass
                {
                    Id = 999
                },
                new OtherTestClass
                {
                    Id = 9999
                }
            });

            SeedingConfigurationBuilder<TestContext> builder = new SeedingConfigurationBuilder<TestContext>();

            builder.AddSeedingProfile(s => s.MyEntity)
                        .AddPropertySeeder(p => p.Name, o => o.UseRandomDataPropertySeeder(new List<string> { "test 1", "test2" }))
                        .AddPropertySeeder(p => p.Number, o => o.UseRandomDataPropertySeeder(new List<int> { 69, 96, 168 }));
                        //.AddPropertySeeder(p => p.Orders, o => o.UseRandomDataPropertySeeder(testy));
                        
            
                       
      

            //builder.AddSeedingProfile(s => s.MyOtherEntity)
            //            .AddPropertySeeder(p => p.Id, o => o.UseRandomDataPropertySeeder(new List<int> { 100, 101, 102 }));                 
            
            //Test context instance is returned
            TestContext test = builder.Build();
            IEnumerable<TestClass> myEntities = test.MyEntity;




        }
    }
}
