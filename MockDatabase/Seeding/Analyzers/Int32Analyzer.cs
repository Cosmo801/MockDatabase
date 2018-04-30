using MockDatabase.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MockDatabase.Seeding.Analyzers
{
    public class Int32Analyzer : IAnalyzer
    {
        private string _propertyName;
        private int i;

        public Int32Analyzer(string propertyName)
        {
            _propertyName = propertyName;
            i = 0;
        }


        public object GetObject()
        {
            if (_propertyName.Contains("Id"))
            {
                i++;
                return i;
            }

            if (_propertyName.Contains("Age"))
            {
                var ages = new int[] { 5, 18, 21, 30, 35, 40, 60, 80 };
                return ages[RandomDataHelper.GetRandomNumber(0, ages.Length)];
            }

            var data = new int[] { 10, 20, 30, 40, 50 };
            return data[RandomDataHelper.GetRandomNumber(0, data.Length)];
        }
    }
}
