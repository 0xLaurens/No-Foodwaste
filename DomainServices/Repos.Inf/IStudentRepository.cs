using Domain;

namespace DomainServices.Repos.Inf;

public interface IStudentRepository
{
    public Student? GetStudentById(int id);
    public Student GetStudentByEmail(string Email);
    public IQueryable<Student> GetStudents();

    public void AddStudent(Student student);
}