using Domain;
using DomainServices.Repos.Inf;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repos.Impl;

public class ProductRepository : IProductRepository
{
    private readonly FoodDbContext _context;

    public ProductRepository(FoodDbContext context)
    {
        _context = context;
    }
    public Product GetProductById(int id)
    {
        return _context.Products.SingleOrDefault(p => p.ProductId == id);
    }

    public List<Product> GetProducts()
    {
        return _context.Products
            .ToList();
    }
}