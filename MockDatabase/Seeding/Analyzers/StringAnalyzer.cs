using MockDatabase.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MockDatabase.Seeding.Analyzers
{
    public class StringAnalyzer : IAnalyzer
    {
        private string _propertyName;

        public StringAnalyzer(string propertyName)
        {
            _propertyName = propertyName;
        }

        public object GetObject()
        {

            if (_propertyName.Contains("FirstName") || _propertyName.Contains("LastName"))
            {
                var fNames = new string[] { "Harrison", "Ahmed", "Carter", "Ashley", "Garcia" };
                return fNames[RandomDataHelper.GetRandomNumber(0, fNames.Length)];
            }

            var randomStrings = new string[] { "Random", "Haphazard", "Indiscriminate", "Arbitrary", "Hello World" };
            return randomStrings[RandomDataHelper.GetRandomNumber(0, randomStrings.Length)];




        }
    }
}
