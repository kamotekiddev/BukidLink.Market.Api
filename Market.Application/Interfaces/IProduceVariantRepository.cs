using Market.Domain.Entities;

namespace Market.Application.Interfaces;

public interface IProduceVariantRepository
{
    Task<ProduceVariant?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<ProduceVariant>>
        GetByProduceIdAsync(Guid produceId, CancellationToken cancellationToken = default);

    Task<ProduceVariant> AddAsync(ProduceVariant variant, CancellationToken cancellationToken = default);
    Task<ProduceVariant> UpdateAsync(ProduceVariant variant, CancellationToken cancellationToken = default);
    Task<ProduceVariant> DeleteAsync(ProduceVariant variant, CancellationToken cancellationToken = default);
}