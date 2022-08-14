namespace app.model.entities;

public record Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int StudentNumber { get; set; }
    public List<Grade> Grades = new List<Grade>();

    public override string ToString()
    {
        return $"{StudentNumber}: {FirstName} {LastName} -> {2}";
    }
}