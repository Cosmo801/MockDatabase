using MockDatabase.Seeding;
using System;
using System.Linq.Expressions;

namespace MockDatabase.API
{
    public class SeedingProfileBuilder<TClass>
    {
        public SeedingProfileBuilder()
        {
            _mockCollectionSeedingProfile = new MockCollectionSeedingProfile<TClass>();
        }


        /// <summary>
        /// Add a property seeder to the seeding profile of a class
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="selector">Select which Property on TClass to create an IPropertySeederFor for</param>
        /// <param name="propertyBuilder">PropertySeeder options builder</param>
        /// <returns>SeedingProfileBuilder for adding more IPropertySeeders</returns>
        public SeedingProfileBuilder<TClass> AddPropertySeeder<TProperty>(Expression<Func<TClass, TProperty>> selector, Func<PropertySeederBuilder<TProperty>, IPropertySeeder> propertyBuilder)
        {
            var memberExpression = (MemberExpression)selector.Body;
            var name = memberExpression.Member.Name;

            var builder = new PropertySeederBuilder<TProperty>(name);
            var propertySeeder = propertyBuilder(builder);
            _mockCollectionSeedingProfile.OverwritePropertySeeder(propertySeeder);

            return this;
        }

        public IMockCollectionSeedingProfile BuildProfile()
        {
            return _mockCollectionSeedingProfile;
        }

        private IMockCollectionSeedingProfile _mockCollectionSeedingProfile;


    }
}
