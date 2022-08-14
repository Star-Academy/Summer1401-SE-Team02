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
    public IEnumerable<string> Get(string query) => _searchEngine.Search(new Query { Content = query });

        [HttpPost]
    public void AddContent(string source, string content)
    {
        _searchEngine.ImportData(new Data { Source = source, Content = content });
    }
}