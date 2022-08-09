using SampleLibrary.DataProviding;
using SampleLibrary.Queries;
using SampleLibrary.QueryProcessors;

namespace SampleLibrary;

public class SearchEngine
{
    private readonly IQueryProcessor _queryProcessor;
    private readonly IIndexedDataRepository _indexedDataRepository;

    public SearchEngine(IIndexedDataRepository indexedDataRepository, IQueryProcessor queryProcessor)
    {
        _queryProcessor = queryProcessor;
        _indexedDataRepository = indexedDataRepository;
    }

    public SearchEngine(IIndexedDataRepository indexedDataRepository)
    {
        _queryProcessor = new DefaultQueryProcessor();
        _indexedDataRepository = indexedDataRepository;
    }

    public IEnumerable<string> Search(IQuery query) =>
        _indexedDataRepository.MatchSourcesWithIds(_queryProcessor.Process(query.GetContent(), _indexedDataRepository,
            _indexedDataRepository.GetAllDocIds().ToList()));
}