using MockDatabase.Context;
using MockDatabase.Seeding;

namespace MockDatabase.Loader
{
    /// <summary>
    /// Creates the database from a ISeedingConfiguration
    /// </summary>
    /// <typeparam name="TContext">Concrete implementation of MockContext</typeparam>

    public interface IDatabaseLoader<TContext> where TContext : MockContext
    {
        void AddSeedingConfiguration(ISeedingConfiguration<TContext> config);
        TContext CreateDatabase(int count);

    }
}
