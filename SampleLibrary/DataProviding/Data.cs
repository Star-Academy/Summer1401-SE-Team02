namespace SampleLibrary.DataProviding;

public record Data
{
    public string Source { get; init; } = string.Empty;
    public string Content { get; init; } = string.Empty;
}