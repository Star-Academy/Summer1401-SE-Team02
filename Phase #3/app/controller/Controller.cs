public class Controller
{


     public void RunProgram()
     {

          FileReader fileReader = new FileReader();
          StudentManagementSystem studentManagementSystem = new StudentManagementSystem();
          IDeserializer deserializer = new JsonDeserializer();
          IDataProvider fileDataProvider = new FileDataProvider(fileReader);
          View view = new View();

          List<Student> students = deserializer.Deserialize<Student>(fileDataProvider.GetData(Constants.STUDENTS_FILE_ADDRESS));
          List<Grade> grades = deserializer.Deserialize<Grade>(fileDataProvider.GetData(Constants.GRADES_FILE_ADDRESS));

          studentManagementSystem.RegisterStudents(students);
          studentManagementSystem.ImportGrades(grades);

          view.ShowList(studentManagementSystem.getNTopStudents(3));
     }

}