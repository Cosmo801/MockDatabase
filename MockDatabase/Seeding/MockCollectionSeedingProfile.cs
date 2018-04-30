using MockDatabase.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MockDatabase.Seeding
{
    /// <summary>
    /// MockCollectionSeedingProfile implementation when user supplies custom data.
    /// </summary>
    /// <typeparam name="TMockCollection">The generic type param of a given MockCollection</typeparam>

    public class MockCollectionSeedingProfile<TMockCollection> : IMockCollectionSeedingProfile
    {  

        public MockCollectionSeedingProfile()
        {
            ClassName = typeof(TMockCollection).Name;
            LoadDefaultSeeders();
        }


        /// <summary>
        /// Use the property seeders to produce an object of a given type
        /// </summary>
        /// <returns>object of given TMockCollection</returns>
        public object GetClassEntry()
        {

            var obj = Activator.CreateInstance(typeof(TMockCollection));
            var properties = typeof(TMockCollection).GetProperties();

            foreach(var seeder in _propertySeeders)
            {

                var prop = obj.GetType().GetProperty(seeder.Key);

                obj.GetType()
                   .GetProperty(seeder.Key)
                   .GetSetMethod()
                   .Invoke(obj, new object[] { seeder.Value.GetPropertyEntry() });


                //if (prop.PropertyType.GetInterfaces().Contains(typeof(IEnumerable)) && prop.PropertyType != typeof(string))
                //{
                //    var newOBj = Activator.CreateInstance(typeof(List<>).MakeGenericType(prop.PropertyType.GenericTypeArguments[0]));
                //    var entry = seeder.Value.GetPropertyEntry();
                //    if (entry.GetType().GetInterfaces().Contains(typeof(IEnumerable)))
                //    {
                //        prop.SetValue(obj, entry, null);
                //    }
                //    else
                //    {
                //        ((IList)newOBj).Add(entry);
                //        prop.SetValue(obj, newOBj, null);
                //    }




                //}

                //else
                //{
                //    obj.GetType()
                //   .GetProperty(seeder.Key)
                //   .GetSetMethod()
                //   .Invoke(obj, new object[] { seeder.Value.GetPropertyEntry() });
                //}



            }

            return obj;
        }

        /// <summary>
        /// Get an IPropertySeeder
        /// </summary>
        /// <param name="propertyName">The name of the property</param>
        /// <returns>IPropertSeeder</returns>
        public IPropertySeeder GetSeeder(string propertyName)
        {
            return _propertySeeders[propertyName];
        }

        /// <summary>
        /// Add an IPropertySeeder to this SeedingProfile and overwrite if it exists
        /// </summary>
        /// <param name="seeder"></param>
        public void OverwritePropertySeeder(IPropertySeeder seeder)
        {
            if (!_propertySeeders.ContainsKey(seeder.PropertyName))
            {
                _propertySeeders.Add(seeder.PropertyName, seeder);
            }

            _propertySeeders[seeder.PropertyName] = seeder;

        }

        /// <summary>
        /// Create IPropertySeeders for any properties that are not supplied a custom PropertySeeder.
        /// </summary>
        private void LoadDefaultSeeders()
        {
            var classProperties = typeof(TMockCollection).GetProperties();

            foreach(var property in classProperties)
            {
                if (_propertySeeders.ContainsKey(property.Name)) continue;

                _propertySeeders.Add(property.Name, new DefaultPropertySeeder(property));
            }
        }

      

        public string ClassName { get; private set; }

        private Dictionary<string, IPropertySeeder> _propertySeeders = new Dictionary<string, IPropertySeeder>();
   
    }
}
