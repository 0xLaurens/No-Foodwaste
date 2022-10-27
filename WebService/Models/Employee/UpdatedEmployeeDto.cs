using System.ComponentModel.DataAnnotations;

namespace WebService.Models.Employee;

public class UpdatedEmployeeDto
{
    [Required] public int CityId { get; set; }

    [Required] public string? Name { get; set; }
}