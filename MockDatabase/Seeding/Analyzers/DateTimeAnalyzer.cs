using MockDatabase.Helpers;
using System;

namespace MockDatabase.Seeding.Analyzers
{
    public class DateTimeAnalyzer : IAnalyzer
    {
     
        public string PropertyName { get; set; }
        

        public object GetObject()
        {
            var dates = new DateTime[]
            {
                new DateTime(2015, 1, 1),
                new DateTime(2015, 12, 12),
                new DateTime(2017, 1, 1),
                new DateTime(2015, 12, 12),
                new DateTime(2016, 1, 1),
                new DateTime(2016, 12, 12),
                new DateTime(2017, 1, 1),
                new DateTime(2017, 12, 12)
            };

            return dates[RandomDataHelper.GetRandomNumber(0, dates.Length)];
        }
    }
}
