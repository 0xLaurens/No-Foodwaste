using Domain;
using DomainServices.Repos.Inf;

namespace Infrastructure.Repos.Impl;

public interface StudentRepository: IStudentRepository
{
    public Student GetStudentById(int id);
    public Student GetStudentByEmail(string Email);
    public List<Student> GetStudents();
}