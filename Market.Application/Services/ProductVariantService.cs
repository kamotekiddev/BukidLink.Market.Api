using AutoMapper;
using Market.Application.DTOs.ProductVariant;
using Market.Application.Interfaces;
using Market.Domain.Entities;

namespace Market.Application.Services;

public class ProductVariantService : IProductVariantService
{
    private readonly IProductVariantRepository _repository;
    private readonly IMapper _mapper;

    public ProductVariantService(IProductVariantRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ProductVariantDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var variant = await _repository.GetByIdAsync(id, cancellationToken);
        return _mapper.Map<ProductVariantDto>(variant);
    }

    public async Task<IEnumerable<ProductVariant>> GetByProduceIdAsync(Guid produceId,
        CancellationToken cancellationToken = default)
    {
        return await _repository.GetByProduceIdAsync(produceId, cancellationToken);
    }

    public async Task<ProductVariantDto> AddAsync(AddProductVariantDto dto,
        CancellationToken cancellationToken = default)
    {
        var produceVariant = new ProductVariant
        {
            ProductId = dto.ProduceId,
            Price = dto.Price,
            UnitOfMeasure = dto.UnitOfMeasure,
            UniSize = dto.UniSize,
        };

        await _repository.AddAsync(produceVariant, cancellationToken);
        return _mapper.Map<ProductVariantDto>(produceVariant);
    }

    public async Task<ProductVariantDto> UpdateAsync(Guid id, UpdateProductVariantDto dto,
        CancellationToken cancellationToken = default)
    {
        var variant = await _repository.GetByIdAsync(id, cancellationToken);

        await _repository.UpdateAsync(variant, cancellationToken);
        return _mapper.Map<ProductVariantDto>(variant);
    }

    public async Task<ProductVariantDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var variant = await _repository.GetByIdAsync(id, cancellationToken);

        await _repository.DeleteAsync(variant, cancellationToken);
        return _mapper.Map<ProductVariantDto>(variant);
    }
}