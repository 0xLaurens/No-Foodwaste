using Domain;
using DomainServices.Repos.Inf;

namespace Infrastructure.Repos.Impl;

public class StudentRepository: IStudentRepository
{
    private readonly FoodDbContext _context;

    public StudentRepository(FoodDbContext context)
    {
        _context = context;
    }
    public Student GetStudentById(int id)
    {
        return _context.Students!.SingleOrDefault(s => s.StudentId == id)!;
    }

    public Student GetStudentByEmail(string Email)
    {
        return _context.Students!.SingleOrDefault(s => s.EmailAddress == Email)!;
    }

    public IQueryable<Student> GetStudents()
    {
        return _context.Students!;
    }

    public void AddStudent(Student student)
    {
        _context.Students!.Add(student);
        _context.SaveChanges();
    }
}