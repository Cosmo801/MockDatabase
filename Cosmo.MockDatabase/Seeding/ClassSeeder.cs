using Cosmo.MockDatabase.Seeding.Loaders;
using Cosmo.MockDatabase.Seeding.Loaders.Factory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmo.MockDatabase.Seeding
{
    public class ClassSeeder : IClassSeeder
    {
    

        public ClassSeeder(Type classType)
        {
            ClassType = classType;
            _loader = new ClassSeederLoader();
            PropertySeeders = new Dictionary<string, IPropertySeeder>();
        }

        public object SeedClass()
        {
            _loader.LoadUnsetPropertySeeders(this);

            var classInstance = Activator.CreateInstance(ClassType);

            foreach (var prop in ClassType.GetProperties())
            {
                var seeder = PropertySeeders[prop.Name];
                classInstance.GetType().GetProperty(prop.Name).SetValue(classInstance, seeder.GetInstance().PropertyInstance);
            }

            return classInstance;
        }

        public Dictionary<string, IPropertySeeder> PropertySeeders { get; set; }

        public Type ClassType { get; }

        private ClassSeederLoader _loader;

        
    }
}