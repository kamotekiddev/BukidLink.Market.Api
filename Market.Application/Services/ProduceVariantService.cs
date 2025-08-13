using Market.Application.DTOs.ProduceVariant;
using Market.Application.Interfaces;
using Market.Domain.Entities;

namespace Market.Application.Services;

public class ProduceVariantService : IProduceVariantService
{
    private readonly IProduceVariantRepository _repository;

    public ProduceVariantService(IProduceVariantRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProduceVariant> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _repository.GetByIdAsync(id, cancellationToken) ??
               throw new KeyNotFoundException("Produce variant does not exist.");
    }

    public async Task<IEnumerable<ProduceVariant>> GetByProduceIdAsync(Guid produceId,
        CancellationToken cancellationToken = default)
    {
        return await _repository.GetByProduceIdAsync(produceId, cancellationToken);
    }

    public async Task<ProduceVariant> AddAsync(AddProduceVariantDto dto, CancellationToken cancellationToken = default)
    {
        var produceVariant = new ProduceVariant
        {
            ProduceId = dto.ProduceId,
            Price = dto.Price,
            UnitOfMeasure = dto.UnitOfMeasure,
            UniSize = dto.UniSize,
        };

        await _repository.AddAsync(produceVariant, cancellationToken);
        return produceVariant;
    }

    public async Task<ProduceVariant> UpdateAsync(Guid id, UpdateProduceVariantDto dto,
        CancellationToken cancellationToken = default)
    {
        var variant = await GetByIdAsync(id, cancellationToken);

        variant.Price = dto.Price;
        variant.UnitOfMeasure = dto.UnitOfMeasure;
        variant.UniSize = dto.UniSize;

        await _repository.UpdateAsync(variant, cancellationToken);
        return variant;
    }

    public async Task<ProduceVariant> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var variant = await GetByIdAsync(id, cancellationToken);

        await _repository.DeleteAsync(variant, cancellationToken);
        return variant;
    }
}