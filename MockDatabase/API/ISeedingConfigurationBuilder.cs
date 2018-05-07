using MockDatabase.Context;
using MockDatabase.Seeding;
using System;

namespace MockDatabase.API
{
    /// <summary>
    /// Interface for a helper to easily create ISeedingConfigurations
    /// </summary>
    /// <typeparam name="TContext"></typeparam>

    public interface ISeedingConfigurationBuilder<TContext> where TContext: MockContext
    {
        SeedingProfileBuilder<TMockCollection> AddSeedingProfile<TMockCollection>(Func<TContext, MockCollection<TMockCollection>> selector) where TMockCollection : class;
        TContext Build(int count = 30);
        ISeedingConfiguration<TContext> SeedingConfiguration { get; }




    }
}
