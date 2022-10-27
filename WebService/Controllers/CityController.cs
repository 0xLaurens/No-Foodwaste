using AutoMapper;
using Domain;
using DomainServices.Repos.Inf;
using Microsoft.AspNetCore.Mvc;
using WebService.Models;
using WebService.Models.Cafeteria;
using WebService.Models.City;

namespace WebService.Controllers;

[ApiController]
[Route("[controller]")]
public class CityController : ControllerBase
{
    private readonly ICityRepository _cityRepository;
    private readonly ILocationRepository _locationRepository;
    private readonly IMapper _mapper;

    public CityController(IMapper mapper, ICityRepository cityRepository, ILocationRepository locationRepository)
    {
        _mapper = mapper;
        _cityRepository = cityRepository;
        _locationRepository = locationRepository;
    }

    [HttpGet]
    public ActionResult<IQueryable<City>> Get()
    {
        return Ok(_cityRepository.GetCities());
    }

    [HttpGet("{id}")]
    public ActionResult<City> Get(int id)
    {
        return Ok(_cityRepository.GetCityById(id));
    }

    [HttpPost]
    public ActionResult<NewCreatedCafteriaDTO> CreateCity([FromBody] NewCityDTO newCity)
    {
        var cityToCreate = new City
        {
            Name = newCity.Name
        };

        _cityRepository.CreateCity(cityToCreate);
        var createdResource = _mapper.Map<NewCreatedCityDTO>(newCity);
        createdResource.CityId = cityToCreate.CityId;

        return CreatedAtAction(nameof(Get), new { id = createdResource.CityId }, createdResource);
    }

    [HttpPut("{id}")]
    public ActionResult<NewCreatedCafteriaDTO> UpdateCity([FromBody] UpdatedCityDto cityToChange, int id)
    {
        var cityToEdit = _cityRepository.GetCityById(id);

        if (id != cityToChange.CityId) return BadRequest();

        cityToEdit!.Name = cityToChange.Name;

        _cityRepository.UpdateCity(cityToEdit!);

        var editedResource = _mapper.Map<UpdatedCityDto>(cityToChange);

        return Ok(editedResource);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteCity(int id)
    {
        var city = _cityRepository.GetCityById(id);
        _cityRepository.DeleteCity(city!);
        return new NoContentResult();
    }
}