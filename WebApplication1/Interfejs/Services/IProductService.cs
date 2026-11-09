using TwojaAplikacja.Models;

namespace TwojaAplikacja.Services;

public interface IProductService
{
    IEnumerable<Product> GetAll();
    Product? GetById(int id);
    Product Add(Product product);
}