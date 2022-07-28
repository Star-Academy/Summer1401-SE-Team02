namespace app.model;

public class StudentManagementSystem
{
    private Dictionary<int, Student> Students { get; set; }

    public StudentManagementSystem()
    {
        this.Students = new Dictionary<int, Student>();
    }

    public void RegisterStudents(List<Student> students)
    {
        Students = students.ToDictionary(x => x.StudentNumber, x => x);
    }

    public void ImportGrades(List<Grade> grades)
    {
        foreach (Grade grade in grades) Students[grade.StudentNumber].RegisterGrade(grade);
    }

    public IEnumerable<Student> GetNTopStudents(int n)
        => Students.Values.ToList().OrderByDescending(s => s.GetAverage()).Take(n);
}