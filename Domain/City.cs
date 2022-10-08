namespace Domain;

public class City
{
    public int CityId { get; set; }
    public string Name { get; set; }
    public ICollection<Location>? Locations { get; set; }
    public ICollection<Student>? Students { get; set; }
    public ICollection<Cafeteria>? Cafeterias { get; set; }
}