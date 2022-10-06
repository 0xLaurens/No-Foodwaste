using Domain;

namespace DomainServices.Repos.Inf;

public interface IEmployeeRepository
{
    public List<Employee> GetEmployees();
    public Employee GetEmployeeById(int id);
}