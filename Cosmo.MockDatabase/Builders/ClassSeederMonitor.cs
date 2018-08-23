using Cosmo.MockDatabase.Seeding;
using System.Collections.Generic;

namespace Cosmo.MockDatabase.Builders
{
    /// <summary>
    /// Helper class for implement the fluent API for MockContextBuilder
    /// </summary>
    internal class ClassSeederMonitor
    {
        public ClassSeederMonitor()
        {
            _classSeeders = new Dictionary<string, IClassSeeder>();
        }
 
        public void AddOrUpdateClassSeeder(string className, IClassSeeder seeder)
        {
            if (_classSeeders.ContainsKey(className)) _classSeeders[className] = seeder;
            else _classSeeders.Add(className, seeder);
        }

        public Dictionary<string, IClassSeeder> GetClassSeeders()
        {
            return _classSeeders;
        }

        private Dictionary<string, IClassSeeder> _classSeeders;

    }
}
