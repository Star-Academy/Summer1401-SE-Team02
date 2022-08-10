namespace app.model.Deserializer;

public interface IDeserializer
{
    public T Deserialize<T>(string text);
}