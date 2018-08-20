using System;

namespace Cosmo.MockDatabase.Seeding.Analyzers
{
    public class ReferenceTypeAnalyzer : PropertyAnalyzer
    {
        public ReferenceTypeAnalyzer(PropertyAnalyzer next)
            :base(next)
        {

        }


        public override object GetInstance(Type type, string propertyName)
        {
            if (type.IsValueType == true) return _next.GetInstance(type, propertyName);

            return Activator.CreateInstance(type);
        }
    }
}
