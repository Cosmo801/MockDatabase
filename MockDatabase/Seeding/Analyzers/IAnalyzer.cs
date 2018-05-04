namespace MockDatabase.Seeding.Analyzers
{
    /// <summary>
    /// IAnalyzer are used to produce random and hopefully relevant data for used in default seeding
    /// </summary>

    public interface IAnalyzer
    {
        object GetObject();
        string PropertyName { get; set; }
        

    }
}
