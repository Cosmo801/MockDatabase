using Cosmo.MockDatabase.Helpers;
using System;
using System.Collections.Generic;

namespace Cosmo.MockDatabase.Seeding
{
    /// <summary>
    /// The client can provide a list of data to be chosen randomly for each property instance to be created
    /// </summary>
    public class RandomDataPropertySeeder : IPropertySeeder
    {
      
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

        private List<object> _randomData;
        private string _propertyName;
    }
}
