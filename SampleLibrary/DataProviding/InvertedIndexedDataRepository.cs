using SampleLibrary.Normalizing;

namespace SampleLibrary.DataProviding;

public class InvertedIndexedDataRepository : IIndexedDataRepository
{
    private readonly SortedDictionary<string, SortedSet<int>> _indexedData;
    private readonly Dictionary<int, string> _docNames;
    private readonly INormalizer _normalizer;
    
    public InvertedIndexedDataRepository()
    {
        _indexedData = new SortedDictionary<string, SortedSet<int>>(StringComparer.OrdinalIgnoreCase);
        _docNames = new Dictionary<int, string>();
        _normalizer = new BasicNormalizer();
    }
    public InvertedIndexedDataRepository(INormalizer normalizer)
    {
        _indexedData = new SortedDictionary<string, SortedSet<int>>(StringComparer.OrdinalIgnoreCase);
        _docNames = new Dictionary<int, string>();
        _normalizer = normalizer;
    }

    public void ImportData(Data data)
    {
        var id = _docNames.Count();
        _docNames.Add(id, data.Source);
        foreach (var word in _normalizer.Normalize(data.Content))
            AddWordToIndexedData(word, id);
    }

    private void AddWordToIndexedData(string word, int id)
    {
        if (_indexedData.ContainsKey(word)) _indexedData[word].Add(id);
        else _indexedData.Add(word, new SortedSet<int>() { id });
    }

    public IEnumerable<int> GetPostingList(string word) =>
        (_indexedData.ContainsKey(word)) ? _indexedData[word] : new SortedSet<int>();

    public IEnumerable<string> MatchSourcesWithIds(IEnumerable<int> docIds) =>
        new List<string>(docIds.Select(x => _docNames[x]));

    public IEnumerable<int> GetAllDocIds() => _docNames.Keys;
}