namespace searchEngineApp.UserInterface;

public interface IInterface
{
    public void ShowSearchResult(IEnumerable<string> result);
    public string? GetSearchText();
}