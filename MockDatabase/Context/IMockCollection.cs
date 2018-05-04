using System.Collections.Generic;

namespace MockDatabase.Context
{
    /// <summary>
    /// Used to add data to MockCollection instances
    /// </summary>

    public interface IMockCollection
    {
        string ClassName { get;}
        void AddData(List<object> data);
        void AddEntry(object entry);
    }
}
