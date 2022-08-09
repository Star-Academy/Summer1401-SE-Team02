using SampleLibrary;
using SampleLibrary.DataProviding;
using SampleLibrary.Queries;

static class Program
{
    public static void Main(string[] args)
    {
        // INormalizer normalizer = new BasicNormalizer();
        IIndexedDataRepository dataRepository = new InvertedIndexedDataRepository();
        ImportDataToRepository(dataRepository);
        SearchEngine searchEngine = new SearchEngine(dataRepository);
        var result = searchEngine.Search(new Query(){Content = Console.ReadLine()!});
        Console.WriteLine(string.Join(", ", result));
    }
    
    
    private static void ImportDataToRepository(IIndexedDataRepository repository)
    {
        var fakeData1 = new Data() { Source = "source1", Content = "simple test for search engine" };
        var fakeData2 = new Data() { Source = "source2", Content = "more complex one for better queries, search:)" };
        var fakeData3 = new Data() { Source = "source3", Content = "hello world is enough, believe it!" };

        var fakeData = new List<Data>() { fakeData1, fakeData2, fakeData3 };
        foreach (var data in fakeData) repository.ImportData(data);
    }
}