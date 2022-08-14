using SampleLibrary.DataProviding;
using SampleLibrary.Queries;

namespace SampleLibrary;

public interface ISearchEngine
{
    public IEnumerable<string> Search(Query qyQuery);
}