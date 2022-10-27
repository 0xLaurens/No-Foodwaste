using System.ComponentModel.DataAnnotations;
using Domain;

namespace WebService.Models.City;

public class UpdatedCityDto
{
    [Required] public int CityId { get; set; }

    [Required] public string? Name { get; set; }
}