namespace Cosmo.MockDatabase.Seeding
{
    /// <summary>
    /// An abstraction represnting how mock data is created for a property
    /// </summary>
    public interface IPropertySeeder
    {
        /// <summary>
        /// Get an instance of some type
        /// </summary>
        /// <returns>PropertyResult which contains the object instance and the type of the object</returns>
        PropertyResult GetInstance();
    }
}