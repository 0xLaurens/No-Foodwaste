using Domain;

namespace DomainServices.Repos.Inf;

public interface ICityRepository
{
    public City GetCityById(int id);
    public List<City> GetCities();
}