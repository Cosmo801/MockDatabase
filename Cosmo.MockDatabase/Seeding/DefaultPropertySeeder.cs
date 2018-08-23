using Cosmo.MockDatabase.Seeding.Analyzers;
using System;

namespace Cosmo.MockDatabase.Seeding
{
    /// <summary>
    /// Default IPropertySeeder that is used when the client doesnt supply a custom IPropertySeeder to seed a property
    /// </summary>
    public class DefaultPropertySeeder : IPropertySeeder
    {
     
        public DefaultPropertySeeder(string propertyName, Type propertyType)
        {
            _propertyName = propertyName;
            _propertyType = propertyType;
            
        }

        public PropertyResult GetInstance()
        {
            return new PropertyResult { PropertyInstance = PropertyAnalyzerFactory.GetAnalyzedObject(_propertyType, _propertyName), PropertyName = _propertyName };                     
        }

        private string _propertyName;
        private Type _propertyType;

    }
}
