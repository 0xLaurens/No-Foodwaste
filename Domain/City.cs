namespace Domain;

public class City
{
    public int CityId { get; set; }
    public string? Name { get; set; }
    public virtual ICollection<Location>? Locations { get; set; }
}