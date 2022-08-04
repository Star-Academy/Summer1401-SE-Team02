// namespace SampleLibrary.Queries;
//
// public class DynamicQueryProcessor : IQueryProcessor
// {
//     private List<Func<string, List<int>, List<int>>> _steps = new List<Func<string, List<int>, List<int>>>();
//
//     public DynamicQueryProcessor NextStep(Func<string, List<int>, List<int>> func)
//     {
//         _steps.Add(func);
//         return this;
//     }
//
//     public IEnumerable<int> Process(string query, Dictionary<string, List<int>> indexedData)
//     {
//         var result = new List<int>();
//         foreach (Func<string, List<int>, List<int>> func in _steps) result = func(query, result);
//         return result;
//     }
//     
//     
// }