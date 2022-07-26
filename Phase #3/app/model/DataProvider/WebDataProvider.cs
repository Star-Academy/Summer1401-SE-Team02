using System.Net;

public class WebDataProvider : IDataProvider
{
          
     public string GetData(string path) =>
          new WebClient().DownloadString(path);

}