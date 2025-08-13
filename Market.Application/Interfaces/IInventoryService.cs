using Market.Application.DTOs.Inventory;
using Market.Domain.Entities;

namespace Market.Application.Interfaces;

public interface IInventoryService
{
    Task<InventoryDto> CreateAsync(AddInventoryDto dto);
    Task<InventoryDto> UpdateAsync(Guid id, UpdateInventoryDto dto);

    Task<InventoryDto?> GetByIdAsync(Guid id);
    Task<IReadOnlyList<InventoryDto>> GetAllAsync();
    Task<IReadOnlyList<InventoryDto>> GetByProduceIdAsync(Guid produceId);

    Task<bool> DeleteAsync(Guid id);

    Task<Inventory?> AdjustQuantityAsync(Guid id, int delta);
}