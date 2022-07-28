using app.model;
using app.model.DataProvider;

public class FileDataProvider : IDataProvider
{
     private FileReader FileReader;

     public FileDataProvider(FileReader fileReader) => this.FileReader = fileReader;
     public string GetData(string path) => FileReader.ReadFile(path);
}