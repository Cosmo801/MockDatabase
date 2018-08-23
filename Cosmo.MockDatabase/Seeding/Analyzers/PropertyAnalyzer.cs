using System;

namespace Cosmo.MockDatabase.Seeding.Analyzers
{
    /// <summary>
    /// Create an instance of a given property by analysing the property type and property name
    /// Set up the Chain of Responsiblity pattern
    /// </summary>
    public abstract class PropertyAnalyzer
    {
        public PropertyAnalyzer(PropertyAnalyzer next)
        {
            _next = next;
        }

        /// <summary>
        /// The next PropertyAnalyzer in the chain
        /// </summary>
        protected PropertyAnalyzer _next;

        /// <summary>
        /// Get an instance of a property
        /// </summary>
        /// <param name="type">Type of the property</param>
        /// <param name="propertyName">Name of the property</param>
        /// <returns>An object instance of the type</returns>
        public abstract object GetInstance(Type type, string propertyName);
    }
}
