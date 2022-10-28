using Location = Domain.Location;

namespace WebService.Models.Cafeteria;

public class UpdatedCafeteriaDto
{
    public int CafeteriaId { get; set; }
    public int CityId { get; set; }
    public Domain.City? City { get; set; }
    public int LocationId { get; set; }
    public Location? Location { get; set; }
}