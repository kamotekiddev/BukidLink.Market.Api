using Market.Domain.Entities;

namespace Market.Application.Interfaces;

public interface IInventoryRepository
{
    Task<Inventory> SaveInventoryAsync(Inventory inventory);
    Task<Inventory> UpdateInventoryAsync(Inventory inventory);

    Task<Inventory?> FindInventoryByIdAsync(Guid inventoryId);
    Task<IReadOnlyList<Inventory>> GetAllInventoryAsync();
    Task<IReadOnlyList<Inventory>> GetInventoryByProduceIdAsync(Guid produceId);

    Task<bool> DeleteInventoryAsync(Guid inventoryId);

    Task<Inventory?> AdjustQuantityAsync(Guid inventoryId, int delta);
}