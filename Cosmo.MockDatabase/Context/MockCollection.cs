using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmo.MockDatabase.Context
{
    public class MockCollection<TEntity> : List<TEntity> where TEntity : class
    {
    }
}
