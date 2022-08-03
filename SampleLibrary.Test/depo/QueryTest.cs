// using FluentAssertions;
// using SampleLibrary.Queries;
// using SampleLibrary.Test.model;
//
// namespace SampleLibrary.Test;
//
// public class QueryTest
// {
//     #region SingleQueryTest
//
//     [Theory]
//     [InlineData("test")]
//     [InlineData("new")]
//     public void GetMustIncludingWords_SingleWordQuery_ReturnTheListContainingTheInputWord(string singleWord)
//     {
//         var expected = new List<string>() { singleWord };
//         var result = new Query(singleWord).GetMustIncludingWords();
//         result.Should().Equal(expected);
//     }
//
//     [Theory]
//     [InlineData("test")]
//     [InlineData("new")]
//     public void GetLeastOnceIncludingWords_SingleWordQuery_ReturnEmptyList(string singleWord)
//     {
//         var result = new SingleWordQuery(singleWord).GetLeastOnceIncludingWords();
//         result.Should().BeEmpty();
//     }
//
//     [Theory]
//     [InlineData("test")]
//     [InlineData("new")]
//     public void GetExcludingWords_SingleWordQuery_ReturnEmptyList(string singleWord)
//     {
//         var result = new SingleWordQuery(singleWord).GetExcludingWords();
//         result.Should().BeEmpty();
//     }
//
//     #endregion
//
//     #region MultipleWordsQuery
//
//     [Theory]
//     [InlineData("simple words query")]
//     [InlineData("longer test for multiple word query")]
//     public void GetMustIncludingWords_SingleTypeQuery_ReturnListOfWords(string query)
//     {
//         var expected = query.Split().ToList();
//         var result = new Query(query).GetMustIncludingWords();
//         result.Should().Equal(expected);
//     }
//
//     [Theory]
//     [InlineData("multiple +words -query")]
//     [InlineData("longer -test -for multiple word +query")]
//     public void GetMustIncludingWords_MultipleTypeQuery_ReturnListOfMustIncludingWords(string query)
//     {
//         var expected = query.Split().ToList().Where(x => !(x.StartsWith("+") || x.StartsWith("-")));
//         var result = new Query(query).GetMustIncludingWords();
//         result.Should().Equal(expected);
//     }
//
//     [Fact]
//     public void GetMustIncludingWords_QueryWithoutSimpleWord_ReturnEmptyList()
//     {
//         var result = new Query("+test -without +simple -word").GetMustIncludingWords();
//         result.Should().BeEmpty();
//     }
//
//     [Theory]
//     [InlineData("multiple +words -query")]
//     [InlineData("longer -test -for multiple word +query")]
//     public void GetLeastOnceIncludingWords_MultipleTypeQuery_ReturnListOfPositiveWords(string query)
//     {
//         var expected = query.Split().ToList().Where(x => x.StartsWith("+")).Select(x => x.Substring(1));
//         var result = new Query(query).GetLeastOnceIncludingWords();
//         result.Should().Equal(expected);
//     }
//
//     [Theory]
//     [InlineData("+single +type +query")]
//     [InlineData("+longer +test +for +single +type +query")]
//     public void GetLeastOnceIncludingWords_SingleTypeQuery_ReturnListOfAllWords(string query)
//     {
//         var expected = query.Split().ToList().Where(x => x.StartsWith("+")).Select(x => x.Substring(1));
//         var result = new Query(query).GetLeastOnceIncludingWords();
//         result.Should().Equal(expected);
//     }
//
//
//     [Fact]
//     public void GetLeastOnceIncludingWords_NoPositiveWordQuery_ReturnEmptyList()
//     {
//         var result = new Query("test -without positive -word").GetLeastOnceIncludingWords();
//         result.Should().BeEmpty();
//     }
//
//     [Theory]
//     [InlineData("multiple +words -query")]
//     [InlineData("longer -test -for multiple word +query")]
//     public void GetExcludingWords_MultipleTypeQuery_ReturnListOfNegativeWords(string query)
//     {
//         var expected = query.Split().ToList().Where(x => x.StartsWith("-")).Select(x => x.Substring(1));
//         var result = new Query(query).GetExcludingWords();
//         result.Should().Equal(expected);
//     }
//
//
//     [Theory]
//     [InlineData("-single -type -query")]
//     [InlineData("-longer -test -for -single -type -query")]
//     public void GetExcludingWords_SingleTypeQuery_ReturnListOfAllWords(string query)
//     {
//         var expected = query.Split().ToList().Select(x => x.Substring(1));
//         var result = new Query(query).GetExcludingWords();
//         result.Should().Equal(expected);
//     }
//
//     [Fact]
//     public void GetExcludingWords_QueryWithoutNegativeWord_ReturnEmptyList()
//     {
//         var result = new Query("test +without positive +word").GetExcludingWords();
//         result.Should().BeEmpty();
//     }
//
//     #endregion
// }