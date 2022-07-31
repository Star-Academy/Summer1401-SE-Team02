namespace SampleLibrary;

public class Data
{
    private readonly string _source;
    private readonly string _content;

    public Data(string source, string content)
    {
        _source = source;
        _content = content;
    }

    public string GetSource() => _source;
    public string GetContent() => _content;
}