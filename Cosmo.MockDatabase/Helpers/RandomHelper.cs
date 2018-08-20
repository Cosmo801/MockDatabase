using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmo.MockDatabase.Helpers
{
    public class RandomHelper
    {
        private static Random _random;

        static RandomHelper()
        {
            _random = new Random();
        }

        public static int GetRandomInt(int min, int max)
        {
            return _random.Next(min, max);
        }

        public static int GetRandomInt(int max)
        {
            return GetRandomInt(0, max);
        }


    }
}
