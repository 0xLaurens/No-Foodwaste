using Domain;
using DomainServices.Repos.Inf;

namespace Infrastructure.Repos.Impl;

public class CityRepository : ICityRepository
{
    private readonly FoodDbContext _context;

    public CityRepository(FoodDbContext context)
    {
        _context = context;
    }

    public City? GetCityById(int id)
    {
        return GetCities()?
            .SingleOrDefault(c => c.CityId == id)!;
    }

    public IQueryable<City>? GetCities()
    {
        return _context.Cities?
            .OrderBy(c => c.Name);
    }

    public void CreateCity(City city)
    {
        _context.Cities!.Add(city);
        _context.SaveChanges();
    }

    public void UpdateCity(City city)
    {
        _context.Cities!.Update(city);
        _context.SaveChanges();
    }

    public void DeleteCity(City city)
    {
        _context.Cities!.Remove(city);
        _context.SaveChanges();
    }
}