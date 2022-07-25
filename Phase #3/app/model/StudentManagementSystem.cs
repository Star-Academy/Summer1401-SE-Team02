using System.Linq;
public class StudentManagementSystem
{
     public Dictionary<int, Student> students {get; init;}

     public StudentManagementSystem()
     {
          this.students = new Dictionary<int, Student>();
     }

     public void addStudent(Student student) => this.students.Add(student.StudentNumber, student);
     // public List<Student> getTopNStudents(int n) => 

     public void importGrades(List<Grade> grades)
     {
          foreach (Grade grade in grades) students[grade.StudentNumber].addGrade(grade);
     }     

     public IEnumerable<Student> getNTopStudents(int n)
          => students.Values.ToList().OrderBy(s => s.Average()).Take(n);
}