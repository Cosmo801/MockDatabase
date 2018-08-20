using Cosmo.MockDatabase.Helpers;
using System;

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

            var randStrings = new string[] { "Random, Arbitrary, Mock, Fake, Word" };
            return randStrings[RandomHelper.GetRandomInt(randStrings.Length - 1)];
        }
    }
}
