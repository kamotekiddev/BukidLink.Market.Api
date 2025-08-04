using AutoMapper;
using Market.Application.DTOs;
using Market.Application.DTOs.Store;
using Market.Application.Interfaces;
using Market.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Market.Application.Services;

public class StoreService : IStoreService
{
    private readonly IStoreRepository _storeRepository;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public StoreService(IStoreRepository storeRepository, IUserService userService, IMapper mapper)
    {
        _storeRepository = storeRepository;
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<StoreDto> AddStoreAsync(AddStoreDto dto)
    {
        var user = await _userService.GetCurrentUser();

        var existingStore = await _storeRepository.FindStoreByNameAsync(dto.Name);
        if (existingStore is not null)
            throw new BadHttpRequestException("Store is already taken");

        var store = new Store()
        {
            Name = dto.Name,
            CoverPhotoUrl = dto.CoverPhotoUrl,
            ProfilePhotoUrl = dto.ProfilePhotoUrl,
            Description = dto.Description,
            OwnerId = user.Id,
        };

        await _storeRepository.CreateStoreAsync(store);

        return _mapper.Map<StoreDto>(store);
    }

    public async Task<StoreDto> UpdateStoreAsync(Guid storeId, UpdateStoreDto dto)
    {
        var existingStore = await _storeRepository.FindStoreByIdAsync(storeId) ??
                            throw new BadHttpRequestException("Store does not exist.");

        if (!string.IsNullOrWhiteSpace(dto.Name))
            existingStore.Name = dto.Name;

        if (!string.IsNullOrWhiteSpace(dto.CoverPhotoUrl))
            existingStore.CoverPhotoUrl = dto.CoverPhotoUrl;

        if (!string.IsNullOrWhiteSpace(dto.ProfilePhotoUrl))
            existingStore.ProfilePhotoUrl = dto.ProfilePhotoUrl;

        if (!string.IsNullOrWhiteSpace(dto.Description))
            existingStore.Description = dto.Description;

        await _storeRepository.UpdateStoreAsync(existingStore);
        return _mapper.Map<StoreDto>(existingStore);
    }

    public async Task<StoreDto> RemoveStoreAsync(Guid storeId)
    {
        var existingStore = await _storeRepository.FindStoreByIdAsync(storeId) ??
                            throw new BadHttpRequestException("Store does not exist.");

        await _storeRepository.DeleteStoreAsync(existingStore.Id);
        return _mapper.Map<StoreDto>(existingStore);
    }

    public async Task<StoreDto> GetStoreByIdAsync(Guid storeId)
    {
        var store = await _storeRepository.FindStoreByIdAsync(storeId) ??
                    throw new BadHttpRequestException("Store does not exist.");

        return _mapper.Map<StoreDto>(store);
    }

    public async Task<List<StoreDto>> GetAllStoreAsync()
    {
        var stores = await _storeRepository.GetAllStoresAsync();
        return _mapper.Map<List<StoreDto>>(stores);
    }
}