namespace SampleLibrary.QueryProcessors;

public class NegativeWordHandler : ChainQueryHandler
{
    public override IEnumerable<int> Process(string query, SortedDictionary<string, SortedSet<int>> indexedData,
        List<int> allDocIds)
    {
        var negativeWords = new List<int>();

        foreach (var word in ExtractMatchedWords(query, enums.Constants.NegativeWordsRegex))
            negativeWords = negativeWords.Union(GetPostingList(indexedData, word)).ToList();
        allDocIds = allDocIds.Except(negativeWords).ToList();
        return (Next != null) ? Next.Process(query, indexedData, allDocIds) : allDocIds;
    }
}