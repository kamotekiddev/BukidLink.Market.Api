using Market.Application.DTOs.ProductVariant;
using Market.Domain.Entities;

namespace Market.Application.Interfaces;

public interface IProductVariantService
{
    Task<ProductVariantDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<ProductVariant>> GetByProduceIdAsync(Guid produceId,
        CancellationToken cancellationToken = default);

    Task<ProductVariantDto> AddAsync(AddProductVariantDto dto, CancellationToken cancellationToken = default);

    Task<ProductVariantDto> UpdateAsync(Guid id, UpdateProductVariantDto dto,
        CancellationToken cancellationToken = default);

    Task<ProductVariantDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}