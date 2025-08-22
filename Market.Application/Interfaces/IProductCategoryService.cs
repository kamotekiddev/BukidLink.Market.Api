using Market.Application.DTOs.ProductCategory;
using Market.Domain.Entities;

namespace Market.Application.Interfaces;

public interface IProductCategoryService
{
    Task<ProductCategory> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<ICollection<ProductCategoryDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ProductCategoryDto> AddAsync(AddProductCategoryDto dto, CancellationToken cancellationToken = default);

    Task<ProductCategoryDto> UpdateAsync(Guid id, UpdateProductCategoryDto dto,
        CancellationToken cancellationToken = default);

    Task<ProductCategoryDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}