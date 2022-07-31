namespace app.model;

public record Student
{
    public List<Grade> Grades { get; } = new List<Grade>();
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int StudentNumber { get; set; }

    public void RegisterGrade(Grade grade) => Grades.Add(grade);

    public override string ToString() =>
        $"{StudentNumber}: {FirstName} {LastName} -> {Math.Round(this.GetAverageOfGrades(), 2)}";

    public double GetAverageOfGrades() => Grades.Select(g => g.Score).Average();
}