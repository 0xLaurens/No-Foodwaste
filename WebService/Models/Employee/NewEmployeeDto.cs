using System.ComponentModel.DataAnnotations;

namespace WebService.Models.Employee;

public class NewEmployeeDto 
{
    [Required] public string? Name { get; set; }
}