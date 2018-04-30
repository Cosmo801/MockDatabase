using System;
using System.Collections.Generic;
using System.Text;

namespace MockDatabase.Helpers
{
    /// <summary>
    /// Produce random ints for indexing
    /// </summary>

    public static class RandomDataHelper
    {
        private static Random _random;

        static RandomDataHelper()
        {
            _random = new Random();
        }

        public static int GetRandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        public static List<T> GetRandomData<T>(List<T> data, int count)
        {

            var randomList = new List<T>();

            for (int i = 0; i < count; i++)
            {
                var randNum = _random.Next(0, data.Count);
                var randEntry = data[randNum];

                randomList.Add(randEntry);
            }


            return randomList;
        }
    }
}
