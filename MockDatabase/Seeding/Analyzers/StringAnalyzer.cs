using MockDatabase.Helpers;

namespace MockDatabase.Seeding.Analyzers
{
    public class StringAnalyzer : IAnalyzer
    {
        
        public object GetObject()
        {

            if (PropertyName.Contains("FirstName") || PropertyName.Contains("LastName"))
            {
                var fNames = new string[] { "Harrison", "Ahmed", "Carter", "Ashley", "Garcia" };
                return fNames[RandomDataHelper.GetRandomNumber(0, fNames.Length)];
            }

            var randomStrings = new string[] { "Random", "Haphazard", "Indiscriminate", "Arbitrary", "Hello World" };
            return randomStrings[RandomDataHelper.GetRandomNumber(0, randomStrings.Length)];




        }

        public string PropertyName { get; set; }
        
    }
}
