namespace Domain;

public class Cafeteria
{
    public int CafeteriaId { get; set; }
    public int? CityId { get; set; }
    public int? LocationId { get; set; }
    public ICollection<Package>? Packages { get; set; }
    public Location? Location { get; set; }
}