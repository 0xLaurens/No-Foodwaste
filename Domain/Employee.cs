using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Employee
{
    public int EmployeeId { get; set; }
    public string? Name { get; set; }

    [EmailAddress] public string? Email { get; set; }

    public int? LocationId { get; set; }
    public int CafeteriaId { get; set; }
    public int? CityId { get; set; }
}