using app.model.database;
using app.model.entities;

namespace app.model;

public class StudentManagementSystem
{
    public IDatabase Database { init; get; }

    public void RegisterStudents(List<Student> students)
    {
        Database.AddStudents(students);
    }

    public void ImportGrades(List<Grade> grades)
    {
        Database.AddGrades(grades);
    }

    public IEnumerable<string> GetNTopStudents(int n)
    {
        return Database.GetStudents().OrderByDescending(s =>
                Database.GetGrades().Where(g => g.StudentNumber == s.StudentNumber).Select(g => g.Score).Average())
            .Take(n)
            .Select(s =>
                $"{s.StudentNumber} | {s.FirstName} {s.LastName}: {Database.GetGrades().Where(g => g.StudentNumber == s.StudentNumber).Select(g => g.Score).Average()}");
    }
}