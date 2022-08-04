using FluentAssertions;
using NSubstitute;
using SampleLibrary.DataProviding;
using SampleLibrary.Normalizing;
using SampleLibrary.Queries;


namespace SampleLibrary.Test;

public class SearchEngineTest
{
    private readonly SearchEngine _searchEngine;

    public SearchEngineTest()
    {
        _searchEngine = new SearchEngine(new BasicNormalizer());
        InitSearchEngine(_searchEngine);
    }

    private void InitSearchEngine(SearchEngine searchEngine)
    {
        var fakeData1 = Substitute.For<IData>();
        fakeData1.GetSource().ReturnsForAnyArgs("source1");
        fakeData1.GetContent().ReturnsForAnyArgs("simple test for search engine");
        
        var fakeData2 = Substitute.For<IData>();
        fakeData2.GetSource().ReturnsForAnyArgs("source2");
        fakeData2.GetContent().ReturnsForAnyArgs("more complex one for better queries, search:)");
        
        
        var fakeData3 = Substitute.For<IData>();
        fakeData3.GetSource().Returns("source3");
        fakeData3.GetContent().Returns("hello world is enough, believe it!");
        
        
        var fakeData = new List<IData>() { fakeData1, fakeData2, fakeData3 };
        foreach (var data in fakeData) searchEngine.IndexData(data);
    }

    #region SingleWordQuery test

    [Fact]
    public void Search_SingleWordQuery_ReturnIncludingSources()
    {
        var result = _searchEngine.Search(createFakeQuery("simple"));
        result.Should().Equal(new List<string>() { "source1" });
    }


    #endregion

    #region MultipleWordQuery test

    [Fact]
    public void Search_MultipleSimpleWords_ReturnIncludingSources()
    {
        var result = _searchEngine.Search(createFakeQuery("search engine"));
        result.Should().Equal(new List<string>() { "source1" });
    }

    [Fact]
    public void Search_MultiplePositiveWords_ReturnSourcesIncludingAtLeastOneOfThem()
    {
        var result = _searchEngine.Search(createFakeQuery("+search +complex"));
        result.Should().Equal(new List<string>() { "source1", "source2" });
    }

    [Fact]
    public void Search_MultipleNegativeWords_ReturnNonContainingSources()
    {
        var result = _searchEngine.Search(createFakeQuery("-better -believe"));
        result.Should().Equal(new List<string>() { "source1" });
    }

    [Theory]
    [MemberData(nameof(SearchQueryDataLowerCase))]
    [MemberData(nameof(SearchQueryDataUpperOrLowerCase))]
    public void Search_MultipleWordsWithUpperOrLowercaseCharacters_ReturnIncludingSources(string query,
        List<String> expected)
    {
        var result = _searchEngine.Search(createFakeQuery(query));
        result.Should().Equal(expected);
    }

    public static IEnumerable<object[]> SearchQueryDataUpperOrLowerCase =>
        new List<object[]>
        {
            new object[] { "+beTTer SeaRch", new List<String>() { "source2" } },
            new object[] { "+heLlo +COMplex -engIne", new List<String>() { "source2", "source3" } },
            new object[] { "+hellO +worlD -beliEve", new List<String>() },
            new object[] { "searCH +WOrld +BElieve ", new List<String>() },
        };

    public static IEnumerable<object[]> SearchQueryDataLowerCase =>
        new List<object[]>
        {
            new object[] { "+better search", new List<String>() { "source2" } },
            new object[] { "+hello +complex -engine", new List<String>() { "source2", "source3" } },
            new object[] { "+hello +world -believe", new List<String>() },
            new object[] { "search +world +believe ", new List<String>() },
        };

    #endregion
    
    private IQuery createFakeQuery(string query)
    {
        var fakeQuery = Substitute.For<IQuery>();
        fakeQuery.GetContent().Returns(query);
        return fakeQuery;
    }
}