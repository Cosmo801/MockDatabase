using System;
using System.Collections.Generic;
using System.Text;

namespace MockDatabase.Seeding
{
    /// <summary>
    /// Responsible for seeding a MockCollection type param class
    /// </summary>


    public interface IMockCollectionSeedingProfile
    {
        string ClassName { get; }
        void OverwritePropertySeeder(IPropertySeeder seeder);
        IPropertySeeder GetSeeder(string propertyName);
        object GetClassEntry();
  


    }
}
