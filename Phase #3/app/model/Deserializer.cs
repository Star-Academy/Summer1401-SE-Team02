using System.Text.Json;

public class Deserializer
{
     public List<T> deserialize<T>(string json) => JsonSerializer.Deserialize<List<T>>(json);
}