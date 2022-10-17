using Domain;
using DomainServices.Repos.Inf;

namespace Infrastructure.Repos.Impl;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly FoodDbContext _context;

    public EmployeeRepository(FoodDbContext context)
    {
        _context = context;
    }

    public List<Employee> GetEmployees()
    {
        return _context.Employees.ToList();
    }

    public Employee GetEmployeeById(int id)
    {
        return _context.Employees.SingleOrDefault(e => e.EmployeeId == id);
    }
    
    public Employee GetEmployeeByEmail(string email)
    {
        return _context.Employees.SingleOrDefault(e => e.Email == email);
    }
}