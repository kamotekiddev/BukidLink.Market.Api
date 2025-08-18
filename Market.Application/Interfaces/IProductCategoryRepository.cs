using Market.Domain.Entities;

namespace Market.Application.Interfaces
{
    public interface IProductCategoryRepository
    {
        Task<ProductCategory?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<ProductCategory>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<IReadOnlyList<ProductCategory>> GetByIdsAsync(IEnumerable<Guid> ids,
            CancellationToken cancellationToken = default);

        Task<ProductCategory> AddAsync(ProductCategory category, CancellationToken cancellationToken = default);
        Task<ProductCategory> UpdateAsync(ProductCategory category, CancellationToken cancellationToken = default);
        Task<ProductCategory> DeleteAsync(ProductCategory category, CancellationToken cancellationToken = default);

        Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> NameExistsAsync(string name, CancellationToken cancellationToken = default);
    }
}