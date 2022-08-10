using System.Net;

namespace app.model.rawDataProvider;

public class WebDataProvider : IRawDataProvider
{
    public string GetData(string path)
    {
        return new WebClient().DownloadString(path);
    }
}