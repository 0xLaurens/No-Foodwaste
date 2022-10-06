using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Package
{
    public int PackageId { get; set; }
    [Required (ErrorMessage = "Please add a name")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Please add some example products")]
    public List<Product>? Products { get; set; }
    [Required(ErrorMessage = "Please add a city")]
    public City? City { get; set; }
    [Required(ErrorMessage = "Please add a cafeteria")]
    public Cafeteria? Cafeteria { get; set; }
    [Required(ErrorMessage = "Please add a pickup time for the package")]
    public DateTime? PickupTime { get; set; }
    [Required(ErrorMessage = "Please add a best before date")]
    public DateTime? BestBeforeDate { get; set; }
    [Required(ErrorMessage = "Please add an age indicator")]
    public bool? EighteenPlus { get; set; }
    [Required(ErrorMessage = "Please add a price for the package")]
    public decimal? Price { get; set; }
    [Required(ErrorMessage = "Please add a Category")]
    public Category? Category { get; set; }
    public Student? ReservedBy { get; set; }
}

public enum Category
{
    Bread,
    Beveridge,
    HotMeal, 
}