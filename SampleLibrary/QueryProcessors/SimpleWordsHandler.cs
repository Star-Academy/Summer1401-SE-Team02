using SampleLibrary.enums;

namespace SampleLibrary.QueryProcessors;

public class SimpleWordsHandler : ChainQueryHandler
{
    public override IEnumerable<int> Process(string query, SortedDictionary<string, SortedSet<int>> indexedData, List<int> allDocIds)
    {
        foreach (var word in ExtractMatchedWords(query, Constants.MustIncludingWordsRegex))
            allDocIds = allDocIds.Intersect(GetPostingList(indexedData, word)).ToList();
        return (Next != null) ? Next.Process(query, indexedData,allDocIds) : allDocIds;
    }
}