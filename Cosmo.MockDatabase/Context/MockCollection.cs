using System.Collections.Generic;

namespace Cosmo.MockDatabase.Context
{
    /// <summary>
    /// The gateway to the mock entity, all the entities are defined on a MockContext as MockCollections
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class MockCollection<TEntity> : List<TEntity> where TEntity : class
    {
    }
}
