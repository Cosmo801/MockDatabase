using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmo.MockDatabase.Seeding.Loaders.Factory
{
    public class PropertySeederFactory
    {
        public static DefaultPropertySeeder GetDefaultPropertySeeder(string propertyName, Type propertyType)
        {
            var loader = new PropertySeederLoader();
            return loader.GetPropertySeeder(propertyName, propertyType);
        }
    }
}
