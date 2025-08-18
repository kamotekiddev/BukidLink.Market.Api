using Market.Application.DTOs.ProductCategory;
using Market.Domain.Entities;

namespace Market.Application.Interfaces;

public interface IProductCategoryService
{
    Task<ProductCategory> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<ProductCategory>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ProductCategory> AddAsync(AddProductCategoryDto dto, CancellationToken cancellationToken = default);

    Task<ProductCategory> UpdateAsync(Guid id, UpdateProductCategoryDto dto,
        CancellationToken cancellationToken = default);

    Task<ProductCategory> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}