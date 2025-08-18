using Market.Application.Interfaces;
using Market.Domain.Entities;
using Market.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Market.Infrastructure.Repositories;

public class ProductVariantRepository : IProductVariantRepository
{
    private readonly AppDbContext _dbContext;

    public ProductVariantRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ProductVariant> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var variant = await _dbContext.ProductVariants
            .Include(pv => pv.Product)
            .FirstOrDefaultAsync(pv => pv.Id == id, cancellationToken);

        if (variant is null) throw new KeyNotFoundException("Produce variant not found");

        return variant;
    }

    public async Task<IEnumerable<ProductVariant>> GetByProduceIdAsync(Guid produceId,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.ProductVariants
            .Where(pv => pv.ProductId == produceId)
            .ToListAsync(cancellationToken);
    }

    public async Task<ProductVariant> AddAsync(ProductVariant variant, CancellationToken cancellationToken = default)
    {
        await _dbContext.ProductVariants.AddAsync(variant, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return variant;
    }

    public async Task<ProductVariant> UpdateAsync(ProductVariant variant, CancellationToken cancellationToken = default)
    {
        _dbContext.ProductVariants.Update(variant);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return variant;
    }

    public async Task<ProductVariant> DeleteAsync(ProductVariant variant, CancellationToken cancellationToken = default)
    {
        _dbContext.ProductVariants.Remove(variant);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return variant;
    }
}