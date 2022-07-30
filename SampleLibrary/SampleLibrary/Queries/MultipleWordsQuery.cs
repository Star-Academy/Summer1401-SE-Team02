using System.Text.RegularExpressions;
using SampleLibrary.enums;

namespace SampleLibrary.Queries;

public class MultipleWordsQuery : IQuery
{
    private readonly string _query;
    public MultipleWordsQuery(string query)
    {
        _query = query;
    }

    public List<string> GetMustIncludingWords()
    {
        return ExtractMatchedWords(Constants.MustIncludingWordsRegex);
    }

    public List<string> GetLeastOnceIncludingWords()
    {
        return ExtractMatchedWords(Constants.PositiveWordsRegex);

    }

    public List<string> GetExcludingWords()
    {
        return ExtractMatchedWords(Constants.NegativeWordsRegex);
    }

    private List<string> ExtractMatchedWords(string pattern)
    {
        var result = new List<string>();
        Regex regex = new Regex(pattern, RegexOptions.Compiled);
        foreach (var word in _query.Split())
            if (regex.IsMatch(word)) result.Add(regex.Match(word).Groups[1].Value);
        return result;
    }
}