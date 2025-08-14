using Market.Application.DTOs.ProduceCategory;
using Market.Application.Interfaces;
using Market.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Market.Application.Services;

public class ProduceCategoryService : IProduceCategoryService
{
    private readonly IProduceCategoryRepository _repository;

    public ProduceCategoryService(IProduceCategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProduceCategory> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var category = await _repository.GetByIdAsync(id, cancellationToken);
        if (category is null) throw new KeyNotFoundException("category not found");
        return category;
    }

    public async Task<IReadOnlyList<ProduceCategory>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _repository.GetAllAsync(cancellationToken);
    }

    public async Task<ProduceCategory> AddAsync(AddProduceCategoryDto dto,
        CancellationToken cancellationToken = default)
    {
        var nameExists = await _repository.NameExistsAsync(dto.Name, cancellationToken);
        if (nameExists) throw new BadHttpRequestException("Name already exists.");

        var category = new ProduceCategory
        {
            Name = dto.Name
        };

        return await _repository.AddAsync(category, cancellationToken);
    }

    public async Task<ProduceCategory> UpdateAsync(Guid id, UpdateProduceCategoryDto dto,
        CancellationToken cancellationToken = default)
    {
        var category = await GetByIdAsync(id, cancellationToken);
        category.Name = dto.Name;

        return await _repository.UpdateAsync(category, cancellationToken);
    }

    public async Task<ProduceCategory> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var category = await GetByIdAsync(id, cancellationToken);
        await _repository.DeleteAsync(category, cancellationToken);
        return category;
    }
}