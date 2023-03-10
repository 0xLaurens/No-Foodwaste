using Avans_NoWaste.Models;
using Domain;
using DomainServices.Repos.Inf;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Avans_NoWaste.Controllers;

public class AccountController : Controller
{
    private readonly ICityRepository _cityRepository;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IStudentRepository _studentRepository;
    private readonly UserManager<IdentityUser> _userManager;

    public AccountController(UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signInMgr,
        IStudentRepository studentRepository, ICityRepository cityRepository)
    {
        _userManager = userMgr;
        _signInManager = signInMgr;
        _studentRepository = studentRepository;
        _cityRepository = cityRepository;

        IdentitySeedData.EnsurePopulated(userMgr).Wait();
    }

    [AllowAnonymous]
    public IActionResult Login(string returnUrl)
    {
        return View(new LoginViewModel
        {
            ReturnUrl = returnUrl
        });
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
        if (!ModelState.IsValid) return View(loginViewModel);

        var user = await _userManager.FindByEmailAsync(loginViewModel.Email);

        if (user != null)
        {
            await _signInManager.SignOutAsync();
            if ((await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false)).Succeeded)
            {
                var claims = await _userManager.GetClaimsAsync(user);
                return Redirect(claims.Any(c => c.Value == "true" && c.Type == "Employee") ? "/Employee" : "/");
            }
        }

        ModelState.AddModelError("LogInError", "The email or password provided is incorrect");

        return View(loginViewModel);
    }

    public async Task<IActionResult> SignOutUser()
    {
        await _signInManager.SignOutAsync();
        return Redirect("/Account/Login");
    }

    [AllowAnonymous]
    public IActionResult Register(string returnUrl)
    {
        var cities = _cityRepository.GetCities()!
            .Select(c => new SelectListItem
            {
                Value = c.CityId.ToString(),
                Text = c.Name
            }).ToList();
        return View(new RegisterViewModel
        {
            Cities = cities,
            ReturnUrl = returnUrl
        });
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
    {
        registerViewModel.Cities = _cityRepository.GetCities()!
            .Select(c => new SelectListItem
            {
                Value = c.CityId.ToString(),
                Text = c.Name
            }).ToList();

        var student = new Student
        {
            EmailAddress = registerViewModel.EmailAddress,
            CityId = registerViewModel.CityId,
            PhoneNumber = registerViewModel.PhoneNumber
        };

        try
        {
            student.DateOfBirth = registerViewModel.DateOfBirth;
        }
        catch (Exception e)
        {
            ModelState.AddModelError("DateError", e.Message);
        }


        if (!ModelState.IsValid) return View(registerViewModel);

        var user = new IdentityUser
            { UserName = registerViewModel.EmailAddress, Email = registerViewModel.EmailAddress };


        var result = await _userManager.CreateAsync(user, registerViewModel.Password);


        if (!result.Succeeded)
            return View(registerViewModel);


        await _signInManager.SignInAsync(user, false);
        _studentRepository.AddStudent(student);
        return LocalRedirect(registerViewModel.ReturnUrl);
    }
}