using Market.Application.Interfaces;
using Market.Domain.Entities;
using Market.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Market.Infrastructure.Repositories
{
    public class ProduceCategoryRepository : IProduceCategoryRepository
    {
        private readonly AppDbContext _dbContext;

        public ProduceCategoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProduceCategory?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.ProduceCategories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }

        public async Task<IReadOnlyList<ProduceCategory>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.ProduceCategories
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<ProduceCategory>> GetByIdsAsync(IEnumerable<Guid> ids,
            CancellationToken cancellationToken = default)
        {
            return await _dbContext.ProduceCategories
                .AsNoTracking()
                .Where(c => ids.Contains(c.Id))
                .ToListAsync(cancellationToken);
        }

        public async Task<ProduceCategory> AddAsync(ProduceCategory category,
            CancellationToken cancellationToken = default)
        {
            _dbContext.ProduceCategories.Add(category);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return category;
        }

        public async Task<ProduceCategory> UpdateAsync(ProduceCategory category,
            CancellationToken cancellationToken = default)
        {
            _dbContext.ProduceCategories.Update(category);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return category;
        }

        public async Task<ProduceCategory> DeleteAsync(ProduceCategory category,
            CancellationToken cancellationToken = default)
        {
            _dbContext.ProduceCategories.Remove(category);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return category;
        }

        public Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return _dbContext.ProduceCategories
                .AsNoTracking()
                .AnyAsync(c => c.Id == id, cancellationToken);
        }

        public Task<bool> NameExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            return _dbContext.ProduceCategories
                .AsNoTracking()
                .AnyAsync(c => c.Name == name, cancellationToken);
        }
    }
}