using SampleLibrary.DataProviding;

namespace SampleLibrary.QueryProcessors;

public class NegativeWordHandler : ChainQueryHandler
{
    public override IEnumerable<int> Process(string query, IIndexedDataRepository indexedData,
        List<int> currentResult)
    {
        var negativeWords = new List<int>();

        foreach (var word in ExtractMatchedWords(query, enums.Constants.NegativeWordsRegex))
            negativeWords = negativeWords.Union(indexedData.GetPostingList(word)).ToList();
        currentResult = currentResult.Except(negativeWords).ToList();
        return (Next != null) ? Next.Process(query, indexedData, currentResult) : currentResult;
    }
}