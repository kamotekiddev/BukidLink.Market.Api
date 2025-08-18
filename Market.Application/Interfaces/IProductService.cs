using Market.Application.DTOs.Product;
using Market.Domain.Entities;

namespace Market.Application.Interfaces;

public interface IProductService
{
    Task<ProductDto> CreateProductAsync(AddProductDto dto);
    Task<List<ProductDto>> GetAllProductsAsync();
    Task<ProductDto> GetProductByIdAsync(Guid produceId);
    Task<ProductDto> UpdateProductAsync(Guid produceId, UpdateProductDto dto);
    Task<ProductDto> DeleteProductByIdAsync(Guid produceId);
}