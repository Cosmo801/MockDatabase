using MockDatabase.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MockDatabase.Seeding.Analyzers
{
    /// <summary>
    /// Get analyzer for a given type
    /// </summary>

    public static class AnalyzerFactory
    {
      
        static AnalyzerFactory()
        {
            _analyzerTypes = RegisterAnalyzers();
        }

        /// <summary>
        /// Get an IAnalyzer which will be used to produce data for a property on a class
        /// </summary>
        /// <param name="propertyInfo">The property to get an IAnalyzer for</param>
        /// <returns>IAnalyzer concrete class</returns>
        public static IAnalyzer GetAnalyzer(PropertyInfo propertyInfo)
        {
            var propName = propertyInfo.Name;
            var type = propertyInfo.PropertyType;
            var analyzerName = propertyInfo.PropertyType.Name.ToLowerInvariant() + "analyzer";


            //Maybe change propName to a property on IAnalyzer rather than using constructor
            var analyzer = _analyzerTypes.FirstOrDefault(o => o.Name.ToLowerInvariant() == analyzerName);
            if (analyzer != null) return (IAnalyzer)Activator.CreateInstance(analyzer, new object[] {propName});


            //No value type analyzer is found, the default value will be used
            if (type.IsValueType) return new ValueTypeAnalyzer(type);

            //Reference type analyzer will return null for classes, and the relationships between Entities on the MockContext will be used in an attempt to fill it
            return new ReferenceTypeAnalyzer();

            
        }

        /// <summary>
        /// Gets all IAnalyzers
        /// </summary>
        /// <returns>IEnumerable of IAnalyzer concrete classes</returns>
        public static IEnumerable<Type> RegisterAnalyzers()
        {


            var analyzerTypes = Assembly.GetExecutingAssembly()
                                        .GetTypes()
                                        .Where(t => t.GetInterfaces().SingleOrDefault(i => i.Name == "IAnalyzer") != null)
                                        .Where(t => t.IsClass);
                                     

            return analyzerTypes;
        }

        private static IEnumerable<Type> _analyzerTypes;
    }
}
