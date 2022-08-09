namespace SampleLibrary.Normalizing;

public interface INormalizer
{
    public List<string> Normalize(string data);
    public List<string> Tokenize(string query);
}