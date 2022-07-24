using System.Text.Json;

namespace library;
public class Program
{
     static void Main(string[] args)
     {
          string studentsFile = @"resources/students.json";
          string gradesFile = @"resources/grades.json";

          FileReader fileReader = new FileReader();
          StudentManagementSystem studentManagementSystem = new StudentManagementSystem();
          Deserializer deserializer = new Deserializer();


          List<Student> studetns = deserializer.deserialize<Student>(fileReader.readFile(studentsFile));
          List<Grade> grades = deserializer.deserialize<Grade>(fileReader.readFile(gradesFile));

          foreach(Student s in studetns)
          {
               studentManagementSystem.addStudent(s);    
          }

          studentManagementSystem.importGrades(grades);
          foreach(Student student in studentManagementSystem.getNTopStudents(3)) Console.WriteLine(student);
                    
     }

}