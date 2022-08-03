using System.Text.RegularExpressions;
using SampleLibrary.Queries;

namespace SampleLibrary.QueryProcessors;

public abstract class ChainQueryHandler : IQueryProcessor
{
    protected ChainQueryHandler? Next;

    public abstract IEnumerable<int> Process(string query, SortedDictionary<string, SortedSet<int>> indexedData,
        List<int> allDocIds);

    public ChainQueryHandler SetNext(ChainQueryHandler next)
    {
        Next = next;
        return next;
    }

    protected List<string> ExtractMatchedWords(string text, string pattern)
    {
        Regex regex = new Regex(pattern, RegexOptions.Compiled);
        return new List<string>(text.Split().Where(x => regex.IsMatch(x))
            .Select(x => regex.Match(x).Groups[1].Value));
    }

    protected IEnumerable<int> GetPostingList(SortedDictionary<string, SortedSet<int>> indexedData, string word) =>
        (indexedData.ContainsKey(word) ? indexedData[word] : new SortedSet<int>());
}