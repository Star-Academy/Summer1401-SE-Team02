using app.model;
using app.model.DataProvider;
using app.model.Deserializer;
using app.view;

namespace app.controller;

public class Program
{
    public void Start()
    {
        var fileReader = new FileReader();
        var studentManagementSystem = new StudentManagementSystem();
        var deserializer = new JsonDeserializer();
        var dataProvider = new WebDataProvider();
        var userInterface = new UserInterface();

        var students =
            deserializer.Deserialize<List<Student>>(dataProvider.GetData(Constants.StudentsFileLink));
        var grades = deserializer.Deserialize<List<Grade>>(dataProvider.GetData(Constants.GradesFileLink));

        studentManagementSystem.RegisterStudents(students);
        studentManagementSystem.ImportGrades(grades);

        userInterface.ShowList(studentManagementSystem.GetNTopStudents(3));
    }
}