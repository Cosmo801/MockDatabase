using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmo.MockDatabase.Seeding.Analyzers
{
    public static class PropertyAnalyzerFactory
    {
        private static StringAnalyzer _analyzerChain;

        static PropertyAnalyzerFactory()
        {
            _analyzerChain = new StringAnalyzer(new Int32Analyzer(null));
        }


        public static object GetAnalyzedObject(Type propertyType, string propertyName)
        {           
            return _analyzerChain.GetInstance(propertyType, propertyName);

        }
  

    }
}
