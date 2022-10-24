using Domain;

namespace DomainServices.Repos.Inf;

public interface ILocationRepository
{
    public Location GetLocationById(int id);
    public IQueryable<Location> GetLocations();
}