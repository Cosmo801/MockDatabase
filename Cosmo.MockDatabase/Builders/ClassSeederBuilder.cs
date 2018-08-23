using Cosmo.MockDatabase.Seeding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Cosmo.MockDatabase.Builders
{
    /// <summary>
    /// Fluent API for customizing IPropertySeeders for a given IClassSeeder
    /// </summary>
    /// <typeparam name="TClass">Type of the class to be seeded</typeparam>
    public class ClassSeederBuilder<TClass>
    {
      
        public ClassSeederBuilder(IClassSeeder classSeeder)
        {
            _classSeeder = classSeeder ?? throw new ArgumentNullException();
        }

        public ClassSeederBuilder<TClass> UseRandomDataPropertySeeder<TProperty>(Expression<Func<TClass, TProperty>> selector, List<TProperty> data)
        {
            if (selector == null) throw new ArgumentNullException();

            if (data == null) throw new ArgumentNullException();
            if (data.Count == 0) throw new ArgumentException();


            dynamic dynamicExp = selector;

            var propertyName = dynamicExp.Body.Member.Name;
            var propertySeeder = new RandomDataPropertySeeder(propertyName, data.Cast<object>().ToList());

            if (_classSeeder.PropertySeeders.ContainsKey(propertyName))
            {
                _classSeeder.PropertySeeders[propertyName] = propertySeeder;
            }

            else _classSeeder.PropertySeeders.Add(propertyName, propertySeeder);

            return this;
        }

        private IClassSeeder _classSeeder;

    }
}
