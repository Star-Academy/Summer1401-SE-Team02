using System.Text.Json;

namespace app.model.Deserializer;

public class JsonDeserializer : IDeserializer
{
    public T Deserialize<T>(string text) => JsonSerializer.Deserialize<T>(text);
}