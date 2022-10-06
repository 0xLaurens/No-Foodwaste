namespace Domain;

public class Location
{
    public int LocationId { get; set; }
    public City City { get; set; }
    public List<Employee> Employees { get; set; }
}