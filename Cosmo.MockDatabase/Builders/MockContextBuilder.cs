using Cosmo.MockDatabase.Context;
using Cosmo.MockDatabase.Seeding;
using System;
using System.Linq.Expressions;

namespace Cosmo.MockDatabase.Builders
{
    /// <summary>
    /// Fluent API for customizing IClassSeeders for a ContextSeeder
    /// </summary>
    /// <typeparam name="TContext">MockContext subclass</typeparam>
    public class MockContextBuilder<TContext> where TContext : MockContext
    {
   

        public MockContextBuilder()
        {
            _contextSeeder = new ContextSeeder<TContext>();
            _classSeederMonitor = new ClassSeederMonitor();
        }

        /// <summary>
        /// Build the database
        /// </summary>
        /// <param name="count">Number of instances per MockCollection</param>
        /// <returns></returns>
        public TContext BuildDatabase(int count = 30)
        {
            foreach(var entry in _classSeederMonitor.GetClassSeeders())
            {
                if (_contextSeeder.ClassSeeders.ContainsKey(entry.Key)) _contextSeeder.ClassSeeders[entry.Key] = entry.Value;
                else _contextSeeder.ClassSeeders.Add(entry.Key, entry.Value);
            }


            return _contextSeeder.SeedDatabase(count);
        }

        /// <summary>
        /// Customize an IClassSeeder with a ClassSeederBuilder API
        /// </summary>
        /// <typeparam name="TClass">Type of the class</typeparam>
        /// <param name="selector"></param>
        /// <returns></returns>
        public ClassSeederBuilder<TClass> CustomizeClassSeeder<TClass>(Expression<Func<TContext, MockCollection<TClass>>> selector) where TClass : class
        {

            dynamic dynamicExp = selector;
            var className = dynamicExp.Body.Member.Name;

            var classSeeder = new ClassSeeder(typeof(TClass));
            _classSeederMonitor.AddOrUpdateClassSeeder(className, classSeeder);

            var classSeederBuilder = new ClassSeederBuilder<TClass>(classSeeder);

            return classSeederBuilder;
        }

        private ContextSeeder<TContext> _contextSeeder;
        private ClassSeederMonitor _classSeederMonitor;
    }
}
