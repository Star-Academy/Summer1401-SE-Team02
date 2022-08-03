namespace SampleLibrary.Queries;

public interface IQueryProcessor
{
    public IEnumerable<int> Process(string query, SortedDictionary<string, SortedSet<int>> indexedData, List<int> allDocIds);
}