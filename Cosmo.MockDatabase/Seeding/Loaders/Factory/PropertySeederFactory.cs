using System;

namespace Cosmo.MockDatabase.Seeding.Loaders.Factory
{
    public class PropertySeederFactory
    {
        public static IPropertySeeder GetDefaultPropertySeeder(string propertyName, Type propertyType)
        {
            return new DefaultPropertySeeder(propertyName, propertyType);
        }
    }
}
