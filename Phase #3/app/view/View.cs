public class View
{
     public void ShowList<T>(IEnumerable<T> enumerable)
     {
          foreach(var item in enumerable) Console.WriteLine(item.ToString());
     }
}