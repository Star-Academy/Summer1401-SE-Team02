// using System.Reflection.Metadata;
// using System.Text.RegularExpressions;
// using SampleLibrary.enums;
//
// namespace SampleLibrary.Queries;
//
// public class DefaultQueryProcessor : IQueryProcessor
// {
//     private string _query;
//
//     public IEnumerable<int> Process(string query, SortedDictionary<string, SortedSet<int>> indexedData, List<int> allDocs)
//     {
//         // var positiveWords = new SortedSet<int>();
//         // if (!ExtractMatchedWords(Constants.PositiveWordsRegex).Any()) positiveWords.UnionWith(allDocs);
//         //
//         // var includingWords = new SortedSet<int>();
//         // includingWords.UnionWith(allDocs);
//         //
//         // var negativeWords = new SortedSet<int>();
//         //
//         // foreach (var word in query.GetMustIncludingWords()) includingWords.IntersectWith(GetPostingList(word));
//         // foreach (var word in query.GetLeastOnceIncludingWords()) positiveWords.UnionWith(GetPostingList(word));
//         // foreach (var word in query.GetExcludingWords()) negativeWords.UnionWith(GetPostingList(word));
//         //
//         // return includingWords.Intersect(positiveWords).Except(negativeWords);
//     }
//     
//     private List<string> ExtractMatchedWords(string pattern)
//     {
//         Regex regex = new Regex(pattern, RegexOptions.Compiled);
//         return new List<string>(_query.Split().Where(x => regex.IsMatch(x))
//             .Select(x => regex.Match(x).Groups[1].Value));
//     }
//     
// }