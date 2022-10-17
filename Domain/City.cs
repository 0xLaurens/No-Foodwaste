namespace Domain;

public class City
{
    public int CityId { get; set; }
    public string? Name { get; set; }
    public virtual ICollection<Location>? Locations { get; set; }
    public virtual ICollection<Student>? Students { get; set; }
    public virtual ICollection<Cafeteria>? Cafeterias { get; set; }
}