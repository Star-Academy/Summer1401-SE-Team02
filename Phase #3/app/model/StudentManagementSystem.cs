using System.Linq;
public class StudentManagementSystem
{
     public Dictionary<int, Student> students {get; init;}

     public StudentManagementSystem()
     {
          this.students = new Dictionary<int, Student>();
     }

     public void RegisterStudent(Student student) => this.students.Add(student.StudentNumber, student);
     public void RegisterStudents(List<Student> students)
     {
          foreach (Student s in students) RegisterStudent(s);
     }
     
     public void ImportGrades(List<Grade> grades)
     {
          foreach (Grade grade in grades) students[grade.StudentNumber].AddGrade(grade);
     }     

     public IEnumerable<Student> getNTopStudents(int n)
          => students.Values.ToList().OrderByDescending(s => s.Average()).Take(n);
}