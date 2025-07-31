using Market.Domain.Entities;

namespace Market.Application.Interfaces;

public interface IStoreRepository
{
    Task<Store?> CreateStoreAsync(Store? store);
    Task<Store?> UpdateStoreAsync(Store? store);
    Task<Store?> FindStoreByIdAsync(Guid storeId);
    Task<Store?> DeleteStoreAsync(Guid storeId);
    Task<Store?> FindStoreByNameAsync(string name);
    Task<List<Store>> GetAllStoresAsync();
}