using System.Security.Claims;
using DomainServices.Repos.Inf;
using DomainServices.Services.Inf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Avans_NoWaste.Controllers;

public class PackageController: Controller
{
    private readonly IPackageRepository _packageRepository;
    private readonly IPackageService _packageService;
    private readonly IStudentRepository _studentRepository;

    public PackageController(IPackageRepository packageRepository, IPackageService packageService, IStudentRepository studentRepository)
    {
        _packageRepository = packageRepository;
        _packageService = packageService;
        _studentRepository = studentRepository;
    }
    
    [Authorize]
    public IActionResult Package(int id)
    {
        return View(_packageRepository.GetPackageById(id));
    }

    [HttpPost]
    [Authorize(Policy = "StudentOnly")]
    public IActionResult ReservePackage(int id)
    {
        var package = _packageRepository.GetPackageById(id);
        var email = User.FindFirstValue(ClaimTypes.Email);
        var student = _studentRepository.GetStudentByEmail(email);
        
        if (!_packageService.CanPackageBeReservedByStudent(package, student))
            throw new Exception("Package cannot be reserved by student");

        _packageRepository.ReservePackageForStudent(package, student);
        return Redirect("/");
    }
  
}