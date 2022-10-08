using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Cafeteria
{
    public int CafeteriaId { get; set; }
    public int? CityId { get; set; }
    public ICollection<Package>? Packages { get; set; }
}