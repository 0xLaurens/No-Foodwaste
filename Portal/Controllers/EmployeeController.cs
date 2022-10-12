using DomainServices.Repos.Inf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Avans_NoWaste.Controllers;

public class EmployeeController: Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IPackageRepository _packageRepository;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IStudentRepository _studentRepository;


    public EmployeeController(ILogger<HomeController> logger, IPackageRepository packageRepository, UserManager<IdentityUser> userManager, IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
        _logger = logger;
        _packageRepository = packageRepository;
        _userManager = userManager;
    }
    
    [Authorize(Policy = "EmployeeOnly")]
    public IActionResult Index()
    {
        return View(_packageRepository.GetPackages());
    }
}