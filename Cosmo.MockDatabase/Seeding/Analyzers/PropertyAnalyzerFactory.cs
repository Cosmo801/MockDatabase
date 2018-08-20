using System;

namespace Cosmo.MockDatabase.Seeding.Analyzers
{
    public static class PropertyAnalyzerFactory
    {
        private static StringAnalyzer _analyzerChain;

        static PropertyAnalyzerFactory()
        {
            _analyzerChain = new StringAnalyzer(
                                    new Int32Analyzer(
                                        new ReferenceTypeAnalyzer(
                                            new ValueTypeAnalyzer(
                                                null))));
        }


        public static object GetAnalyzedObject(Type propertyType, string propertyName)
        {
            if (propertyType == null) throw new ArgumentNullException(nameof(Type));
            if (propertyName == null) throw new ArgumentNullException("Null propertyName");

            if (propertyType.IsAbstract || propertyType.IsInterface) throw new ArgumentException();


            return _analyzerChain.GetInstance(propertyType, propertyName);

        }
  

    }
}
