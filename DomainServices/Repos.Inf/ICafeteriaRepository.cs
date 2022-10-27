using Domain;

namespace DomainServices.Repos.Inf;

public interface ICafeteriaRepository
{
    public Cafeteria GetCafeteriaById(int id);
    public IQueryable<Cafeteria> GetCafeterias();
    public void CreateCafeteria(Cafeteria cafeteria);
    public void UpdateCafeteria(Cafeteria cafeteria);
    public void DeleteCafeteria(Cafeteria cafeteria);
}