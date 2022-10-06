using Domain;

namespace DomainServices.Repos.Inf;

public interface ICafeteriaEmployee
{
    public List<Employee> GetEmployees();
    public Employee GetEmployeeById(int id);
}