using System.Reflection.Metadata.Ecma335;

namespace SampleLibrary.Queries;

public class SingleWordQuery : IQuery
{
    private List<string> _mustIncludingWords;

    public SingleWordQuery(string query) => _mustIncludingWords = new List<string>() { query };

    public List<string> GetMustIncludingWords() => _mustIncludingWords;

    public List<string> GetLeastOnceIncludingWords() => new List<string>();

    public List<string> GetExcludingWords() => new List<string>();
}