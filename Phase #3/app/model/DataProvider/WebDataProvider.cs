using System.Net;

public class WebDataProvider : IDataProvider
{
          
     public string GetGradesData() =>
          new WebClient().DownloadString("https://docs.code-star.ir/assets/files/scores-76885bff66d5238dfd0661c6ac6d74fc.json");

     public string GetStudentsData() =>
          new WebClient().DownloadString("https://docs.code-star.ir/assets/files/students-7e48b111d2450c4a8dc0ffe4fc912c36.json");

}