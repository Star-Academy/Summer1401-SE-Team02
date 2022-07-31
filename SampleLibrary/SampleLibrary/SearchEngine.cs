using SampleLibrary.enums;
using SampleLibrary.Normalizing;
using SampleLibrary.Queries;

namespace SampleLibrary;

public class SearchEngine
{
    private SortedDictionary<string, SortedSet<int>> _indexedData;
    private Dictionary<int, string> _docNames;
    private readonly INormalizer _normalizer;
    
    public SearchEngine(INormalizer normalizer)
    {
        _normalizer = normalizer;
        _docNames = new Dictionary<int, string>();
        _indexedData = new SortedDictionary<string, SortedSet<int>>(StringComparer.OrdinalIgnoreCase);
    }

    public void ImportDataProviderData(IDataProvider dataProvider)
    {
        foreach (var data in dataProvider.GetAllData()) IndexData(data);
    }

    private void IndexData(Data data)
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

    public IEnumerable<string> Search(IQuery query) => MatchSourcesWithIds(ProcessQuery(query));

    private List<string> MatchSourcesWithIds(IEnumerable<int> docIds)
    {
        return new List<string>(docIds.Select(x => _docNames[x]));
    }

    private IEnumerable<int> ProcessQuery(IQuery query)
    {
        var positiveWords = new SortedSet<int>();
        if (!query.GetLeastOnceIncludingWords().Any()) positiveWords.UnionWith(_docNames.Keys);

        var includingWords = new SortedSet<int>();
        includingWords.UnionWith(_docNames.Keys);

        var negativeWords = new SortedSet<int>();

        foreach (var word in query.GetMustIncludingWords()) includingWords.IntersectWith(GetPostingList(word));
        foreach (var word in query.GetLeastOnceIncludingWords()) positiveWords.UnionWith(GetPostingList(word));
        foreach (var word in query.GetExcludingWords()) negativeWords.UnionWith(GetPostingList(word));

        return includingWords.Intersect(positiveWords).Except(negativeWords);
    }

    private IEnumerable<int> GetPostingList(string word)
    {
        return (_indexedData.ContainsKey(word) ? _indexedData[word] : new SortedSet<int>());
    }
}