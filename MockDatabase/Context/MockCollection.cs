using System.Collections.Generic;
using System.Linq;

namespace MockDatabase.Context
{
    /// <summary>
    /// Represents an in-memory data table declared on a MockContext implementation
    /// </summary>
    /// <typeparam name="T">The type of the entity/model</typeparam>


    public class MockCollection<T> : List<T>, IMockCollection where T : class
    {
        public MockCollection()
        {
            ClassName = typeof(T).Name;
        }

        public string ClassName { get; private set; }

        public void AddData(List<object> data)
        {
            this.AddRange(data.Cast<T>());
        }

        public void AddEntry(object entry)
        {
            this.Add((T)entry);
        }
    }
}
