using Market.Application.DTOs.Product;

namespace Market.Application.Interfaces;

public interface IProductService
{
    Task<ProductDto> CreateProductAsync(AddProductDto dto);
    Task<List<ProductDto>> GetAllProductsAsync();
    Task<ProductDto> GetProductByIdAsync(Guid productId);
    Task<ProductDto> UpdateProductAsync(Guid productId, UpdateProductDto dto);
    Task<ProductDto> DeleteProductByIdAsync(Guid productId);
    Task<List<ProductDto>> GetProductsByCategoryIdAsync(Guid categoryId);
    Task<List<ProductDto>> SearchProductsAsync(Guid? categoryId, string? searchTerm);
}