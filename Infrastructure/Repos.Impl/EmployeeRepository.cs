using Domain;
using DomainServices.Repos.Inf;

namespace Infrastructure.Repos.Impl;

public interface CafeteriaEmployee : IEmployeeRepository
{
    public List<Employee> GetEmployees();
    public Employee GetEmployeeById(int id);
}