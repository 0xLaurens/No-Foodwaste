using Microsoft.EntityFrameworkCore;

namespace Domain;

public class Location
{
   public int LocationId { get; set; }
   public string? Name { get; set; }
   
   public int? CityId { get; set; }
   
   public virtual ICollection<Cafeteria>? Cafeterias { get; set; }
   public virtual ICollection<Employee>? Employees { get; set; }
}