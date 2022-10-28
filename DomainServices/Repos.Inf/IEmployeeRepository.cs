using Domain;

namespace DomainServices.Repos.Inf;

public interface IEmployeeRepository
{
    public IQueryable<Employee> GetEmployees();
    public Employee GetEmployeeById(int id);
    public Employee GetEmployeeByEmail(string email);
    public void CreateEmployee(Employee employee);
    public void UpdateEmployee(Employee employee);
    public void DeleteEmployee(Employee employee);
}