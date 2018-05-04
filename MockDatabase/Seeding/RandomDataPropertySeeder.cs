using MockDatabase.Helpers;
using System.Collections.Generic;

namespace MockDatabase.Seeding
{
    /// <summary>
    /// Produces TMockCollectionProperties using user input via a random number generator
    /// </summary>
    /// <typeparam name="T">Type of the property</typeparam>


    public class RandomDataPropertySeeder<T> : IPropertySeeder
    {
       
        public RandomDataPropertySeeder(List<T> randomData, string propertyName)
        {
            _randomData = randomData;
            PropertyName = propertyName;
        }


        /// <summary>
        /// Get an object for a given property type
        /// </summary>
        /// <returns>The object</returns>
        public object GetPropertyEntry()
        {
            var number = RandomDataHelper.GetRandomNumber(0, _randomData.Count);
            return _randomData[number];
        }
        public string PropertyName { get; private set; }

        private List<T> _randomData;
    }
}
