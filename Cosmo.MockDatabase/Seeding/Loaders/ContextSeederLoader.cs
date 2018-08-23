using Cosmo.MockDatabase.Context;
using Cosmo.MockDatabase.Helpers;
using System.Linq;

namespace Cosmo.MockDatabase.Seeding.Loaders
{
    /// <summary>
    /// Create the default IClassSeeders for a ContextSeeder
    /// </summary>
    public class ContextSeederLoader
    {
        /// <summary>
        /// Create IClassSeeders for each MockCollection property on the MockContext subclass, if they have not been supplied by the client
        /// </summary>
        /// <typeparam name="TContext">MockContext subclass</typeparam>
        /// <param name="contextSeeder">The ContextSeeder</param>
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
