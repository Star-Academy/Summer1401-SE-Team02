using SampleLibrary.Queries;

namespace SampleLibrary.QueryProcessors;

public class DefaultQueryProcessor : IQueryProcessor
{
    private ChainQueryHandler _triger; 
    public DefaultQueryProcessor()
    {
        _triger = new SimpleWordsHandler();
        _triger
            .SetNext(new PositiveWordsHandler())
            .SetNext(new NegativeWordHandler());
    }
    public IEnumerable<int> Process(string query, SortedDictionary<string, SortedSet<int>> indexedData, List<int> allDocIds)
    {
        return _triger.Process(query, indexedData, allDocIds);
    }
}