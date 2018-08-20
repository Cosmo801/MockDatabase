using Cosmo.MockDatabase.Context;
using Cosmo.MockDatabase.Helpers;
using System.Linq;

namespace Cosmo.MockDatabase.Seeding.Loaders
{
    public class ContextSeederLoader
    {
        public void LoadUnsetClassSeeders<TContext>(ContextSeeder<TContext> contextSeeder) where TContext : MockContext
        {
            foreach (var prop in MockHelpers.GetMockCollectionPropertiesFromMockContext<TContext>())
            {
                var classType = prop.PropertyType.GenericTypeArguments[0];
                if (contextSeeder.ClassSeeders.ContainsKey(prop.Name)) continue;

                var classSeeder = new ClassSeeder(classType);
                contextSeeder.ClassSeeders.Add(prop.Name, classSeeder);
            }
        }
    }
}
