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
        Regex regex = new Regex(pattern, RegexOptions.Compiled);
        return new List<string>(_query.Split().Where(x => regex.IsMatch(x))
            .Select(x => regex.Match(x).Groups[1].Value));
    }
}