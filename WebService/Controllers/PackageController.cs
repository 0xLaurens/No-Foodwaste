using AutoMapper;
using Domain;
using DomainServices.Repos.Inf;
using Microsoft.AspNetCore.Mvc;
using WebService.Models.Package;

namespace WebService.Controllers;

[ApiController]
[Route("[controller]")]
public class PackageController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IPackageRepository _packageRepository;
    private readonly IStudentRepository _studentRepository;

    public PackageController(IMapper mapper, IPackageRepository packageRepository, IStudentRepository studentRepository)
    {
        _mapper = mapper;
        _packageRepository = packageRepository;
        _studentRepository = studentRepository;
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
    
    [HttpPut("{packageId:int}/student/{studentId:int}")]
    public ActionResult<NewPackageDto> ReservePackage([FromBody]PackageReserveDto reservation, int packageId, int studentId)
    {
       var package = _packageRepository.GetPackageById(packageId);
       var student = _studentRepository.GetStudentById(studentId);
       if (package == null || student == null || studentId != reservation.StudentId || packageId != package.PackageId) return BadRequest();
       if (!package!.CanPackageBeAltered()) return BadRequest("Package cannot be altered");

       var packagePayload = new Package
       {
           PackageId = reservation.PackageId,
           Name = package.Name,
           Thumbnail = package.Thumbnail,
           ThumbnailFormat = package.ThumbnailFormat,
           CityId = package.CityId,
           City = package.City,
           CafeteriaId = package.CafeteriaId,
           Cafeteria = package.Cafeteria,
           Products = package.Products,
           StartTimeSlot = package.StartTimeSlot,
           EndTimeSlot = package.EndTimeSlot,
           EighteenPlus = package.EighteenPlus,
           Price = package.Price,
           Category = package.Category,
           StudentId = reservation.StudentId 
       };
       
       _packageRepository.UpdatePackage(packagePayload);
       
       var reservedPackage = _mapper.Map<UpdatedPackageDto>(packagePayload);
       
       return Ok(reservedPackage);
    }

    [HttpPut("{id}")]
    public ActionResult<UpdatedPackageDto> UpdatePackage([FromBody] UpdatedPackageDto packageToChange, int id)
    {
        var packageToEdit = _packageRepository.GetPackageById(id);

        if (id != packageToChange.PackageId) return BadRequest();
        if (!packageToEdit!.CanPackageBeAltered()) return BadRequest("Package cannot be altered");

        var packageUpdate = new Package
        {
            PackageId = packageToChange.PackageId,
            Name = packageToChange.Name,
            CityId = packageToChange.CityId,
            CafeteriaId = packageToChange.CafeteriaId,
            StartTimeSlot = packageToChange.StartTimeSlot,
            EndTimeSlot = packageToChange.EndTimeSlot,
            EighteenPlus = packageToChange.EighteenPlus,
            Price = packageToChange.Price,
            Category = packageToChange.Category,
            StudentId = packageToChange.StudentId 
        };
        
        _packageRepository.UpdatePackage(packageUpdate);

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