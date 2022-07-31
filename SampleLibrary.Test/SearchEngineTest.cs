using FluentAssertions;
using NSubstitute;
using SampleLibrary.Normalizing;
using SampleLibrary.Queries;

namespace SampleLibrary.Test;

public class SearchEngineTest
{
    private readonly IDataProvider _dataProvider;
    private readonly SearchEngine _searchEngine;

    public SearchEngineTest()
    {
        _dataProvider = Substitute.For<IDataProvider>();
        _searchEngine = new SearchEngine(new BasicNormalizer());
        _dataProvider.GetAllData().Returns(new List<Data>()
        {
            new Data("source1", "simple test for search engine"),
            new Data("source2", "more complex one for better queries, search:)"),
            new Data("source3", "hello world is enough, believe it!")
        });
        _searchEngine.ImportDataProviderData(_dataProvider);
    }

    #region SingleWordQuery test

    [Fact]
    public void Search_SingleWordQuery_ReturnIncludingSources()
    {
        var result = _searchEngine.Search(new SingleWordQuery("simple"));
        result.Should().Equal(new List<string>() { "source1" });
    }

    #endregion

    #region MultipleWordQuery test

    [Fact]
    public void Search_MultipleSimpleWords_ReturnIncludingSources()
    {
        var result = _searchEngine.Search(new MultipleWordsQuery("search engine"));
        result.Should().Equal(new List<string>() { "source1" });
    }

    [Fact]
    public void Search_MultiplePositiveWords_ReturnSourcesIncludingAtLeastOneOfThem()
    {
        var result = _searchEngine.Search(new MultipleWordsQuery("+search +complex"));
        result.Should().Equal(new List<string>() { "source1", "source2" });
    }

    [Fact]
    public void Search_MultipleNegativeWords_ReturnNonContainingSources()
    {
        var result = _searchEngine.Search(new MultipleWordsQuery("-better -believe"));
        result.Should().Equal(new List<string>() { "source1" });
    }

    [Theory]
    [MemberData(nameof(SearchQueryDataLowerCase))]
    [MemberData(nameof(SearchQueryDataUpperOrLowerCase))]
    public void Search_MultipleWordsWithUpperOrLowercaseCharacters_ReturnIncludingSources(string query,
        List<String> expected)
    {
        var result = _searchEngine.Search(new MultipleWordsQuery(query));
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
}