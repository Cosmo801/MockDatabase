using System;
using System.Collections.Generic;

namespace Cosmo.MockDatabase.Seeding
{
    public interface IClassSeeder
    {
        object SeedClass();
        Dictionary<string, IPropertySeeder> PropertySeeders { get; set; }
        Type ClassType { get; }
    }
}
