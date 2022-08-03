using SampleLibrary.Queries;

namespace SampleLibrary.Test.model;

public class Query : IQuery
{
    private readonly string _query;
    public Query(string query) => _query = query;
    public string GetContent() => _query;
}