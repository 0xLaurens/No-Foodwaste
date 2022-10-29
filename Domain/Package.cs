using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Package
{
    
    
    public int PackageId { get; set; }

    [Required(ErrorMessage = "Enter a unique name")]
    public string? Name { get; set; }

    public byte[]? Thumbnail { get; set; }
    public string? ThumbnailFormat { get; set; }


    public int? CityId { get; set; }
    public virtual City? City { get; set; }

    [Required] public int CafeteriaId { get; set; }

    public virtual Cafeteria? Cafeteria { get; set; }

    public virtual ICollection<Product>? Products { get; set; }

    [Required(ErrorMessage = "Enter a valid start time")]
    public DateTime StartTimeSlot { get; set; }
    

    [Required(ErrorMessage = "Enter a valid end time")]
    public DateTime EndTimeSlot { get; set; }

    public bool EighteenPlus { get; set; }

    [Required(ErrorMessage = "Enter a valid price ex: 1.99")]
    [Column(TypeName = "Decimal(3,2)")]
    public decimal? Price { get; set; }

    [Required(ErrorMessage = "Enter a category")]
    public virtual Category? Category { get; set; }

    public int? StudentId { get; set; }
    
    // Domain Logic
    public bool CanPackageBeAltered()
    {
        return StudentId == null;
    }
    
    public bool PackagesHasProductThatContainsAlcohol()
    {
        return Products!.Any(p => p.ContainsAlcohol == true);
    }
}


public enum Category
{
    Fruit,
    Bread,
    Diner,
    Lunch,
    Beveridge,
    Vega
}