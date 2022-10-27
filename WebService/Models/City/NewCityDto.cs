using System.ComponentModel.DataAnnotations;
using Domain;

namespace WebService.Models.City;

public class NewCityDTO
{
    [Required] public string? Name { get; set; }
}