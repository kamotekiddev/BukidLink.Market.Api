using AutoMapper;
using Market.Application.DTOs.ProductCategory;
using Market.Application.Interfaces;
using Market.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Market.Application.Services;

public class ProductCategoryService : IProductCategoryService
{
    private readonly IProductCategoryRepository _repository;
    private readonly IMapper _mapper;

    public ProductCategoryService(IProductCategoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ProductCategory> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var category = await _repository.GetByIdAsync(id, cancellationToken);
        if (category is null) throw new KeyNotFoundException("category not found");
        return category;
    }

    public async Task<ICollection<ProductCategoryDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var categories = await _repository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<ProductCategoryDto>>(categories);
    }

    public async Task<ProductCategoryDto> AddAsync(AddProductCategoryDto dto,
        CancellationToken cancellationToken = default)
    {
        var nameExists = await _repository.NameExistsAsync(dto.Name, cancellationToken);
        if (nameExists) throw new BadHttpRequestException("Name already exists.");

        var category = new ProductCategory
        {
            Name = dto.Name
        };

        await _repository.AddAsync(category, cancellationToken);
        return _mapper.Map<ProductCategoryDto>(category);
    }

    public async Task<ProductCategoryDto> UpdateAsync(Guid id, UpdateProductCategoryDto dto,
        CancellationToken cancellationToken = default)
    {
        var category = await GetByIdAsync(id, cancellationToken);
        category.Name = dto.Name;

        await _repository.UpdateAsync(category, cancellationToken);
        return _mapper.Map<ProductCategoryDto>(category);
    }

    public async Task<ProductCategoryDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var category = await GetByIdAsync(id, cancellationToken);
        await _repository.DeleteAsync(category, cancellationToken);
        return _mapper.Map<ProductCategoryDto>(category);
    }
}