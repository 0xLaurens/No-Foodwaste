namespace Domain;

public class City
{
    public int CityId { get; set; }
    public string? Name { get; set; }
    public List<Location>? Locations { get; set; }
}