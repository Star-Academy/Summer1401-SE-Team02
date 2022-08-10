using app.model.entities;
using Microsoft.EntityFrameworkCore;

namespace app.model.database;

public class PostgresqlDatabase : DbContext, IDatabase
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Grade> Grades { get; set; }

    public void AddStudents(List<Student> students)
    {
        AddRange(students);
        SaveChanges();
    }

    public void AddGrades(List<Grade> grades)
    {
        AddRange(grades);
        SaveChanges();
    }

    public IEnumerable<Student> GetStudents()
    {
        return Students;
    }

    public IEnumerable<Grade> GetGrades()
    {
        return Grades;
    }

    public bool isEmpty()
    {
        return !(Students.Any() || Grades.Any());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Host=localhost;Database=school;Username=postgres;Password=mynewpassword");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().HasKey(s => s.StudentNumber);
        modelBuilder.Entity<Grade>().HasKey(g => new { g.StudentNumber, g.Lesson });
    }
}