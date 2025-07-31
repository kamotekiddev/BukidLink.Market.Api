using Market.Application.Interfaces;
using Market.Domain.Entities;
using Market.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Market.Infrastructure.Repositories;

public class StoreRepository : IStoreRepository
{
    private readonly AppDbContext _dbContext;

    public StoreRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Store?> CreateStoreAsync(Store? store)
    {
        _dbContext.Stores.Add(store);
        await _dbContext.SaveChangesAsync();
        return store;
    }

    public async Task<Store?> UpdateStoreAsync(Store? store)
    {
        _dbContext.Stores.Update(store);
        await _dbContext.SaveChangesAsync();
        return store;
    }

    public async Task<Store?> FindStoreByIdAsync(Guid storeId)
    {
        return await _dbContext.Stores.FindAsync(storeId);
    }

    public async Task<Store?> DeleteStoreAsync(Guid storeId)
    {
        var store = await FindStoreByIdAsync(storeId);
        _dbContext.Stores.Remove(store);

        await _dbContext.SaveChangesAsync();
        return store;
    }

    public async Task<Store?> FindStoreByNameAsync(string name)
    {
        return await _dbContext.Stores.FirstOrDefaultAsync(s => string.Equals(s.Name, name));
    }
}