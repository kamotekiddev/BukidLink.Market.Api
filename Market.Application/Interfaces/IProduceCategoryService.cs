using Market.Application.DTOs.ProduceCategory;
using Market.Domain.Entities;

namespace Market.Application.Interfaces;

public interface IProduceCategoryService
{
    Task<ProduceCategory> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<ProduceCategory>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ProduceCategory> AddAsync(AddProduceCategoryDto dto, CancellationToken cancellationToken = default);

    Task<ProduceCategory> UpdateAsync(Guid id, UpdateProduceCategoryDto dto,
        CancellationToken cancellationToken = default);

    Task<ProduceCategory> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}