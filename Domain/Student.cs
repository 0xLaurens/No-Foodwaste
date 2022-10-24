using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Student
{
    private DateTime? _DateOfBirth;
    public int StudentId { get; init; }
    [EmailAddress]
    public string? EmailAddress { get; init; }
    public int? CityId { get; set; }
    [Phone] 
    public string? PhoneNumber { get; set; }
    [Required(ErrorMessage = "Enter your Date of Birth")]
    public DateTime? DateOfBirth
    {
        get => _DateOfBirth;
        set
        {
            if (value!.Value.Date > DateTime.Now.Date)
                throw new InvalidOperationException("Birthday cannot be in the future");
            if (value.Value.Date > DateTime.Now.AddYears(-16).Date)
                throw new InvalidOperationException("Student must be at least 16 years old");

            _DateOfBirth = value.Value.Date;
        }
    }

    public virtual List<Package>? Packages { get; init; }
}