namespace SampleLibrary.Queries;

public interface IQuery
{
    public List<string> GetMustIncludingWords();
    public List<string> GetLeastOnceIncludingWords();
    public List<string> GetExcludingWords();
}