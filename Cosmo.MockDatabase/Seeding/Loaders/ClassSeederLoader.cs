namespace Cosmo.MockDatabase.Seeding.Loaders
{
    public class ClassSeederLoader
    {
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
