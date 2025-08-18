using Market.Domain.Entities;

namespace Market.Application.Interfaces;

public interface IProductRepository
{
    Task<Product> AddProductAsync(Product product);
    Task<Product> UpdateProductAsync(Product product);
    ValueTask<Product?> GetProductByIdAsync(Guid produceId);
    Task<Product> DeleteProductByIdAsync(Product product);
    Task<List<Product>> GetAllProductsAsync();
    Task<List<Product>> GetByCategoryIdAsync(Guid categoryId);
}