using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Avans_NoWaste.Models;
using DomainServices.Repos.Inf;
using Infrastructure.Repos.Impl;

namespace Avans_NoWaste.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IPackageRepository _packageRepository;

    public HomeController(ILogger<HomeController> logger, IPackageRepository packageRepository)
    {
        _logger = logger;
        _packageRepository = packageRepository;
    }

    public IActionResult Index()
    {
        
        return View(_packageRepository.GetNonReservedPackages());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}