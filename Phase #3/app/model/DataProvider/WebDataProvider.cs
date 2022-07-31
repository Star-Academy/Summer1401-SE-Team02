using System.Net;
using app.model.DataProvider;

public class WebDataProvider : IDataProvider
{
          
     public string GetData(string path) =>
          new WebClient().DownloadString(path);

}