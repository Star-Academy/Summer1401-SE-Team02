public class Controller
{

     string StudentsFile = @"resources/students.json";
     string GradesFile = @"resources/grades.json";

     public void RunProgram()
     {

          FileReader fileReader = new FileReader();
          StudentManagementSystem studentManagementSystem = new StudentManagementSystem();
          IDeserializer deserializer = new JsonDeserializer();

          List<Student> students = deserializer.Deserialize<Student>(fileReader.ReadFile(StudentsFile));
          List<Grade> grades = deserializer.Deserialize<Grade>(fileReader.ReadFile(GradesFile));

          RegisterStudents(students, studentManagementSystem);
          studentManagementSystem.ImportGrades(grades);

          foreach(Student student in studentManagementSystem.getNTopStudents(3)) Console.WriteLine(student);

     }


     private void RegisterStudents(List<Student> students, StudentManagementSystem studentManagementSystem)
     {
          foreach (Student s in students) studentManagementSystem.RegisterStudent(s);
     }


}