using MockDatabase.Seeding.Analyzers;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

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

            _analyzer = AnalyzerFactory.GetAnalyzer(_propertyInfo);
        }

        /// <summary>
        /// Get an object for a given property type
        /// </summary>
        /// <returns>The object</returns>
        public object GetPropertyEntry()
        {
            return _analyzer.GetObject();
            //if (_analyzer != null) return _analyzer.GetObject();

            //if (_type.IsInterface) return null;
            //if (_type.IsClass) return null;
            //return Activator.CreateInstance(_type);
        }

        public string PropertyName { get; private set; }

        private PropertyInfo _propertyInfo;

        private Type _type;

        private IAnalyzer _analyzer;
    }

   
    
}
