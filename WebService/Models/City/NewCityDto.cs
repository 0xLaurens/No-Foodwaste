using System.ComponentModel.DataAnnotations;

namespace WebService.Models.City;

public class NewCityDTO
{
    [Required] public string? Name { get; set; }
}