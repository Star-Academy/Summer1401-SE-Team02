using Microsoft.AspNetCore.Mvc;
using SampleLibrary;
using SampleLibrary.DataProviding;
using SampleLibrary.Queries;

namespace ASP.net.Controllers;

[ApiController]
[Route("[controller]/[Action]")]
public class SearchController : ControllerBase
{
    private readonly ISearchEngine _searchEngine;

    public SearchController(ISearchEngine searchEngine)
    {
        _searchEngine = searchEngine;
    }

    [HttpGet]
    public IEnumerable<string> Search(string query)
    {
        return _searchEngine.Search(new Query { Content = query });
    }

    [HttpPost]
    public void AddContent(Data data)
    {
        _searchEngine.ImportData(data);
    }
}