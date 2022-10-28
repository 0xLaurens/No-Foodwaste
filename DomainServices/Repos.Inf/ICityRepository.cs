using Domain;

namespace DomainServices.Repos.Inf;

public interface ICityRepository
{
    public City? GetCityById(int id);
    public IQueryable<City>? GetCities();
    public void CreateCity(City city);
    public void UpdateCity(City city);
    public void DeleteCity(City city);
}