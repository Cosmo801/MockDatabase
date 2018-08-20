using Cosmo.MockDatabase.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Cosmo.MockDatabase.Helpers
{
    internal class MockHelpers
    {
        public static IEnumerable<PropertyInfo> GetMockCollectionPropertiesFromMockContext<TContext>() where TContext : MockContext
        {
            return typeof(TContext).GetProperties()
                                        .Where(p => p.PropertyType.Name.Contains("MockCollection"));
        }
    }
}
