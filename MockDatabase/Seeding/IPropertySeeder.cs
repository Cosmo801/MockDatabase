using System;
using System.Collections.Generic;
using System.Text;

namespace MockDatabase.Seeding
{
    /// <summary>
    /// Responsible for creating entries of a class or value type that are properties of TMockCollections
    /// </summary>

    public interface IPropertySeeder
    {
        string PropertyName { get; }
        object GetPropertyEntry();



    }
}
