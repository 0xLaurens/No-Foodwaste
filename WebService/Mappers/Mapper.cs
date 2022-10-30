using AutoMapper;
using Domain;
using WebService.Models.Cafeteria;
using WebService.Models.City;
using WebService.Models.Employee;
using WebService.Models.Package;

namespace WebService.Mappers;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<NewCafeteriaDTO, NewCreatedCafteriaDTO>();
        CreateMap<Cafeteria, UpdatedCafeteriaDto>();

        CreateMap<NewCityDTO, NewCreatedCityDTO>();
        CreateMap<City, UpdatedCityDto>();

        CreateMap<NewEmployeeDto, NewCreatedEmployeeDto>();
        CreateMap<Employee, UpdatedEmployeeDto>();

        CreateMap<Package, UpdatedPackageDto>();
    }
}