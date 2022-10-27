using Location = Domain.Location;
using DomainServices.Repos.Inf;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repos.Impl;

public class LocationRepository : ILocationRepository
{
    private readonly FoodDbContext _context;

    public LocationRepository(IDbContextFactory<FoodDbContext> dbContextFactory)
    {
        _context = dbContextFactory.CreateDbContext();
    }

    public Location GetLocationById(int id)
    {
        return _context.Locations!.SingleOrDefault(l => l.LocationId == id)!;
    }

    public IQueryable<Location> GetLocations()
    {
        return _context.Locations!
            .Include(l => l.Employees);
    }
}