using SampleLibrary.DataProviding;
using SampleLibrary.Queries;
using SampleLibrary.QueryProcessors;

namespace SampleLibrary;

public class SearchEngine : ISearchEngine
{
    private readonly IQueryProcessor _queryProcessor;
    private readonly IIndexedDataRepository _indexedDataRepository;
    
    public SearchEngine()
    {
        _queryProcessor = new DefaultQueryProcessor();
        _indexedDataRepository = new InvertedIndexedDataRepository();
    }

    public IEnumerable<string> Search(Query query) =>
        _indexedDataRepository.MatchSourcesWithIds(_queryProcessor.Process(query.Content, _indexedDataRepository,
            _indexedDataRepository.GetAllDocIds().ToList()));

    public void ImportData(Data data)
    {
        _indexedDataRepository.ImportData(data);
    }
}