namespace app.view;

public class ConsoleInterface : IUserInterface
{
    public void ShowList<T>(IEnumerable<dynamic> list)
    {
        foreach (var item in list) Console.WriteLine(item.ToString());
    }
}