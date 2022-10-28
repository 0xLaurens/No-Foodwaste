using Domain;

namespace DomainServices.Repos.Inf;

public interface IProductRepository
{
    public Product GetProductById(int id);
    public IQueryable<Product> GetProducts();
}