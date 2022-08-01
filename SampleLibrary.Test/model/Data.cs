using SampleLibrary.DataProviding;

namespace SampleLibrary.Test;

public class Data : IData
{
    public string _source { get; set; }
    public string _content { get; set; }

    public string GetSource() => _source;
    public string GetContent() => _content;
}