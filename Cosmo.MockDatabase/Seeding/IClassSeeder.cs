using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmo.MockDatabase.Seeding
{
    public interface IClassSeeder
    {
        object SeedClass();
        Dictionary<string, IPropertySeeder> PropertySeeders { get; set; }
        Type ClassType { get; }
    }
}
