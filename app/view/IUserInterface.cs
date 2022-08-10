namespace app.view;

public interface IUserInterface
{
    public void ShowList<T>(IEnumerable<dynamic> list);
}