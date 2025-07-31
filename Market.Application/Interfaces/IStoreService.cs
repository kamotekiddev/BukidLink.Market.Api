using Market.Application.DTOs;
using Market.Application.DTOs.Store;

namespace Market.Application.Interfaces;

public interface IStoreService
{
    Task<StoreDto> AddStoreAsync(AddStoreDto dto);
    Task<StoreDto> UpdateStoreAsync(Guid storeId, UpdateStoreDto dto);
    Task<StoreDto> RemoveStoreAsync(Guid storeId);
}