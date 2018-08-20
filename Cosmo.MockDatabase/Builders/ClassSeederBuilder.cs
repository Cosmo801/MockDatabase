using Cosmo.MockDatabase.Seeding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Cosmo.MockDatabase.Builders
{
    public class ClassSeederBuilder<TClass>
    {
        private IClassSeeder _classSeeder;

        public ClassSeederBuilder(IClassSeeder classSeeder)
        {
            _classSeeder = classSeeder;
        }

        public ClassSeederBuilder<TClass> UseRandomDataPropertySeeder<TProperty>(Expression<Func<TClass, TProperty>> selector, List<TProperty> data)
        {
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
     

    }
}
