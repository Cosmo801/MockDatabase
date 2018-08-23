namespace Cosmo.MockDatabase.Seeding.Loaders
{

    /// <summary>
    /// Create the DefaultPropertySeeders for an IClassSeeder
    /// </summary>
    public class ClassSeederLoader
    {
        /// <summary>
        /// Create DefaultPropertySeeders for each property on the IClassSeeder.Type that hasnt been defined by a client
        /// </summary>
        /// <param name="seeder">The IClassSeeder</param>
        public void LoadUnsetPropertySeeders(IClassSeeder seeder)
        {
            foreach(var prop in seeder.ClassType.GetProperties())
            {
                if (seeder.PropertySeeders.ContainsKey(prop.Name)) continue;
                var propSeeder = new DefaultPropertySeeder(prop.Name, prop.PropertyType);
                seeder.PropertySeeders.Add(prop.Name, propSeeder);
            }
        }
        
    }
}
