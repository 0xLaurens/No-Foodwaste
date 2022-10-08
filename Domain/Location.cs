using Microsoft.EntityFrameworkCore;

namespace Domain;

public class Location
{
   public int LocationId { get; set; }
   public string? Name { get; set; }
   
   public int? CityId { get; set; }
   public ICollection<Employee>? Employees { get; set; }
}