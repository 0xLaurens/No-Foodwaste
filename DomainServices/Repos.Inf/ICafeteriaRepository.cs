using Domain;

namespace DomainServices.Repos.Inf;

public interface ICafeteriaRepository
{
    public Cafeteria GetCafeteriaById(int id);
    public IQueryable<Cafeteria> GetCafeterias();
}