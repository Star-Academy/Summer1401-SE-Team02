using app.model;
using app.model.DataProvider;
using app.model.Deserializer;
using app.view;

namespace app.controller;

public class Program
{
    public void Start()
    {
        FileReader fileReader = new FileReader();
        StudentManagementSystem studentManagementSystem = new StudentManagementSystem();
        IDeserializer deserializer = new JsonDeserializer();
        IDataProvider dataProvider = new WebDataProvider();
        UserInterface userInterface = new UserInterface();

        List<Student> students =
            deserializer.Deserialize<List<Student>>(dataProvider.GetData(Constants.StudentsFileLink));
        List<Grade> grades = deserializer.Deserialize<List<Grade>>(dataProvider.GetData(Constants.GradesFileLink));

        studentManagementSystem.RegisterStudents(students);
        studentManagementSystem.ImportGrades(grades);

        userInterface.ShowList(studentManagementSystem.GetNTopStudents(3));
    }
}