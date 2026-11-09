using TwojaAplikacja.Models;

namespace TwojaAplikacja.Services;

public class ProductService : IProductService
{
    private readonly List<Product> _products = new()
    {
        new Product { Id = 1, Name = "Laptop", Price = 3500.00m, Category = "Elektronika" },
        new Product { Id = 2, Name = "Klawiatura mechaniczna", Price = 299.99m, Category = "Akcesoria" },
        new Product { Id = 3, Name = "Kubek termiczny", Price = 59.50m, Category = "Dom" }
    };

    public IEnumerable<Product> GetAll()
    {
        return _products;
    }

    public Product? GetById(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public Product Add(Product product)
    {
        int nextId = _products.Count > 0 ? _products.Max(p => p.Id) + 1 : 1;
        product.Id = nextId;
        _products.Add(product);

        return product;
    }
}