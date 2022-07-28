namespace app.model;

public class FileReader
{
    public string ReadFile(string path) => File.ReadAllText(path);
}