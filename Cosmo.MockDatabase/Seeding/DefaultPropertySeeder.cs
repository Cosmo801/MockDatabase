using Cosmo.MockDatabase.Seeding.Analyzers;
using System;

namespace Cosmo.MockDatabase.Seeding
{
    public class DefaultPropertySeeder : IPropertySeeder
    {
        private string _propertyName;
        private Type _propertyType;
        

        public DefaultPropertySeeder(string propertyName, Type propertyType)
        {
            _propertyName = propertyName;
            _propertyType = propertyType;
            
        }

        public PropertyResult GetInstance()
        {
            return new PropertyResult { PropertyInstance = PropertyAnalyzerFactory.GetAnalyzedObject(_propertyType, _propertyName), PropertyName = _propertyName };                     
        }
    }
}
