using Cosmo.MockDatabase.Context;
using Cosmo.MockDatabase.Seeding.Loaders;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cosmo.MockDatabase.Seeding
{
    public class ContextSeeder<T> where T : MockContext
    {
        public ContextSeeder()
        {
            ClassSeeders = new Dictionary<string, IClassSeeder>();
            _loader = new ContextSeederLoader();
        }

        public T SeedDatabase(int count = 30)
        {
            _loader.LoadUnsetClassSeeders(this);

            var instance = Activator.CreateInstance<T>();

            foreach (var prop in typeof(T).GetProperties().Where(p => p.PropertyType.Name.Contains("MockCollection")))
            {
                prop.SetValue(instance, Activator.CreateInstance(prop.PropertyType));

                var objList = new List<object>();
                var seeder = ClassSeeders[prop.Name];

                //while(objList.Count() < count)
                //{
                //    objList.Add(seeder.SeedClass());
                //}

                while(((IList)prop.GetValue(instance)).Count < count)
                {
                    ((IList)prop.GetValue(instance)).Add(seeder.SeedClass());
                }

                //Error here
                //cast to list

                //prop.SetValue(instance, objList);

                
            
            }



            return instance;

           

           
            
        }


        public Dictionary<string, IClassSeeder> ClassSeeders { get; set; }

        private ContextSeederLoader _loader;
    }
}