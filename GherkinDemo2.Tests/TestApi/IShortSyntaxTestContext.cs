namespace GherkinDemo2.Tests.TestApi
{
    public interface IShortSyntaxTestContext
    {
        object this[string key] { get; set; }
        bool ContainsKey(string key);
    }
}