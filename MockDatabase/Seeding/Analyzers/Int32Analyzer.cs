using MockDatabase.Helpers;

namespace MockDatabase.Seeding.Analyzers
{
    public class Int32Analyzer : IAnalyzer
    {

        private int i;

        public Int32Analyzer()
        {          
            i = 0;
        }


        public object GetObject()
        {
            if (PropertyName.Contains("Id"))
            {
                i++;
                return i;
            }

            if (PropertyName.Contains("Age"))
            {
                var ages = new int[] { 5, 18, 21, 30, 35, 40, 60, 80 };
                return ages[RandomDataHelper.GetRandomNumber(0, ages.Length)];
            }

            var data = new int[] { 10, 20, 30, 40, 50 };
            return data[RandomDataHelper.GetRandomNumber(0, data.Length)];
        }

        public string PropertyName { get; set; }
        
    }
}
