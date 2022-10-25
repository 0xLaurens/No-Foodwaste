using System.ComponentModel.DataAnnotations;
using Domain;
using Infrastructure.Repos.Impl;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Avans_NoWaste.Models;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Enter your email")]
    public string? EmailAddress { get; set; }

    [Required(ErrorMessage = "Enter you phone number")]
    public string? PhoneNumber { get; set; }

    [Required(ErrorMessage = "Select a city")]
    public int? CityId { get; set; }

    public List<SelectListItem>? Cities { get; set; }

    [Required] public DateTime? DateOfBirth { get; set; }

    [Required(ErrorMessage = "Enter a password")]
    [DataType(DataType.Password)]
    public string? Password
    {
        get;
        set;
    }


    [Required(ErrorMessage = "Confirm your password")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string? ConfirmPassword { get; set; }

    public string ReturnUrl { get; set; } = "/";
}