namespace app.model.entities;

public record Grade
{
    public string Lesson { get; set; }
    public double Score { get; set; }
    public int StudentNumber { get; set; }
}