using System.Security.Claims;
using Avans_NoWaste.Models;
using DomainServices.Repos.Inf;
using DomainServices.Services.Inf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Avans_NoWaste.Controllers;

public class EmployeeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IPackageRepository _packageRepository;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IProductRepository _productRepository;
    private readonly IPackageService _packageService;


    public EmployeeController(ILogger<HomeController> logger, IPackageRepository packageRepository,
        UserManager<IdentityUser> userManager, IEmployeeRepository employeeRepository,
        IProductRepository productRepository, IPackageService packageService)
    {
        _logger = logger;
        _userManager = userManager;
        _packageRepository = packageRepository;
        _employeeRepository = employeeRepository;
        _productRepository = productRepository;
        _packageService = packageService;
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

        var productIds = model.ProductsList;
        model.Package!.Products = productIds?.Select(p => _productRepository.GetProductById(p)).ToList();

        if (!_packageService.PackageHasCorrectDate(model.Package!) || !ModelState.IsValid)
        {
            var products = _productRepository.GetProducts();
            model.OptionsList = products.Select(l =>
                    model.Package.Products != null && model.Package.Products.Contains(l)
                        ? new PackageViewModel.CheckboxOptions() { IsChecked = true, Value = l }
                        : new PackageViewModel.CheckboxOptions() { IsChecked = false, Value = l })
                .ToList();

            var dateError1 = _packageService.PackageDateNotTooFarInTheFutureOrPast(model.Package!);
            var dateError2 = _packageService.PackageHasCorrectStartAndEnd(model.Package!);

            if (!dateError1)
                ModelState.AddModelError("DateError",
                    "Start date and end date must be today, tomorrow or the day after tomorrow");

            if (!dateError2)
                ModelState.AddModelError("DateError",
                    "Start time and end must be on the same day, the start must be earlier than the end time");

            return View(model);
        }


        if (_packageService.PackagesHasProductThatContainsAlcohol(model.Package))
            model.Package.EighteenPlus = true;

        model.Package.CafeteriaId = employee.CafeteriaId;
        model.Package.CityId = employee.CityId;

        _packageRepository.CreatePackage(model.Package!);
        return Redirect("/");
    }

    [HttpGet]
    [Authorize(Policy = "EmployeeOnly")]
    public IActionResult Update(int id)
    {
        var list = _productRepository.GetProducts();
        var package = _packageRepository.GetPackageById(id);
        var check = list.Select(l => package.Products!.Contains(l)
                ? new PackageViewModel.CheckboxOptions() { IsChecked = true, Value = l }
                : new PackageViewModel.CheckboxOptions() { IsChecked = false, Value = l })
            .ToList();
        package.PackageId = id;
        var viewModel = new PackageViewModel
        {
            Package = package,
            OptionsList = check,
        };

        if (_packageService.PackagesHasProductThatContainsAlcohol(viewModel.Package))
            viewModel.Package.EighteenPlus = true;

        return View(viewModel);
    }

    [HttpPost]
    [Authorize(Policy = "EmployeeOnly")]
    public IActionResult Update(PackageViewModel model)
    {
        var productIds = model.ProductsList;
        model.Package!.Products = productIds?.Select(p => _productRepository.GetProductById(p)).ToList();

        if (!_packageService.PackageHasCorrectDate(model.Package!) || 
            !ModelState.IsValid ||
            !_packageService.CanPackageBeAltered(model.Package!))
        {
            if (!_packageService.CanPackageBeAltered(model.Package!))
                ModelState.AddModelError("UpdateError", "This package cannot be altered, it's already reserved");

            var products = _productRepository.GetProducts();
            model.OptionsList = products.Select(l =>
                    model.Package.Products != null && model.Package.Products.Contains(l)
                        ? new PackageViewModel.CheckboxOptions() { IsChecked = true, Value = l }
                        : new PackageViewModel.CheckboxOptions() { IsChecked = false, Value = l })
                .ToList();

            var dateError1 = _packageService.PackageDateNotTooFarInTheFutureOrPast(model.Package!);
            var dateError2 = _packageService.PackageHasCorrectStartAndEnd(model.Package!);

            if (!dateError1)
                ModelState.AddModelError("DateError",
                    "Start date and end date must be today, tomorrow or the day after tomorrow");

            if (!dateError2)
                ModelState.AddModelError("DateError",
                    "Start time and end must be on the same day, the start must be earlier than the end time");

            return View(model);
        }


        if (_packageService.PackagesHasProductThatContainsAlcohol(model.Package!))
            model.Package!.EighteenPlus = true;

        _packageRepository.UpdatePackage(model.Package!);
        return Redirect("/");
    }

    [Authorize(Policy = "EmployeeOnly")]
    public IActionResult Delete(int id)
    {
        if (!_packageService.CanPackageBeAltered(_packageRepository.GetPackageById(id)))
            throw new InvalidOperationException();

        _packageRepository.RemovePackage(id);
        return Redirect("/Employee");
    }
}