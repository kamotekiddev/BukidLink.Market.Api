using Market.Application.DTOs.ProductCategory;
using Market.Application.Interfaces;
using Market.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Market.Application.Services;

public class ProductCategoryService : IProductCategoryService
{
    private readonly IProductCategoryRepository _repository;

    public ProductCategoryService(IProductCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProductCategory> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var category = await _repository.GetByIdAsync(id, cancellationToken);
        if (category is null) throw new KeyNotFoundException("category not found");
        return category;
    }

    public async Task<ICollection<ProductCategory>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _repository.GetAllAsync(cancellationToken);
    }

    public async Task<ProductCategory> AddAsync(AddProductCategoryDto dto,
        CancellationToken cancellationToken = default)
    {
        var nameExists = await _repository.NameExistsAsync(dto.Name, cancellationToken);
        if (nameExists) throw new BadHttpRequestException("Name already exists.");

        var category = new ProductCategory
        {
            Name = dto.Name
        };

        return await _repository.AddAsync(category, cancellationToken);
    }

    public async Task<ProductCategory> UpdateAsync(Guid id, UpdateProductCategoryDto dto,
        CancellationToken cancellationToken = default)
    {
        var category = await GetByIdAsync(id, cancellationToken);
        category.Name = dto.Name;

        return await _repository.UpdateAsync(category, cancellationToken);
    }

    public async Task<ProductCategory> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var category = await GetByIdAsync(id, cancellationToken);
        await _repository.DeleteAsync(category, cancellationToken);
        return category;
    }
}