using System.Collections.Generic;

namespace Cosmo.MockDatabase.Context
{
    public class MockCollection<TEntity> : List<TEntity> where TEntity : class
    {
    }
}
