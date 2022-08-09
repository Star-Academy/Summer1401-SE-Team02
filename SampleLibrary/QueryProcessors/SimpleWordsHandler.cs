using SampleLibrary.DataProviding;
using SampleLibrary.enums;

namespace SampleLibrary.QueryProcessors;

public class SimpleWordsHandler : ChainQueryHandler
{
    public override IEnumerable<int> Process(string query, IIndexedDataRepository indexedData, List<int> currentResult)
    {
        foreach (var word in ExtractMatchedWords(query, Constants.MustIncludingWordsRegex))
            currentResult = currentResult.Intersect(indexedData.GetPostingList(word)).ToList();
        return (Next != null) ? Next.Process(query, indexedData, currentResult) : currentResult;
    }
}