using System.Text.Json;

namespace app.model.Deserializer;

public class JsonDeserializer : IDeserializer
{
    public T Deserialize<T>(string text)
    {
        return JsonSerializer.Deserialize<T>(text);
    }
}