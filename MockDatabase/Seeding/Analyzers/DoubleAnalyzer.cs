using MockDatabase.Helpers;

namespace MockDatabase.Seeding.Analyzers
{
    public class DoubleAnalyzer : IAnalyzer
    {
      

        public string PropertyName { get; set; }
        

        public object GetObject()
        {
            if (PropertyName.Contains("Price"))
            {
                var prices = new double[] { 30, 55.99, 5.99, 150, 300 };
                return prices[RandomDataHelper.GetRandomNumber(0, prices.Length)];
            }

            var data = new double[] { 5, 25, 125, 50.5, 99.99 };
            return data[RandomDataHelper.GetRandomNumber(0, data.Length)];

        }
    }
}
