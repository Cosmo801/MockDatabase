using System;

namespace Cosmo.MockDatabase.Seeding.Analyzers
{
    public class ValueTypeAnalyzer : PropertyAnalyzer
    {
        public ValueTypeAnalyzer(PropertyAnalyzer next)
            :base(next)
        {

        }

        public override object GetInstance(Type type, string propertyName)
        {
            if (type.IsValueType == false) return _next.GetInstance(type, propertyName);

            return Activator.CreateInstance(type);
        }
    }
}
