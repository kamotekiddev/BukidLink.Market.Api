using Market.Domain.Entities;

namespace Market.Application.Interfaces
{
    public interface IProduceCategoryRepository
    {
        Task<ProduceCategory?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<ProduceCategory>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<IReadOnlyList<ProduceCategory>> GetByIdsAsync(IEnumerable<Guid> ids,
            CancellationToken cancellationToken = default);

        Task<ProduceCategory> AddAsync(ProduceCategory category, CancellationToken cancellationToken = default);
        Task<ProduceCategory> UpdateAsync(ProduceCategory category, CancellationToken cancellationToken = default);
        Task<ProduceCategory> DeleteAsync(ProduceCategory category, CancellationToken cancellationToken = default);

        Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> NameExistsAsync(string name, CancellationToken cancellationToken = default);
    }
}