using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Student
{
    public int StudentId { get; set; }
    public string EmailAddress { get; set; }
    public City? City { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? DateOfBirth { get; set; }
}