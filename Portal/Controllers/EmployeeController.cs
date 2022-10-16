using System.Security.Claims;
using Avans_NoWaste.Models;
using Domain;
using DomainServices.Repos.Inf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Avans_NoWaste.Controllers;

public class EmployeeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IPackageRepository _packageRepository;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IProductRepository _productRepository;


    public EmployeeController(ILogger<HomeController> logger, IPackageRepository packageRepository,
        UserManager<IdentityUser> userManager, IEmployeeRepository employeeRepository,
        IProductRepository productRepository)
    {
        _logger = logger;
        _userManager = userManager;
        _packageRepository = packageRepository;
        _employeeRepository = employeeRepository;
        _productRepository = productRepository;
    }

    [Authorize(Policy = "EmployeeOnly")]
    public IActionResult Index()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        var employee = _employeeRepository.GetEmployeeByEmail(email);
        return View(_packageRepository.GetNonReservedPackagesPerCafeteria(employee.CafeteriaId));
    }

    [Authorize(Policy = "EmployeeOnly")]
    public IActionResult Overview()
    {
        return View(_packageRepository.GetNonReservedPackages());
    }

    [HttpGet]
    [Authorize(Policy = "EmployeeOnly")]
    public IActionResult Create()
    {
        var products = _productRepository.GetProducts();
        var list = products.Select(p => new PackageViewModel.CheckboxOptions { IsChecked = false, Value = p }).ToList();
        var viewModel = new PackageViewModel
        {
            Package = null,
            OptionsList = list
        };
        return View(viewModel);
    }

    [HttpPost]
    [Authorize(Policy = "EmployeeOnly")]
    public IActionResult Create(PackageViewModel model)
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        var employee = _employeeRepository.GetEmployeeByEmail(email);
        model.Package.CafeteriaId = employee.CafeteriaId;
        model.Package.CityId = employee.CityId;
        var productIds = model.ProductsList;
        model.Package.Products = productIds.Select(p => _productRepository.GetProductById(p)).ToList();
        _packageRepository.CreatePackage(model.Package);
        return Redirect("/");
    }

    [HttpGet]
    [Authorize(Policy = "EmployeeOnly")]
    public IActionResult Update(int id)
    {
        var list = _productRepository.GetProducts();
        var package = _packageRepository.GetPackageById(id);
        var check = list.Select(l => package.Products.Contains(l)
                ? new PackageViewModel.CheckboxOptions() { IsChecked = true, Value = l }
                : new PackageViewModel.CheckboxOptions() { IsChecked = false, Value = l })
            .ToList();
        var model = new PackageViewModel
        {
            Package = package,
            OptionsList = check,
        };
        return View(model);
    }

    [HttpPost]
    [Authorize(Policy = "EmployeeOnly")]
    public IActionResult Update(PackageViewModel model)
    {
        var productIds = model.ProductsList;
        model.Package.Products = productIds.Select(p => _productRepository.GetProductById(p)).ToList();
        _packageRepository.UpdatePackage(model.Package);
        return Redirect("/");
    }

    [Authorize(Policy = "EmployeeOnly")]
    public IActionResult Delete(int id)
    {
        _packageRepository.RemovePackage(id);
        return Redirect("/Employee");
    }



}