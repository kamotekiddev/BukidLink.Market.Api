using AutoMapper;
using Market.Application.DTOs.ProduceVariant;
using Market.Application.Interfaces;
using Market.Domain.Entities;

namespace Market.Application.Services;

public class ProduceVariantService : IProduceVariantService
{
    private readonly IProduceVariantRepository _repository;
    private readonly IMapper _mapper;

    public ProduceVariantService(IProduceVariantRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ProduceVariantDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var variant = await _repository.GetByIdAsync(id, cancellationToken);
        return _mapper.Map<ProduceVariantDto>(variant);
    }

    public async Task<IEnumerable<ProduceVariant>> GetByProduceIdAsync(Guid produceId,
        CancellationToken cancellationToken = default)
    {
        return await _repository.GetByProduceIdAsync(produceId, cancellationToken);
    }

    public async Task<ProduceVariantDto> AddAsync(AddProduceVariantDto dto,
        CancellationToken cancellationToken = default)
    {
        var produceVariant = new ProduceVariant
        {
            ProduceId = dto.ProduceId,
            Price = dto.Price,
            UnitOfMeasure = dto.UnitOfMeasure,
            UniSize = dto.UniSize,
        };

        await _repository.AddAsync(produceVariant, cancellationToken);
        return _mapper.Map<ProduceVariantDto>(produceVariant);
    }

    public async Task<ProduceVariantDto> UpdateAsync(Guid id, UpdateProduceVariantDto dto,
        CancellationToken cancellationToken = default)
    {
        var variant = await _repository.GetByIdAsync(id, cancellationToken);

        await _repository.UpdateAsync(variant, cancellationToken);
        return _mapper.Map<ProduceVariantDto>(variant);
    }

    public async Task<ProduceVariantDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var variant = await _repository.GetByIdAsync(id, cancellationToken);

        await _repository.DeleteAsync(variant, cancellationToken);
        return _mapper.Map<ProduceVariantDto>(variant);
    }
}