using Domain;
using DomainServices.Repos.Inf;

namespace Infrastructure.Repos.Impl;

public class CafeteriaRepository : ICafeteriaRepository
{
    private readonly FoodDbContext _context;

    public CafeteriaRepository(FoodDbContext context)
    {
        _context = context;
    }
    
    public Cafeteria GetCafeteriaById(int id)
    {
        return _context.Cafeterias.SingleOrDefault(c => c.CafeteriaId == id);
    }

    public List<Cafeteria> GetCafeterias()
    {
        return _context.Cafeterias.ToList();
    }
}