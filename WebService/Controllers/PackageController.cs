using AutoMapper;
using Domain;
using DomainServices.Repos.Inf;
using Microsoft.AspNetCore.Mvc;
using WebService.Models.Package;

namespace WebService.Controllers;

[ApiController]
[Route("[controller]")]
public class PackageController: ControllerBase
{
    private readonly IPackageRepository _packageRepository;
    private readonly IMapper _mapper;

    public PackageController(IMapper mapper, IPackageRepository packageRepository)
    {
        _mapper = mapper;
        _packageRepository = packageRepository;
    }

    [HttpGet]
    public ActionResult<IQueryable<Package>> Get()
    {
        return Ok(_packageRepository.GetPackages());
    }

    [HttpGet("{id}")]
    public ActionResult<Package> Get(int id)
    {
        return Ok(_packageRepository.GetPackageById(id));
    }

    [HttpPost]
    public ActionResult<NewCreatedPackageDto> CreatePackage([FromBody] NewPackageDto newPackage)
    {
        var packageToCreate = new Package
        {
            Name = newPackage.Name,
            Thumbnail = newPackage.Thumbnail,
            ThumbnailFormat = newPackage.ThumbnailFormat,
            CityId = newPackage.CityId,
            CafeteriaId = newPackage.CafeteriaId,
            StartTimeSlot = newPackage.StartTimeSlot,
            EndTimeSlot = newPackage.EndTimeSlot,
            EighteenPlus = newPackage.EighteenPlus,
            Price = newPackage.Price,
            Category = newPackage.Category,
            StudentId = newPackage.StudentId 
        };

        _packageRepository.CreatePackage(packageToCreate);
        var createdResource = _mapper.Map<NewCreatedPackageDto>(newPackage);
        createdResource.PackageId = packageToCreate.PackageId;

        return CreatedAtAction(nameof(Get), new { id = createdResource.PackageId }, createdResource);
    }

    [HttpPut("{id}")]
    public ActionResult<UpdatedPackageDto> UpdatePackage([FromBody] UpdatedPackageDto packageToChange, int id)
    {
        var packageToEdit = _packageRepository.GetPackageById(id);

        if (id != packageToChange.PackageId) return BadRequest();

        
        _packageRepository.UpdatePackage(packageToEdit!);

        var editedResource = _mapper.Map<UpdatedPackageDto>(packageToChange);

        return Ok(editedResource);
    }

    [HttpDelete("{id}")]
    public ActionResult DeletePackage(int id)
    {
        var package = _packageRepository.GetPackageById(id);
        _packageRepository.DeletePackage(package!);
        return new NoContentResult();
    }
}