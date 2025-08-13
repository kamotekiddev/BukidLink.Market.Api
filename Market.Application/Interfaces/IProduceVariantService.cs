using Market.Application.DTOs.ProduceVariant;
using Market.Domain.Entities;

namespace Market.Application.Interfaces;

public interface IProduceVariantService
{
    Task<ProduceVariant> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<ProduceVariant>> GetByProduceIdAsync(Guid produceId,
        CancellationToken cancellationToken = default);

    Task<ProduceVariant> AddAsync(AddProduceVariantDto dto, CancellationToken cancellationToken = default);

    Task<ProduceVariant> UpdateAsync(Guid id, UpdateProduceVariantDto dto,
        CancellationToken cancellationToken = default);

    Task<ProduceVariant> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}