namespace app.model.entities;

public record Student
{
    public double Average { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int StudentNumber { get; set; }

    public override string ToString()
    {
        return $"{StudentNumber}: {FirstName} {LastName} -> {Math.Round(Average, 2)}";
    }
}