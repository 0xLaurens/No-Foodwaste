using System.ComponentModel.DataAnnotations;
using Domain;

namespace WebService.Models.Package;

public class UpdatedPackageDto
{
    public int PackageId { get; set; }

    [Required(ErrorMessage = "Enter a unique name")]
    public string? Name { get; set; }

    [Required] public int? CityId { get; set; }

    [Required] public int CafeteriaId { get; set; }

    [Required(ErrorMessage = "Enter a valid start time")]
    public DateTime StartTimeSlot { get; set; }

    [Required(ErrorMessage = "Enter a valid end time")]
    public DateTime EndTimeSlot { get; set; }

    public bool EighteenPlus { get; set; }

    [Required(ErrorMessage = "Enter a valid price ex: 1.99")]
    public decimal? Price { get; set; }

    public Category? Category { get; set; }
    public int? StudentId { get; set; }
}