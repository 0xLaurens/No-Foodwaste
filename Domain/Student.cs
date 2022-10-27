using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Student
{
    private DateTime? _dateOfBirth;

    public int StudentId { get; init; }

    [EmailAddress] public string? EmailAddress { get; init; }

    public int? CityId { get; set; }

    [Phone] public string? PhoneNumber { get; set; }

    [Required(ErrorMessage = "Enter your Date of Birth")]
    public DateTime? DateOfBirth
    {
        get => _dateOfBirth;
        set
        {
            if (value!.Value.Date > DateTime.Now.Date)
                throw new InvalidOperationException("Birthday cannot be in the future");
            if (value.Value.Date > DateTime.Now.AddYears(-16).Date)
                throw new InvalidOperationException("Student must be at least 16 years old");

            _dateOfBirth = value.Value.Date;
        }
    }

    public virtual List<Package>? Packages { get; init; }
}