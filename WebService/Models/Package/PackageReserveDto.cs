using System.ComponentModel.DataAnnotations;

namespace WebService.Models.Package;

public class PackageReserveDto
{
    [Required] public int PackageId { get; set; }
    [Required] public int? StudentId { get; set; }
}