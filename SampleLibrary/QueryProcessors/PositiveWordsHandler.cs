using Microsoft.VisualBasic;
using Constants = SampleLibrary.enums.Constants;

namespace SampleLibrary.QueryProcessors;

public class PositiveWordsHandler : ChainQueryHandler
{
    public override IEnumerable<int> Process(string query, SortedDictionary<string, SortedSet<int>> indexedData, List<int> allDocIds)
    {
        var positiveWords = new List<int>();
        if (!ExtractMatchedWords(query, Constants.PositiveWordsRegex).Any()) positiveWords = positiveWords.Union(allDocIds).ToList();
        
        foreach (var word in ExtractMatchedWords(query, Constants.PositiveWordsRegex))
            positiveWords = positiveWords.Union(GetPostingList(indexedData, word)).ToList();
        allDocIds = allDocIds.Intersect(positiveWords).ToList();
        return (Next != null) ? Next.Process(query, indexedData,allDocIds) : allDocIds;
    }
}