using SampleLibrary.DataProviding;
using SampleLibrary.Queries;

namespace SampleLibrary.QueryProcessors;

public class DefaultQueryProcessor : IQueryProcessor
{
    private readonly ChainQueryHandler _triger;

    public DefaultQueryProcessor()
    {
        _triger = new SimpleWordsHandler();
        _triger
            .SetNext(new PositiveWordsHandler())
            .SetNext(new NegativeWordHandler());
    }

    public IEnumerable<int> Process(string query, IIndexedDataRepository indexedData, List<int> currentResult)
    {
        return _triger.Process(query, indexedData, currentResult);
    }
}