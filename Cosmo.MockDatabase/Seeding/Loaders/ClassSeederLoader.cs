using System;
using System.Collections.Generic;
using System.Text;

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




        //public static IClassSeeder GetDefaultClassSeeder(Type classType)
        //{
        //    IClassSeeder seeder = (IClassSeeder)Activator.CreateInstance(typeof(ClassSeeder).MakeGenericType(new Type[] { classType }));

        //    foreach(var prop in classType.GetProperties())
        //    {
        //        var propSeeder = new DefaultPropertySeeder(prop.Name, prop.PropertyType);
        //        seeder.PropertySeeders.Add(prop.Name, propSeeder);

        //    }

        //    return seeder;

        //}


        //public ClassSeeder<TClass> GetClassSeeder<TClass>() where TClass : class
        //{
        //    var classSeeder = new ClassSeeder<TClass>();
        //    foreach(var prop in typeof(TClass).GetProperties())
        //    {
        //        var seeder = new DefaultPropertySeeder(prop.Name, prop.PropertyType);
        //        classSeeder.ClassPropertySeeders.Add(prop.Name, seeder);
        //    }


        //    return classSeeder;
        //}
    }
}
