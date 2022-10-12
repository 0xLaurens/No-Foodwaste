using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Avans_NoWaste.Models;
using DomainServices.Repos.Inf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Avans_NoWaste.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IPackageRepository _packageRepository;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IStudentRepository _studentRepository;


    public HomeController(ILogger<HomeController> logger, IPackageRepository packageRepository, UserManager<IdentityUser> userManager, IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
        _logger = logger;
        _packageRepository = packageRepository;
        _userManager = userManager;
    }

    [Authorize]
    public IActionResult Index()
    {
        return View(_packageRepository.GetNonReservedPackages());
    }
    
    [Authorize]
    public IActionResult Orders()
    {
        var email = this.User.FindFirstValue(ClaimTypes.Email);
        var student = _studentRepository.GetStudentByEmail(email);
        return View(_packageRepository.GetPackagesByStudent(student.StudentId));
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}