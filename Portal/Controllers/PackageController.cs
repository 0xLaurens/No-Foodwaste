using System.Security.Claims;
using Domain;
using DomainServices.Repos.Inf;
using DomainServices.Services.Inf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Avans_NoWaste.Controllers;

public class PackageController : Controller
{
    private readonly IPackageRepository _packageRepository;
    private readonly IPackageService _packageService;
    private readonly IStudentRepository _studentRepository;

    public PackageController(IPackageRepository packageRepository, IPackageService packageService,
        IStudentRepository studentRepository)
    {
        _packageRepository = packageRepository;
        _packageService = packageService;
        _studentRepository = studentRepository;
    }

    [HttpGet]
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


        if (!_packageService.StudentCanOrderPackageOnDate(package!, student))
        {
            if (!package!.CanPackageBeAltered())
            {
                ViewBag.Error = "The package you are trying to reserve has already been reserved";

                return View("Package", _packageRepository.GetPackageById(id));
            }

            if (!_packageService.StudentCanOrderPackageOnDate(package!, student) && _packageService.StudentOldEnoughForPackage(package!, student))
            {
                ViewBag.Error = "Marked as 18+ and the student already picked up a package for that day";
            } 

            if (!_packageService.StudentCanOrderPackageOnDate(package!, student))
            {
                ViewBag.Error = "You already ordered a package for that date, you can only pickup one package per day";

                return View("Package", _packageRepository.GetPackageById(id));
            }
            
            if (!_packageService.StudentOldEnoughForPackage(package!, student))
            {
                ViewBag.Error =
                    "This package is marked as 18 plus, you have to be 18 or older on the date of the package pickup";
                return View("Package", _packageRepository.GetPackageById(id));
            }
        }

        _packageRepository.ReservePackageForStudent(package!, student);
        return View("Confirmation");
    }

    public IActionResult Confirmation()
    {
        return View();
    }
}