// using FluentAssertions;
// using NSubstitute;
// using SampleLibrary.DataProviding;
// using SampleLibrary.Normalizing;
// using SampleLibrary.Queries;
//
//
// namespace SampleLibrary.Test;
//
// public class SearchEngineTest
// {
//     private readonly SearchEngine _searchEngine;
//
//     public SearchEngineTest()
//     {
//         IIndexedDataRepository indexedDataRepository = new InvertedIndexedDataRepository(new BasicNormalizer());
//         InitSearchEngine(indexedDataRepository);
//         _searchEngine = new SearchEngine(indexedDataRepository);
//     }
//
//     private void InitSearchEngine(IIndexedDataRepository indexedDataRepository)
//     {
//         var fakeData1 = new Data() { Source = "source1", Content = "simple test for search engine" };
//         var fakeData2 = new Data() { Source = "source2", Content = "more complex one for better queries, search:)" };
//         var fakeData3 = new Data() { Source = "source3", Content = "hello world is enough, believe it!" };
//
//         var fakeData = new List<Data>() { fakeData1, fakeData2, fakeData3 };
//         foreach (var data in fakeData) indexedDataRepository.ImportData(data);
//     }
//
//     #region SingleWordQuery test
//
//     [Fact]
//     public void Search_SingleWordQuery_ReturnIncludingSources()
//     {
//         var expected = new List<string>() { "source1" };
//         var result = _searchEngine.Search(new Query(){Content = "simple"});
//         result.Should().Equal(expected);
//     }
//
//     #endregion
//
//     #region MultipleWordQuery test
//
//     [Fact]
//     public void Search_MultipleSimpleWords_ReturnIncludingSources()
//     {
//         var expected = new List<string>() { "source1" };
//         var result = _searchEngine.Search(new Query(){Content = "search engine"});
//         result.Should().Equal(expected);
//     }
//
//     [Fact]
//     public void Search_MultiplePositiveWords_ReturnSourcesIncludingAtLeastOneOfThem()
//     {
//         var expected = new List<string>() { "source1", "source2" };
//         var result = _searchEngine.Search(new Query(){Content = "+search +complex"});
//         result.Should().Equal(expected);
//     }
//
//     [Fact]
//     public void Search_MultipleNegativeWords_ReturnNonContainingSources()
//     {
//         var expected = new List<string>() { "source1" };
//         var result = _searchEngine.Search(new Query(){Content = "-better -believe"});
//         result.Should().Equal(expected);
//     }
//
//     [Theory]
//     [MemberData(nameof(SearchQueryDataLowerCase))]
//     [MemberData(nameof(SearchQueryDataUpperOrLowerCase))]
//     public void Search_MultipleWordsWithUpperOrLowercaseCharacters_ReturnIncludingSources(string query,
//         List<String> expected)
//     {
//         var result = _searchEngine.Search(new Query(){Content = query});
//         result.Should().Equal(expected);
//     }
//
//     public static IEnumerable<object[]> SearchQueryDataUpperOrLowerCase =>
//         new List<object[]>
//         {
//             new object[] { "+beTTer SeaRch", new List<String>() { "source2" } },
//             new object[] { "+heLlo +COMplex -engIne", new List<String>() { "source2", "source3" } },
//             new object[] { "+hellO +worlD -beliEve", new List<String>() },
//             new object[] { "searCH +WOrld +BElieve ", new List<String>() },
//         };
//
//     public static IEnumerable<object[]> SearchQueryDataLowerCase =>
//         new List<object[]>
//         {
//             new object[] { "+better search", new List<String>() { "source2" } },
//             new object[] { "+hello +complex -engine", new List<String>() { "source2", "source3" } },
//             new object[] { "+hello +world -believe", new List<String>() },
//             new object[] { "search +world +believe ", new List<String>() },
//         };
//
//     #endregion
//
// }