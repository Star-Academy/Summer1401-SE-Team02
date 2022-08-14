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
        var database = new SchoolContext();
        var studentManagementSystem = new StudentManagementSystem { Database = database };

        var userInterface = new ConsoleInterface();

        if (database.isEmpty())
        {
            var deserializer = new JsonDeserializer();
            var dataProvider = new WebDataProvider();
            var students =
                deserializer.Deserialize<List<Student>>(dataProvider.GetData(Constants.StudentsFileLink)).ToDictionary(s => s.StudentNumber);
            var grades = deserializer.Deserialize<List<Grade>>(dataProvider.GetData(Constants.GradesFileLink));

            foreach (var g in grades) students[g.StudentNumber].Grades.Add(g);
                
            studentManagementSystem.RegisterStudents(students.Values.ToList());
            studentManagementSystem.ImportGrades(grades);
        }

        userInterface.ShowList<string>(studentManagementSystem.GetNTopStudents(3));
    }
}