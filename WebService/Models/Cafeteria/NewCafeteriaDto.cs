using System.ComponentModel.DataAnnotations;

namespace WebService.Models.Cafeteria;

public class NewCafeteriaDTO
{
    [Required] public int CityId { get; set; }
    [Required] public int LocationId { get; set; }
}