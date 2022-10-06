using Domain;
using DomainServices.Repos.Inf;

namespace Infrastructure.Repos.Impl;

public interface CafeteriaRepository : ICafeteriaRepository
{
    public Cafeteria GetCafeteriaById(int id);
    public List<Cafeteria> GetCafeterias();
}