using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;

namespace Domain;

public class Package
{
    public int PackageId { get; set; }
    [Required(ErrorMessage = "Enter a unique name")]
    public string Name { get; set; }
    [Required]
    public int? CityId { get; set; }
    public virtual City City { get; set; }
    [Required]
    public int CafeteriaId { get; set; }
    public virtual Cafeteria? Cafeteria { get; set; }
    public virtual ICollection<Product>? Products { get; set; }
    [Required]
    public DateTime PickupTime { get; set; }
    [Required]
    public DateTime BestBeforeDate { get; set; }
    public bool EighteenPlus { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public virtual Category Category { get; set; }
    public int? ReservedByStudentId { get; set; }
}

public enum Category
{
    Fruit,
    Vegetable,
    Bread,
    Diner,
    Lunch,
    Beveridge,
    HotMeal,
    Vega,
    Gluten,
}