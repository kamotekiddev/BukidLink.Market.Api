using Market.Application.Interfaces;
using Market.Domain.Entities;
using Market.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Market.Infrastructure.Repositories;

public class ProduceRepository : IProduceRepository
{
    private readonly AppDbContext _dbContext;

    public ProduceRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Produce> AddProduceAsync(Produce produce)
    {
        _dbContext.Produce.Add(produce);
        await _dbContext.SaveChangesAsync();
        return produce;
    }

    public async Task<Produce> UpdateProduceAsync(Produce produce)
    {
        _dbContext.Produce.Update(produce);
        await _dbContext.SaveChangesAsync();
        return produce;
    }

    public ValueTask<Produce?> GetProduceByIdAsync(Guid produceId)
    {
        return _dbContext.Produce.FindAsync(produceId);
    }

    public async Task<Produce> DeleteProduceByIdAsync(Produce produce)
    {
        _dbContext.Produce.Remove(produce);
        await _dbContext.SaveChangesAsync();

        return produce;
    }

    public async Task<List<Produce>> GetAllProduceAsync()
    {
        return await _dbContext.Produce.ToListAsync();
    }
}