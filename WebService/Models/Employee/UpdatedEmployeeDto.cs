using System.ComponentModel.DataAnnotations;

namespace WebService.Models.Employee;

public class UpdatedEmployeeDto
{
    [Required] public int EmployeeId { get; set; }

    public string? Name { get; set; }

    [EmailAddress] [Required] public string? Email { get; set; }

    public int? LocationId { get; set; }
    public int CafeteriaId { get; set; }
    public int? CityId { get; set; }
}