using Market.Application.DTOs.ProduceVariant;
using Market.Domain.Entities;

namespace Market.Application.Interfaces;

public interface IProduceVariantService
{
    Task<ProduceVariantDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<ProduceVariant>> GetByProduceIdAsync(Guid produceId,
        CancellationToken cancellationToken = default);

    Task<ProduceVariantDto> AddAsync(AddProduceVariantDto dto, CancellationToken cancellationToken = default);

    Task<ProduceVariantDto> UpdateAsync(Guid id, UpdateProduceVariantDto dto,
        CancellationToken cancellationToken = default);

    Task<ProduceVariantDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}