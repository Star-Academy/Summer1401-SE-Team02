using System.Text.Json;

public class JsonDeserializer : IDeserializer
{
     public List<T> Deserialize<T>(string text) => JsonSerializer.Deserialize<List<T>>(text);
}