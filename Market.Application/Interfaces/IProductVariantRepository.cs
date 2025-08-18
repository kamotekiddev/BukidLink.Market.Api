using Market.Domain.Entities;

namespace Market.Application.Interfaces;

public interface IProductVariantRepository
{
    Task<ProductVariant> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<ProductVariant>>
        GetByProduceIdAsync(Guid produceId, CancellationToken cancellationToken = default);

    Task<ProductVariant> AddAsync(ProductVariant variant, CancellationToken cancellationToken = default);
    Task<ProductVariant> UpdateAsync(ProductVariant variant, CancellationToken cancellationToken = default);
    Task<ProductVariant> DeleteAsync(ProductVariant variant, CancellationToken cancellationToken = default);
}