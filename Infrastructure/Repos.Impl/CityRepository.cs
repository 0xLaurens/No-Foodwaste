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
}