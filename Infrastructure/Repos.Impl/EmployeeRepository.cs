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

    public IQueryable<Employee> GetEmployees()
    {
        return _context.Employees!;
    }

    public Employee GetEmployeeById(int id)
    {
        return _context.Employees!.SingleOrDefault(e => e.EmployeeId == id)!;
    }

    public Employee GetEmployeeByEmail(string email)
    {
        return _context.Employees!.SingleOrDefault(e => e.Email == email)!;
    }

    public void CreateEmployee(Employee employee)
    {
        _context.Employees!.Add(employee);
        _context.SaveChanges();
    }

    public void UpdateEmployee(Employee employee)
    {
        _context.Employees!.Update(employee);
        _context.SaveChanges();
    }

    public void DeleteEmployee(Employee employee)
    {
        _context.Employees!.Remove(employee);
        _context.SaveChanges();
    }
}