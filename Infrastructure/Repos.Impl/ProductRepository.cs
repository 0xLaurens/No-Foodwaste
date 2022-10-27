using Domain;
using DomainServices.Repos.Inf;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repos.Impl;

public class ProductRepository : IProductRepository
{
    private readonly FoodDbContext _context;

    public ProductRepository(FoodDbContext context, IDbContextFactory<FoodDbContext>? contextFactory)
    {
        _context = context;
        if (contextFactory != null) _context = contextFactory.CreateDbContext();
    }

    public Product GetProductById(int id)
    {
        return _context.Products!.SingleOrDefault(p => p.ProductId == id)!;
    }

    public IQueryable<Product> GetProducts()
    {
        return _context.Products!;
    }
}