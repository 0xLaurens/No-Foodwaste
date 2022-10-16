using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Product
{
   public int ProductId { get; set; }
   public string? Name { get; set; }
   public string? Photo { get; set; }
   public virtual ICollection<Package>? Packages { get; set; }
}