using System.ComponentModel.DataAnnotations;

namespace WebService.Models.City;

public class UpdatedCityDto
{
    [Required] public int CityId { get; set; }

    [Required] public string? Name { get; set; }
}