using Cosmo.MockDatabase.Seeding.Analyzers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmo.MockDatabase.Seeding.Loaders
{
    public class PropertySeederLoader
    {
        public DefaultPropertySeeder GetPropertySeeder(string propertyName, Type propertyType)
        {               
            return new DefaultPropertySeeder(propertyName, propertyType);
        }
    }
}
