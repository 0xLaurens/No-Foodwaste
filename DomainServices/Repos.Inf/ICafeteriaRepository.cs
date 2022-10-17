using Domain;

namespace DomainServices.Repos.Inf;

public interface ICafeteriaRepository
{
    public Cafeteria GetCafeteriaById(int id);
    public List<Cafeteria> GetCafeterias();
}