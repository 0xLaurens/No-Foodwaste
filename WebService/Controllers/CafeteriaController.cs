using AutoMapper;
using Domain;
using DomainServices.Repos.Inf;
using Microsoft.AspNetCore.Mvc;
using WebService.Models.Cafeteria;

namespace WebService.Controllers;

[ApiController]
[Route("[controller]")]
public class CafeteriaController : ControllerBase
{
    private readonly ICafeteriaRepository _cafeteriaRepository;
    private readonly ICityRepository _cityRepository;
    private readonly ILocationRepository _locationRepository;
    private readonly IMapper _mapper;

    public CafeteriaController(ICafeteriaRepository cafeteriaRepository, IMapper mapper, ICityRepository cityRepository,
        ILocationRepository locationRepository)
    {
        _cafeteriaRepository = cafeteriaRepository;
        _mapper = mapper;
        _cityRepository = cityRepository;
        _locationRepository = locationRepository;
    }

    [HttpGet]
    public ActionResult<IQueryable<Cafeteria>> Get()
    {
        return Ok(_cafeteriaRepository.GetCafeterias());
    }

    [HttpGet("{id}")]
    public ActionResult<Cafeteria> Get(int id)
    {
        return Ok(_cafeteriaRepository.GetCafeteriaById(id));
    }

    [HttpPost]
    public ActionResult<NewCreatedCafteriaDTO> CreateCafeteria([FromBody] NewCafeteriaDTO newCafe)
    {
        var cafeToCreate = new Cafeteria
        {
            CityId = newCafe.CityId, LocationId = newCafe.LocationId,
            Location = _locationRepository.GetLocationById(newCafe.LocationId)
        };

        _cafeteriaRepository.CreateCafeteria(cafeToCreate);
        var createdResource = _mapper.Map<NewCreatedCafteriaDTO>(newCafe);
        createdResource.CafeteriaId = cafeToCreate.CafeteriaId;

        return CreatedAtAction(nameof(Get), new { id = createdResource.CafeteriaId }, createdResource);
    }

    [HttpPut("{id}")]
    public ActionResult<UpdatedCafeteriaDto> UpdateCafeteria([FromBody] UpdatedCafeteriaDto cafeToChange, int id)
    {
        var cafeToEdit = _cafeteriaRepository.GetCafeteriaById(id);

        if (id != cafeToChange.CafeteriaId) return BadRequest();

        cafeToEdit.CityId = cafeToChange.CityId;
        cafeToEdit.Location = _locationRepository.GetLocationById(cafeToChange.LocationId);
        cafeToEdit.LocationId = cafeToChange.LocationId;

        _cafeteriaRepository.UpdateCafeteria(cafeToEdit);

        var editedResource = _mapper.Map<UpdatedCafeteriaDto>(cafeToChange);

        return Ok(editedResource);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteCafeteria(int id)
    {
        var cafe = _cafeteriaRepository.GetCafeteriaById(id);
        _cafeteriaRepository.DeleteCafeteria(cafe);
        return new NoContentResult();
    }
}