using Domain;
using DomainServices.Repos.Inf;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repos.Impl;

public class StudentRepository : IStudentRepository
{
    private readonly FoodDbContext _context;

    public StudentRepository(FoodDbContext context)
    {
        _context = context;
    }


    public Student? GetStudentById(int id)
    {
        return GetStudents().SingleOrDefault(s => s.StudentId == id)!;
    }

    public Student GetStudentByEmail(string email)
    {
        return GetStudents().SingleOrDefault(s => s.EmailAddress == email)!;
    }

    public IQueryable<Student> GetStudents()
    {
        return _context.Students!
            .Include(s => s.Packages);
    }

    public void AddStudent(Student student)
    {
        _context.Students!.Add(student);
        _context.SaveChanges();
    }
}