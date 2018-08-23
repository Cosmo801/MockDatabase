using Cosmo.MockDatabase.Context;
using Cosmo.MockDatabase.Seeding.Loaders;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cosmo.MockDatabase.Seeding
{
    /// <summary>
    /// A class that creates a MockContext implementation using IClassSeeders for each defined MockCollection
    /// </summary>
    /// <typeparam name="T">The MockContext subclass</typeparam>
    public class ContextSeeder<T> where T : MockContext
    {
        public ContextSeeder()
        {
            ClassSeeders = new Dictionary<string, IClassSeeder>();
            _loader = new ContextSeederLoader();
        }

        /// <summary>
        /// Return an instance of the MockContext subclass.
        /// </summary>
        /// <param name="count">Number of objects per each defined MockCollection</param>
        /// <returns>An instance of the MockContext subclass</returns>
        public T SeedDatabase(int count = 30)
        {
            _loader.LoadUnsetClassSeeders(this);

            var instance = Activator.CreateInstance<T>();

            foreach (var prop in typeof(T).GetProperties().Where(p => p.PropertyType.Name.Contains("MockCollection")))
            {
                prop.SetValue(instance, Activator.CreateInstance(prop.PropertyType));

                var objList = new List<object>();
                var seeder = ClassSeeders[prop.Name];

                while(((IList)prop.GetValue(instance)).Count < count)
                {
                    ((IList)prop.GetValue(instance)).Add(seeder.SeedClass());
                }
            
            
            }

            return instance;

           

           
            
        }

        /// <summary>
        /// Get or Set the IClassSeeders 
        /// </summary>
        public Dictionary<string, IClassSeeder> ClassSeeders { get; private set; }

        private ContextSeederLoader _loader;
    }
}