using Cosmo.MockDatabase.Helpers;
using System;
using System.Collections.Generic;

namespace Cosmo.MockDatabase.Seeding
{
    public class RandomDataPropertySeeder : IPropertySeeder
    {
        private List<object> _randomData;
        private string _propertyName;

        public RandomDataPropertySeeder(string propertyName, List<object> randomData)
        {
            if (randomData.Count == 0) throw new ArgumentException();

            _randomData = randomData ?? throw new ArgumentNullException();
            _propertyName = propertyName ?? throw new ArgumentNullException();
        }


        public PropertyResult GetInstance()
        {
            var randNum = RandomHelper.GetRandomInt(0, _randomData.Count - 1);

            return new PropertyResult
            {
                PropertyName = _propertyName,
                PropertyInstance = _randomData[randNum]
            };
        }
    }
}
