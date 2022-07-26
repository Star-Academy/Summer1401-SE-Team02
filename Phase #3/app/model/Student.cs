public class Student
{    
     public List<Grade> Grades {get; }
     public string FirstName {get; set;}
     public string LastName {get; set;}
     public int StudentNumber {get; set;}

     public Student() => this.Grades = new List<Grade>();
     public void AddGrade(Grade grade) => this.Grades.Add(grade);

     public override string ToString() => $"{StudentNumber}: {FirstName} {LastName} -> {Math.Round(this.Average(), 2)}";
     public double Average() => Grades.Select(g => g.Score).Average();
}