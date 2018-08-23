using System;
using System.Collections.Generic;

namespace Cosmo.MockDatabase.Seeding
{

    /// <summary>
    /// An abstraction that represents how mock data is created for an entity.
    /// </summary>
    public interface IClassSeeder
    {
        /// <summary>
        /// Get an instance of an entity class
        /// </summary>
        /// <returns>An instance of an entity class</returns>
        object SeedClass();

        /// <summary>
        /// Get the seeders for each property defined on the entity class
        /// </summary>      
        Dictionary<string, IPropertySeeder> PropertySeeders { get; set; }

        /// <summary>
        /// Get the type of the entity class
        /// </summary>
        Type ClassType { get; }
    }
}
