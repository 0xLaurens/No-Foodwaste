using System.Security.Claims;
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
    private readonly IEmployeeRepository _employeeRepository;


    public EmployeeController(ILogger<HomeController> logger, IPackageRepository packageRepository, UserManager<IdentityUser> userManager, IEmployeeRepository employeeRepository)
    {
        _logger = logger;
        _userManager = userManager;
        _packageRepository = packageRepository;
        _employeeRepository = employeeRepository;
    }
    
    [Authorize(Policy = "EmployeeOnly")]
    public IActionResult Index()
    {
        
        var email = User.FindFirstValue(ClaimTypes.Email);
        var employee = _employeeRepository.GetEmployeeByEmail(email);
        return View(_packageRepository.GetNonReservedPackagesPerCafeteria(employee.EmployeeId));
    }
    
    [Authorize(Policy = "EmployeeOnly")]
    public IActionResult Overview()
    {
        return View(_packageRepository.GetPackages());
    }
    
}