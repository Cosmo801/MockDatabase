using System;

namespace Cosmo.MockDatabase.Seeding.Analyzers
{
    /// <summary>
    /// Sets up the PropertyAnalyzer chain of responsbility
    /// </summary>
    public static class PropertyAnalyzerFactory
    { 

        static PropertyAnalyzerFactory()
        {
            _analyzerChain = new StringAnalyzer(
                                    new Int32Analyzer(
                                        new ReferenceTypeAnalyzer(
                                            new ValueTypeAnalyzer(
                                                null))));
        }


        /// <summary>
        /// Use the chain of PropertyAnalyzers to get an object instance of a given property
        /// </summary>
        /// <param name="propertyType">Type of the property</param>
        /// <param name="propertyName">Name of the property</param>
        /// <returns>An object instance of the given type</returns>
        public static object GetAnalyzedObject(Type propertyType, string propertyName)
        {
            if (propertyType == null) throw new ArgumentNullException(nameof(Type));
            if (propertyName == null) throw new ArgumentNullException("Null propertyName");

            if (propertyType.IsAbstract || propertyType.IsInterface) throw new ArgumentException();


            return _analyzerChain.GetInstance(propertyType, propertyName);

        }

        private static StringAnalyzer _analyzerChain;


    }
}
