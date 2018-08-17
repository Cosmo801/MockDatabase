using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmo.MockDatabase.Seeding.Analyzers
{
    public class Int32Analyzer : PropertyAnalyzer
    {
        public Int32Analyzer(PropertyAnalyzer next)
            :base(next)
        {

        }

        public override object GetInstance(Type type, string propertyName)
        {
            if (type != typeof(Int32)) return _next.GetInstance(type, propertyName);

            return 0;
        }
    }
}
