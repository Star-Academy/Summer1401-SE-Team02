using app.model.entities;

namespace app.model.database;

public interface IDatabase
{
    public void AddStudents(List<Student> dataList);
    public void AddGrades(List<Grade> grades);
    public IEnumerable<Student> GetStudents();
    public IEnumerable<Grade> GetGrades();
    public bool isEmpty();
}