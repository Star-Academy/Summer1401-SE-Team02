using SampleLibrary.DataProviding;
using SampleLibrary.enums;
using SampleLibrary.Normalizing;
using SampleLibrary.Queries;
using SampleLibrary.QueryProcessors;

namespace SampleLibrary;

public class SearchEngine
{
    private SortedDictionary<string, SortedSet<int>> _indexedData;
    private Dictionary<int, string> _docNames;
    private readonly INormalizer _normalizer;
    private readonly IQueryProcessor _queryProcessor;

    public SearchEngine(INormalizer normalizer)
    {
        _normalizer = normalizer;
        _docNames = new Dictionary<int, string>();
        _queryProcessor = new DefaultQueryProcessor();
        _indexedData = new SortedDictionary<string, SortedSet<int>>(StringComparer.OrdinalIgnoreCase);
    }

    public void IndexData(IData data)
    {
        var id = _docNames.Count();
        _docNames.Add(id, data.GetSource());
        foreach (var word in _normalizer.Normalize(data.GetContent()))
            AddWordToIndexedData(word, id);
    }

    private void AddWordToIndexedData(string word, int id)
    {
        if (_indexedData.ContainsKey(word)) _indexedData[word].Add(id);
        else _indexedData.Add(word, new SortedSet<int>() { id });
    }

    public IEnumerable<string> Search(IQuery query) =>
        MatchSourcesWithIds(_queryProcessor.Process(query.GetContent(), _indexedData, _docNames.Keys.ToList()));

    private List<string> MatchSourcesWithIds(IEnumerable<int> docIds)
    {
        return new List<string>(docIds.Select(x => _docNames[x]));
    }

    
}