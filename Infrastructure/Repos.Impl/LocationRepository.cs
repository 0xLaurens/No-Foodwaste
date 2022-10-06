using Domain;
using DomainServices.Repos.Inf;

namespace Infrastructure.Repos.Impl;

public interface LocationRepository : ILocationRepository
{
    public Location GetLocationById(int id);
    public List<Location> GetLocations();
}