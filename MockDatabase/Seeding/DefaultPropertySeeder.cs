using MockDatabase.Seeding.Analyzers;
using System;
using System.Reflection;

namespace MockDatabase.Seeding
{
    /// <summary>
    /// Property seeder used when no custom data is supplied by the user. Uses IAnalyzer to produce results.
    /// </summary>


    public class DefaultPropertySeeder : IPropertySeeder
    {
   
        public DefaultPropertySeeder(PropertyInfo propertyInfo)
        {
            _propertyInfo = propertyInfo;
            _type = propertyInfo.PropertyType;

            _analyzer = AnalyzerFactory.GetAnalyzer(propertyInfo.Name, propertyInfo.PropertyType);
        }

        /// <summary>
        /// Get an object for a given property type
        /// </summary>
        /// <returns>The object</returns>
        public object GetPropertyEntry()
        {
            return _analyzer.GetObject();
        }

        public string PropertyName { get; private set; }

        private PropertyInfo _propertyInfo;

        private Type _type;

        private IAnalyzer _analyzer;
    }

   
    
}
