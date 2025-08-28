using Market.Application.DTOs.Product;

namespace Market.Application.Interfaces;

public interface IProductService
{
    Task<ProductDto> CreateProductAsync(AddProductDto dto);
    Task<List<ProductListItemDto>> GetAllProductsAsync();
    Task<ProductDto> GetProductByIdAsync(Guid productId);
    Task<ProductDto> UpdateProductAsync(Guid productId, UpdateProductDto dto);
    Task<ProductDto> DeleteProductByIdAsync(Guid productId);
    Task<List<ProductListItemDto>> GetProductsByCategoryIdAsync(Guid categoryId);
    Task<List<ProductListItemDto>> SearchProductsAsync(Guid? categoryId, string? searchTerm);
}