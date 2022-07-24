public class Grade
{
     public string Lesson {get; set;}
     public double Score {get; set;}
     public int StudentNumber {get; set;}

     public override string ToString() => $"{StudentNumber} | {Lesson}: {Score}";
}