using System.ComponentModel.DataAnnotations;

namespace WebService.Models.Employee;

public class NewEmployeeDto
{
    public string? Name { get; set; }

    [Required] [EmailAddress] public string? Email { get; set; }

    public int? LocationId { get; set; }
    public int CafeteriaId { get; set; }
    public int? CityId { get; set; }
}