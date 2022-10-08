using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Student
{
    public int StudentId { get; set; }
    [EmailAddress]
    public string? EmailAddress { get; set; }
    public int? CityId { get; set; }
    [Phone] 
    public string? PhoneNumber { get; set; }
    [Required(ErrorMessage = "Enter your Date of Birth")]
    public DateTime? DateOfBirth { get; set; }

}