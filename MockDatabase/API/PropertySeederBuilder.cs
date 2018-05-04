using MockDatabase.Seeding;
using System.Collections.Generic;

namespace MockDatabase.API
{

    /// <summary>
    /// API for creating IPropertySeeders
    /// </summary>
    /// <typeparam name="TProperty"></typeparam>
    public class PropertySeederBuilder<TProperty>
    {
       
        public PropertySeederBuilder(string propertyName)
        {
            _propertyName = propertyName;
        }

       /// <summary>
       /// Create a RandomDataPropertySeeder by supplying data that will be randomly selected
       /// </summary>
       /// <param name="data">Data to be randomly selected</param>
       /// <returns>IPropertySeeder</returns>
        public IPropertySeeder UseRandomDataPropertySeeder(List<TProperty> data)
        {
            return new RandomDataPropertySeeder<TProperty>(data, _propertyName);
        }


        private string _propertyName;




    }
}
