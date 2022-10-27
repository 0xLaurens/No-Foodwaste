using Domain;
using DomainServices.Repos.Inf;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repos.Impl;

public class ProductRepository : IProductRepository
{
    private readonly FoodDbContext _context;

    public ProductRepository(IDbContextFactory<FoodDbContext> dbContextFactory)
    {
        _context = dbContextFactory.CreateDbContext();
    }

    

    public Product GetProductById(int id)
    {
        return GetProducts().SingleOrDefault(p => p.ProductId == id)!;
    }

    public IQueryable<Product> GetProducts()
    {
        return _context.Products!;
    }
}