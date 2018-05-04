using MockDatabase.Context;
using MockDatabase.Seeding;

namespace MockDatabase.Loader
{
    /// <summary>
    /// Default implementation of IDatabaseLoader
    /// </summary>
    /// <typeparam name="TContext"></typeparam>


    public class InMemoryDatabaseLoader<TContext> : IDatabaseLoader<TContext> where TContext : MockContext
    {
        private ISeedingConfiguration<TContext> _config;

        public void AddSeedingConfiguration(ISeedingConfiguration<TContext> config)
        {
            _config = config;
        }

        public TContext CreateDatabase(int count = 30)
        {
            return _config.SeedDatabase(count);
        }
    }
}
