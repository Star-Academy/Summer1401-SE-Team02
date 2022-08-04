using SampleLibrary.DataProviding;

namespace SampleLibrary.Queries;

public interface IQueryProcessor
{
    public IEnumerable<int> Process(string query, IIndexedDataRepository indexedData, List<int> currentResult);
}