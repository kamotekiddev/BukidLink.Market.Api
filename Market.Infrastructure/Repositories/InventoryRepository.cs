using Market.Application.Interfaces;
using Market.Domain.Entities;
using Market.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Market.Infrastructure.Repositories;

public class InventoryRepository : IInventoryRepository
{
    private readonly AppDbContext _dbContext;

    public InventoryRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Inventory> SaveInventoryAsync(Inventory inventory)
    {
        _dbContext.Inventory.Add(inventory);
        await _dbContext.SaveChangesAsync();
        return inventory;
    }

    public async Task<Inventory> UpdateInventoryAsync(Inventory inventory)
    {
        _dbContext.Inventory.Update(inventory);
        await _dbContext.SaveChangesAsync();
        return inventory;
    }

    public async Task<Inventory?> FindInventoryByIdAsync(Guid inventoryId)
    {
        return await _dbContext.Inventory.FindAsync(inventoryId);
    }

    public async Task<IReadOnlyList<Inventory>> GetAllInventoryAsync()
    {
        return await _dbContext.Inventory
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Inventory>> GetInventoryByProduceIdAsync(Guid produceId)
    {
        return await _dbContext.Inventory
            .Where(i => i.Id == produceId)
            .ToListAsync();
    }

    public async Task<bool> DeleteInventoryAsync(Guid inventoryId)
    {
        var entity = await _dbContext.Inventory.FindAsync(inventoryId);
        if (entity is null)
        {
            return false;
        }

        _dbContext.Inventory.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<Inventory?> AdjustQuantityAsync(Guid inventoryId, int delta)
    {
        var entity = await _dbContext.Inventory.FirstOrDefaultAsync(i => i.Id == inventoryId);
        if (entity is null)
        {
            return null;
        }

        checked
        {
            entity.Quantity += delta;
        }

        _dbContext.Inventory.Update(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }
}