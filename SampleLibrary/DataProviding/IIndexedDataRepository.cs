namespace SampleLibrary.DataProviding;

public interface IIndexedDataRepository
{
    public void ImportData(Data data);
    public IEnumerable<int> GetPostingList(string word);
    public IEnumerable<string> MatchSourcesWithIds(IEnumerable<int> docIds);
    public IEnumerable<int> GetAllDocIds();
}