using Cosmo.MockDatabase.Context;
using Cosmo.MockDatabase.Seeding;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Cosmo.MockDatabase.Builders
{
    public class MockContextBuilder<TContext> where TContext : MockContext
    {
        private ContextSeeder<TContext> _contextSeeder;
        private ClassSeederMonitor _classSeederMonitor;


        public MockContextBuilder()
        {
            _contextSeeder = new ContextSeeder<TContext>();
            _classSeederMonitor = new ClassSeederMonitor();
        }

        public TContext BuildDatabase(int count = 30)
        {
            foreach(var entry in _classSeederMonitor.GetClassSeeders())
            {
                if (_contextSeeder.ClassSeeders.ContainsKey(entry.Key)) _contextSeeder.ClassSeeders[entry.Key] = entry.Value;
                else _contextSeeder.ClassSeeders.Add(entry.Key, entry.Value);
            }


            return _contextSeeder.SeedDatabase(count);
        }

        public ClassSeederBuilder<TClass> CustomizeClassSeeder<TClass>(Expression<Func<TContext, MockCollection<TClass>>> selector) where TClass : class
        {

            dynamic dynamicExp = selector;
            var className = dynamicExp.Body.Member.Name;

            var classSeeder = new ClassSeeder(typeof(TClass));
            _classSeederMonitor.AddOrUpdateClassSeeder(className, classSeeder);

            var classSeederBuilder = new ClassSeederBuilder<TClass>(classSeeder);

            return classSeederBuilder;
        }
    }
}
