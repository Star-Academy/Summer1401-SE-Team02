namespace searchEngineApp.UserInterface;

public class ConsoleInterface : IInterface
{
    public void ShowSearchResult(IEnumerable<string> result)
    {
        if (result.Any())
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("+");
            Console.ResetColor();
            Console.WriteLine($" number of results: {result.Count()}");
            Console.WriteLine(string.Join(", ", result));

        }else
        {
            PrintError("nothing to show ...");
        }

    }

    public string? GetSearchText()
    {
        PrintSearchEngineLogo();
        var searchInput = string.Empty;
        while ((((searchInput = Console.ReadLine())!)).Equals(string.Empty))
        {
            PrintError("please fill me, I am empty :(");
            PrintSearchEngineLogo();
        }
        return searchInput;
    }

    private void PrintError(string message)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("! ");
        Console.ResetColor();
        Console.WriteLine(message);
    }

    private void PrintSearchEngineLogo()
    {

        ColorFulPrint(
            Tuple.Create(ConsoleColor.Blue, "G"),
            Tuple.Create(ConsoleColor.Red, "O"),
            Tuple.Create(ConsoleColor.Yellow, "O"),
            Tuple.Create(ConsoleColor.Blue, "G"),
            Tuple.Create(ConsoleColor.Green, "L"),
            Tuple.Create(ConsoleColor.Red, "E\t")
            );
        Console.ResetColor();
    }

    private void ColorFulPrint(params Tuple<ConsoleColor, string>[] colorfulMessages)
    {
        foreach (var pair in colorfulMessages)
        {
            Console.ForegroundColor = pair.Item1;
            Console.Write(pair.Item2);
        }
    }
}