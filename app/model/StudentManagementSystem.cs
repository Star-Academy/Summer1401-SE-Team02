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
        return Database.GetStudents().ToList().GroupJoin(Database.GetGrades(), s => s.StudentNumber,
            g => g.StudentNumber,
            (student, grades) => new
            {
                Average = grades.Select(g => g.Score).Average(),
                PersonalData = $"{student.StudentNumber} | {student.FirstName} {student.LastName}"
            }).OrderByDescending(p => p.Average).Select(p => $"{p.PersonalData} : {Math.Round(p.Average, 2)}").Take(n);
    }
}