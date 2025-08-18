using Market.Domain.Entities;

namespace Market.Application.Interfaces;

public interface IProductRepository
{
    Task<Product> AddProduceAsync(Product product);
    Task<Product> UpdateProduceAsync(Product product);
    ValueTask<Product?> GetProduceByIdAsync(Guid produceId);
    Task<Product> DeleteProduceByIdAsync(Product product);
    Task<List<Product>> GetAllProduceAsync();
}