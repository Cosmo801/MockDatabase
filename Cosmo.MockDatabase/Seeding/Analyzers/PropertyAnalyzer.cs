using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmo.MockDatabase.Seeding.Analyzers
{
    public abstract class PropertyAnalyzer
    {
        public PropertyAnalyzer(PropertyAnalyzer next)
        {
            _next = next;
        }

        protected PropertyAnalyzer _next;

        public abstract object GetInstance(Type type, string propertyName);
    }
}
