namespace Domain;

public class Cafeteria
{
    public int CafeteriaId { get; set; }
    public int? CityId { get; set; }
    public virtual City? City { get; set; }
    public int? LocationId { get; set; }
    public virtual Location? Location { get; set; }
}