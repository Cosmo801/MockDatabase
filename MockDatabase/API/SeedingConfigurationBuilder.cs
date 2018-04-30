using MockDatabase.Context;
using MockDatabase.Helpers;
using MockDatabase.Loader;
using MockDatabase.Seeding;
using System;
using System.Collections.Generic;
using System.Text;

namespace MockDatabase.API
{
    /// <summary>
    /// Helper for creating a SeedingConfiguration for TContext
    /// </summary>
    /// <typeparam name="TContext"></typeparam>

    public class SeedingConfigurationBuilder<TContext> where TContext : MockContext
    {
   
       /// <summary>
       /// Add an IMockCollectionSeedingProfile for a given MockCollection property on a TContext
       /// </summary>
       /// <typeparam name="TMockCollection">The class the IMockCollectionSeedingProfile will seed</typeparam>
       /// <param name="selector">Selector for the class</param>
       /// <returns>SeedingProfileBuilder to add PropertySeeder options</returns>
        public SeedingProfileBuilder<TMockCollection> AddSeedingProfile<TMockCollection>(Func<TContext, MockCollection<TMockCollection>> selector) where TMockCollection : class
        {
            if (!ReflectionHelpers.IsMockCollection(typeof(TContext), typeof(TMockCollection))) throw new ArgumentException(nameof(TMockCollection));

            var profileBuilder = new SeedingProfileBuilder<TMockCollection>();
            SeedingConfiguration.AddSeedingProfile(profileBuilder.BuildProfile());
            return profileBuilder;
        }

        /// <summary>
        /// Create the TContext object from the ISeedingConfiguration
        /// </summary>
        /// <param name="count">The number of entries for each MockCollection</param>
        /// <returns>TContext object with seeded data</returns>
        public TContext Build(int count = 30)
        {
            var loader = new InMemoryDatabaseLoader<TContext>();
            loader.AddSeedingConfiguration(SeedingConfiguration);

            return loader.CreateDatabase(count);

        }

        public ISeedingConfiguration<TContext> SeedingConfiguration { get; private set; } = new SeedingConfiguration<TContext>();

    }
}
