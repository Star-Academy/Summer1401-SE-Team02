namespace SampleLibrary;

public interface IDataProvider
{
    public IEnumerable<Data> GetAllData();
}