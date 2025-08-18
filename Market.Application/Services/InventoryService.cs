using AutoMapper;
using Market.Application.DTOs.Inventory;
using Market.Application.Interfaces;
using Market.Domain.Entities;
using Market.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Market.Application.Services;

public class InventoryService : IInventoryService
{
    private readonly IInventoryRepository _repository;
    private readonly IMapper _mapper;
    private readonly IProductService _productService;

    public InventoryService(IInventoryRepository repository, IMapper mapper, IProductService productService)
    {
        _repository = repository;
        _mapper = mapper;
        _productService = productService;
    }

    public async Task<InventoryDto> CreateAsync(AddInventoryDto dto)
    {
        var inventory = new Inventory
        {
            ProductVariantId = dto.ProduceVariantId,
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

        if (dto.Quantity != null)
            inventory.Quantity = (int)dto.Quantity;

        if (dto.Sku != null)
            inventory.Sku = dto.Sku;

        if (dto.DateExpired != null)
            inventory.DateExpired = (DateTime)dto.DateExpired;

        if (dto.DateReceived != null)
            inventory.DateReceived = (DateTime)dto.DateReceived;

        if (dto.Status != null)
            inventory.Status = (InventoryStatus)dto.Status;

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
        var produce = await _productService.GetProductByIdAsync(produceId);

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