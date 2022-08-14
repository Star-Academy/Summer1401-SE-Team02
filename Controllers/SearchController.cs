
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
    public IEnumerable<string> Get(string query)
    {
        var q = new Query() { Content = query };
        Console.WriteLine($"getting: {query}  >> result:{_searchEngine.Search(q).ToList()}");
        return _searchEngine.Search(q);
    }
    
    [HttpPost]
    public void AddContent(string source, string content)
    {
        _searchEngine.ImportData(new Data(){Source = source, Content = content});
    }




    
}