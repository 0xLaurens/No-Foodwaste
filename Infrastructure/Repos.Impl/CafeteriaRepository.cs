using Domain;
using DomainServices.Repos.Inf;
using Microsoft.EntityFrameworkCore;

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
        return GetCafeterias().SingleOrDefault(c => c.CafeteriaId == id)!;
    }

    public IQueryable<Cafeteria> GetCafeterias()
    {
        return _context.Cafeterias!
            .Include(c => c.Location);
    }

    public void CreateCafeteria(Cafeteria cafeteria)
    {
        _context.Cafeterias!.Add(cafeteria);
        _context.SaveChanges();
    }

    public void UpdateCafeteria(Cafeteria cafeteria)
    {
        _context.Cafeterias!.Update(cafeteria);
        _context.SaveChanges();
    }

    public void DeleteCafeteria(Cafeteria cafeteria)
    {
        _context.Cafeterias!.Remove(cafeteria);
        _context.SaveChanges();
    }
}