using System;
using System.Collections.Generic;
using System.Text;

namespace MockDatabase.Seeding.Analyzers
{
    public class ValueTypeAnalyzer : IAnalyzer
    {
        private Type _valueType;

        public ValueTypeAnalyzer(Type valueType)
        {
            if (!valueType.IsValueType) throw new ArgumentException(nameof(valueType));
            _valueType = valueType;
        }


        public object GetObject()
        {
            return Activator.CreateInstance(_valueType);
        }
    }
}
