using Domain;
using DomainServices.Repos.Inf;

namespace Infrastructure.Repos.Impl;

public interface ProductRepository : IProductRepository
{
    public Product GetProductById(int id);
    public List<Product> GetProducts();
}