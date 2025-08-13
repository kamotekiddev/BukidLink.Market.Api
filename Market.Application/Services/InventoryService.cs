using AutoMapper;
using Market.Application.DTOs.Inventory;
using Market.Application.Interfaces;
using Market.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Market.Application.Services;

public class InventoryService : IInventoryService
{
    private readonly IInventoryRepository _repository;
    private readonly IMapper _mapper;
    private readonly IProduceService _produceService;

    public InventoryService(IInventoryRepository repository, IMapper mapper, IProduceService produceService)
    {
        _repository = repository;
        _mapper = mapper;
        _produceService = produceService;
    }

    public async Task<InventoryDto> CreateAsync(AddInventoryDto dto)
    {
        var inventory = new Inventory
        {
            ProduceId = dto.ProduceId,
            Quantity = dto.Quantity,
            Sku = dto.Sku,
            DateExpired = dto.DateExpired,
            DateReceived = dto.DateReceived
        };

        await _repository.SaveInventoryAsync(inventory);
        return _mapper.Map<InventoryDto>(inventory);
    }

    public async Task<InventoryDto> UpdateAsync(Guid id, UpdateInventoryDto dto)
    {
        var inventory = await _repository.FindInventoryByIdAsync(id) ??
                        throw new BadHttpRequestException("Inventory does not exist.");

        inventory.Quantity = dto.Quantity;
        inventory.Sku = dto.Sku;
        inventory.DateExpired = dto.DateExpired;
        inventory.DateReceived = dto.DateReceived;

        await _repository.UpdateInventoryAsync(inventory);
        return _mapper.Map<InventoryDto>(inventory);
    }

    public async Task<InventoryDto?> GetByIdAsync(Guid id)
    {
        var inventory = await _repository.FindInventoryByIdAsync(id) ??
                        throw new BadHttpRequestException("Inventory does not exist.");

        return _mapper.Map<InventoryDto>(inventory);
    }

    public async Task<IReadOnlyList<InventoryDto>> GetAllAsync()
    {
        var inventories = await _repository.GetAllInventoryAsync();
        return _mapper.Map<List<InventoryDto>>(inventories);
    }

    public async Task<IReadOnlyList<InventoryDto>> GetByProduceIdAsync(Guid produceId)
    {
        var produce = await _produceService.GetProduceByIdAsync(produceId);

        var inventories = await _repository.GetInventoryByProduceIdAsync(produce.Id);
        return _mapper.Map<IReadOnlyList<InventoryDto>>(inventories);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var success = await _repository.DeleteInventoryAsync(id);
        if (!success) throw new BadHttpRequestException("Inventory does not exist");

        return success;
    }

    public Task<Inventory?> AdjustQuantityAsync(Guid id, int delta)
    {
        throw new NotImplementedException();
    }
}