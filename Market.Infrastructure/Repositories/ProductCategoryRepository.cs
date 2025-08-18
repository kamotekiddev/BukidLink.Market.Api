using Market.Application.Interfaces;
using Market.Domain.Entities;
using Market.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Market.Infrastructure.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductCategoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductCategory?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.ProductCategories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }

        public async Task<ICollection<ProductCategory>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.ProductCategories
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .ToListAsync(cancellationToken);
        }

        public async Task<ICollection<ProductCategory>> GetByIdsAsync(IEnumerable<Guid> ids,
            CancellationToken cancellationToken = default)
        {
            return await _dbContext.ProductCategories
                .AsNoTracking()
                .Where(c => ids.Contains(c.Id))
                .ToListAsync(cancellationToken);
        }

        public async Task<ProductCategory> AddAsync(ProductCategory category,
            CancellationToken cancellationToken = default)
        {
            _dbContext.ProductCategories.Add(category);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return category;
        }

        public async Task<ProductCategory> UpdateAsync(ProductCategory category,
            CancellationToken cancellationToken = default)
        {
            _dbContext.ProductCategories.Update(category);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return category;
        }

        public async Task<ProductCategory> DeleteAsync(ProductCategory category,
            CancellationToken cancellationToken = default)
        {
            _dbContext.ProductCategories.Remove(category);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return category;
        }

        public Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return _dbContext.ProductCategories
                .AsNoTracking()
                .AnyAsync(c => c.Id == id, cancellationToken);
        }

        public Task<bool> NameExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            return _dbContext.ProductCategories
                .AsNoTracking()
                .AnyAsync(c => c.Name == name, cancellationToken);
        }
    }
}