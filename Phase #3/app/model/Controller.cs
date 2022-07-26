public class Controller
{


     public void RunProgram()
     {

          FileReader fileReader = new FileReader();
          StudentManagementSystem studentManagementSystem = new StudentManagementSystem();
          IDeserializer deserializer = new JsonDeserializer();
          IDataProvider fileDataProvider = new FileDataProvider(fileReader);
          View view = new View();

          List<Student> students = deserializer.Deserialize<Student>(fileDataProvider.GetStudentsData());
          List<Grade> grades = deserializer.Deserialize<Grade>(fileDataProvider.GetGradesData());

          RegisterStudents(students, studentManagementSystem);
          studentManagementSystem.ImportGrades(grades);

          view.ShowList(studentManagementSystem.getNTopStudents(3));
     }


     private void RegisterStudents(List<Student> students, StudentManagementSystem studentManagementSystem)
     {
          foreach (Student s in students) studentManagementSystem.RegisterStudent(s);
     }


}