namespace DomainServices.Repos.Inf;

public interface Product
{
    public Product GetProductById(int id);
    public List<Product> GetProducts();
}