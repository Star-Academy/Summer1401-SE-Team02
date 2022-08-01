namespace SampleLibrary.DataProviding;

public interface IDataProvider
{
    public IEnumerable<IData> GetAllData();
}