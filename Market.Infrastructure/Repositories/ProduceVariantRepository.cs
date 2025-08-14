using Market.Application.Interfaces;
using Market.Domain.Entities;
using Market.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Market.Infrastructure.Repositories;

public class ProduceVariantRepository : IProduceVariantRepository
{
    private readonly AppDbContext _dbContext;

    public ProduceVariantRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ProduceVariant> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var variant = await _dbContext.ProduceVariants
            .Include(pv => pv.Produce)
            .FirstOrDefaultAsync(pv => pv.Id == id, cancellationToken);

        if (variant is null) throw new KeyNotFoundException("Produce variant not found");

        return variant;
    }

    public async Task<IEnumerable<ProduceVariant>> GetByProduceIdAsync(Guid produceId,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.ProduceVariants
            .Where(pv => pv.ProduceId == produceId)
            .ToListAsync(cancellationToken);
    }

    public async Task<ProduceVariant> AddAsync(ProduceVariant variant, CancellationToken cancellationToken = default)
    {
        await _dbContext.ProduceVariants.AddAsync(variant, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return variant;
    }

    public async Task<ProduceVariant> UpdateAsync(ProduceVariant variant, CancellationToken cancellationToken = default)
    {
        _dbContext.ProduceVariants.Update(variant);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return variant;
    }

    public async Task<ProduceVariant> DeleteAsync(ProduceVariant variant, CancellationToken cancellationToken = default)
    {
        _dbContext.ProduceVariants.Remove(variant);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return variant;
    }
}