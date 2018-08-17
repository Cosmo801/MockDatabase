using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmo.MockDatabase.Seeding.Analyzers
{
    public class StringAnalyzer : PropertyAnalyzer
    {
        public StringAnalyzer(PropertyAnalyzer next)
            :base(next)
        {

        }

        public override object GetInstance(Type type, string propertyName)
        {
            if (type != typeof(String)) return _next.GetInstance(type, propertyName);

            return "Test";
        }
    }
}
