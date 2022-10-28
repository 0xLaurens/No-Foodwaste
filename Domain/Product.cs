namespace Domain;

public class Product
{
    public int ProductId { get; set; }
    public string? Name { get; set; }
    public byte[]? Photo { get; set; }
    public bool? ContainsAlcohol { get; set; }
    public virtual ICollection<Package>? Packages { get; set; }
}