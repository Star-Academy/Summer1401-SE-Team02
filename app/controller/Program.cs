using app.model;
using app.model.database;
using app.model.Deserializer;
using app.model.entities;
using app.model.rawDataProvider;
using app.view;

namespace app.controller;

public class Program
{
    public void Start()
    {
        var database = new PostgresqlDatabase();
        var studentManagementSystem = new StudentManagementSystem { Database = database };
        var deserializer = new JsonDeserializer();
        var dataProvider = new WebDataProvider();
        var userInterface = new ConsoleInterface();

        var students =
            deserializer.Deserialize<List<Student>>(dataProvider.GetData(Constants.StudentsFileLink));
        var grades = deserializer.Deserialize<List<Grade>>(dataProvider.GetData(Constants.GradesFileLink));

        if (database.isEmpty())
        {
            studentManagementSystem.RegisterStudents(students);
            studentManagementSystem.ImportGrades(grades);
        }

        userInterface.ShowList<string>(studentManagementSystem.GetNTopStudents(3));
    }
}