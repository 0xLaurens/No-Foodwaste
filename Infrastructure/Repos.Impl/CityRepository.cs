using Domain;
using DomainServices.Repos.Inf;

namespace Infrastructure.Repos.Impl;

public interface CityRepository : ICityRepository
{
    public City GetCityById(int id);
    public List<City> GetCities();
}