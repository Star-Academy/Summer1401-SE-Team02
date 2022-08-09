using Microsoft.VisualBasic;
using SampleLibrary.DataProviding;
using Constants = SampleLibrary.enums.Constants;

namespace SampleLibrary.QueryProcessors;

public class PositiveWordsHandler : ChainQueryHandler
{
    public override IEnumerable<int> Process(string query, IIndexedDataRepository indexedData, List<int> currentResult)
    {
        var positiveWords = new List<int>();
        if (!ExtractMatchedWords(query, Constants.PositiveWordsRegex).Any()) positiveWords = positiveWords.Union(currentResult).ToList();
        
        foreach (var word in ExtractMatchedWords(query, Constants.PositiveWordsRegex))
            positiveWords = positiveWords.Union(indexedData.GetPostingList(word)).ToList();
        currentResult = currentResult.Intersect(positiveWords).ToList();
        return (Next != null) ? Next.Process(query, indexedData,currentResult) : currentResult;
    }
}