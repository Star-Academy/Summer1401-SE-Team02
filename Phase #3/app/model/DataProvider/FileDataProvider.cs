public class FileDataProvider : IDataProvider
{
     private FileReader FileReader;

     public FileDataProvider(FileReader fileReader) => this.FileReader = fileReader;
     public string GetGradesData() => FileReader.ReadFile(@"resources/grades.json");
     public string GetStudentsData() => FileReader.ReadFile(@"resources/students.json");
}