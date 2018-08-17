using Cosmo.MockDatabase.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cosmo.MockDatabase.Seeding.Loaders
{
    public class ContextSeederLoader
    {
        public void LoadUnsetClassSeeders<T>(ContextSeeder<T> contextSeeder) where T : MockContext
        {
            foreach (var prop in typeof(T).GetProperties().Where(p => p.PropertyType.Name.Contains("MockCollection")))
            {
                var classType = prop.PropertyType.GenericTypeArguments[0];
                if (contextSeeder.ClassSeeders.ContainsKey(prop.Name)) continue;

                var classSeeder = new ClassSeeder(classType);
                contextSeeder.ClassSeeders.Add(prop.Name, classSeeder);
            }
        }
    }
}
