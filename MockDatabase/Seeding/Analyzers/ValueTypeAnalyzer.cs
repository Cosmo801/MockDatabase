using System;

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

        public string PropertyName { get; set; }

        public object GetObject()
        {
            return Activator.CreateInstance(_valueType);
        }
    }
}
