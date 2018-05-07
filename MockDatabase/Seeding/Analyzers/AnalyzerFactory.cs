using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
        public static IAnalyzer GetAnalyzer(string propertyName, Type propertyType)
        {

            var analyzerName = propertyType.Name.ToLowerInvariant() + "analyzer";

            var analyzerType = (_analyzerTypes.SingleOrDefault(o => o.Name.ToLowerInvariant() == analyzerName));        

            if(analyzerType != null)
            {
                var analyzerInstance = (IAnalyzer)Activator.CreateInstance(analyzerType);
                analyzerInstance.PropertyName = propertyName;

                return analyzerInstance;
            }

            //No value type analyzer is found, the default value will be used
            if (propertyType.IsValueType) return new ValueTypeAnalyzer(propertyType);

            //Reference type analyzer will return null for classes, and the relationships between Entities on the MockContext will be used in an attempt to fill it
            return new ReferenceTypeAnalyzer();


        }

        /// <summary>
        /// Gets all IAnalyzers
        /// </summary>
        /// <returns>IEnumerable of IAnalyzer concrete classes</returns>
        private static IEnumerable<Type> RegisterAnalyzers()
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
