using Cosmo.MockDatabase.Helpers;
using System;

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

            var randInts = new int[] { 10, 20, 30, 40, 50 };
            return randInts[RandomHelper.GetRandomInt(randInts.Length - 1)];
        }
    }
}
