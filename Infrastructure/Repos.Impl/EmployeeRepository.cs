using Domain;
using DomainServices.Repos.Inf;

namespace Infrastructure.Repos.Impl;

public interface EmployeeRepository : IEmployeeRepository
{
    public List<Employee> GetEmployees();
    public Employee GetEmployeeById(int id);
}