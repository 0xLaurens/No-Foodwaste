using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Package
{
    public int PackageId { get; set; }
    [Required]
    public string Name { get; set; }
    public List<Product>? Products { get; set; }
    public City? City { get; set; }
    public Cafeteria? Cafeteria { get; set; }
    public DateTime? PickupTime { get; set; }
    public DateTime? BestBeforeDate { get; set; }
    public bool? EighteenPlus { get; set; }
    public decimal? Price { get; set; }
    public Category? Category { get; set; }
    public Student? ReservedBy { get; set; }
}

public enum Category
{
    Bread,
    Beveridge,
    HotMeal, 
}