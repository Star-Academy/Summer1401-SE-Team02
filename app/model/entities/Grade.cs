using System.ComponentModel.DataAnnotations.Schema;

namespace app.model.entities;

public record Grade
{
    public string Lesson { get; set; }
    public double Score { get; set; }
    [ForeignKey("Student")] public int StudentNumber { get; set; }
}