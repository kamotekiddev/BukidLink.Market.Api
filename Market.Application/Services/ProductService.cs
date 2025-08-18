using AutoMapper;
using Market.Application.DTOs.Product;
using Market.Application.Interfaces;
using Market.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Market.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductDto> CreateProductAsync(AddProductDto dto)
    {
        var produce = new Product
        {
            Name = dto.Name,
            Description = dto.Description,
            PhotoUrl = dto.PhotoUrl,
        };

        await _productRepository.AddProduceAsync(produce);
        return _mapper.Map<ProductDto>(produce);
    }

    public async Task<List<ProductDto>> GetAllProductsAsync()
    {
        var produce = await _productRepository.GetAllProduceAsync();
        return _mapper.Map<List<ProductDto>>(produce);
    }

    public async Task<ProductDto> GetProductByIdAsync(Guid produceId)
    {
        var produce = await _productRepository.GetProduceByIdAsync(produceId) ??
                      throw new BadHttpRequestException($"produce with id:{produceId} not found.");

        return _mapper.Map<ProductDto>(produce);
    }

    public async Task<ProductDto> UpdateProductAsync(Guid produceId, UpdateProductDto dto)
    {
        var existingProduce = await _productRepository.GetProduceByIdAsync(produceId) ??
                              throw new BadHttpRequestException("Produce does not exist.");

        existingProduce.Name = dto.Name;
        if (dto.PhotoUrl != null) existingProduce.PhotoUrl = dto.PhotoUrl;
        if (dto.Description != null) existingProduce.Description = dto.Description;

        await _productRepository.UpdateProduceAsync(existingProduce);

        return _mapper.Map<ProductDto>(existingProduce);
    }

    public async Task<ProductDto> DeleteProductByIdAsync(Guid produceId)
    {
        var existingProduce = await _productRepository.GetProduceByIdAsync(produceId) ??
                              throw new BadHttpRequestException("Produce does not exist.");

        await _productRepository.DeleteProduceByIdAsync(existingProduce);

        return _mapper.Map<ProductDto>(existingProduce);
    }
}