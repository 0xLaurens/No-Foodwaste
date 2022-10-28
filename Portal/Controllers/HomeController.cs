using System.Diagnostics;
using System.Security.Claims;
using Avans_NoWaste.Models;
using Domain;
using DomainServices.Repos.Inf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Avans_NoWaste.Controllers;

public class HomeController : Controller
{
    private readonly ILocationRepository _locationRepository;
    private readonly ILogger<HomeController> _logger;
    private readonly IPackageRepository _packageRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly UserManager<IdentityUser> _userManager;


    public HomeController(ILogger<HomeController> logger, IPackageRepository packageRepository,
        UserManager<IdentityUser> userManager, IStudentRepository studentRepository,
        ILocationRepository locationRepository)
    {
        _studentRepository = studentRepository;
        _locationRepository = locationRepository;
        _logger = logger;
        _packageRepository = packageRepository;
        _userManager = userManager;
    }

    [Authorize]
    public IActionResult Index(Category? category, string? location)
    {
        ViewData["Locations"] = _locationRepository.GetLocations().Select(x => x.Name).ToList();
        ViewData["LocationFilter"] = location;
        ViewData["CategoryFilter"] = category;
        return View(_packageRepository.GetNonReservedPackagesFiltered(category, location));
    }

    [Authorize]
    public IActionResult Orders()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        var student = _studentRepository.GetStudentByEmail(email);
        return View(_packageRepository.GetPackagesByStudent(student));
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}