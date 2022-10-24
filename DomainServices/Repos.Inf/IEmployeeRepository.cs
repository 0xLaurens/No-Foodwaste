using Domain;

namespace DomainServices.Repos.Inf;

public interface IEmployeeRepository
{
    public IQueryable<Employee> GetEmployees();
    public Employee GetEmployeeById(int id);
    public Employee GetEmployeeByEmail(string email);
}