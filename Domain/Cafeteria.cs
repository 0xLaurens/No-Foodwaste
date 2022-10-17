namespace Domain;

public class Cafeteria
{
    public int CafeteriaId { get; set; }
    public int? CityId { get; set; }
    public int? LocationId { get; set; }
    public virtual ICollection<Package>? Packages { get; set; }
    public virtual Location? Location { get; set; }
}