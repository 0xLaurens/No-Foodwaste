using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Student
{
    public int StudentId { get; set; }
    [Required(ErrorMessage = "Please enter your email address")]
    [EmailAddress]
    public string EmailAddress { get; set; }
    public int CityId { get; set; }
    [Required(ErrorMessage = "Please enter a valid phone number")] 
    [Phone] 
    public string? PhoneNumber { get; set; }
    [Required(ErrorMessage = "Enter your Date of Birth")]
    public DateTime? DateOfBirth { get; set; }
}