using MockDatabase.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MockDatabase.Seeding.Analyzers
{
    public class DoubleAnalyzer : IAnalyzer
    {
        private string _propertyName;

        public DoubleAnalyzer(string propertyName)
        {
            _propertyName = propertyName;
        }     

        public object GetObject()
        {
            if (_propertyName.Contains("Price"))
            {
                var prices = new double[] { 30, 55.99, 5.99, 150, 300 };
                return prices[RandomDataHelper.GetRandomNumber(0, prices.Length)];
            }

            var data = new double[] { 5, 25, 125, 50.5, 99.99 };
            return data[RandomDataHelper.GetRandomNumber(0, data.Length)];

        }
    }
}
