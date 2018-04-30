using MockDatabase.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace MockDatabase.Seeding
{
    /// <summary>
    /// Responsible for interacting with SeedingProfiles to produce a TContext
    /// </summary>
    /// <typeparam name="TContext">Concrete implementation of MockContext</typeparam>

    public interface ISeedingConfiguration<TContext> where TContext : MockContext
    {
        void AddSeedingProfile(IMockCollectionSeedingProfile seedingProfile);
        TContext SeedDatabase(int count);

    }
}
