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
        var product = new Product
        {
            Name = dto.Name,
            Description = dto.Description,
            PhotoUrl = dto.PhotoUrl,
        };

        await _productRepository.AddProduceAsync(product);
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<List<ProductDto>> GetAllProductsAsync()
    {
        var products = await _productRepository.GetAllProduceAsync();
        return _mapper.Map<List<ProductDto>>(products);
    }

    public async Task<ProductDto> GetProductByIdAsync(Guid productId)
    {
        var product = await _productRepository.GetProduceByIdAsync(productId) ??
                      throw new BadHttpRequestException($"produce with id:{productId} not found.");

        return _mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> UpdateProductAsync(Guid productId, UpdateProductDto dto)
    {
        var product = await _productRepository.GetProduceByIdAsync(productId) ??
                      throw new BadHttpRequestException("Produce does not exist.");

        product.Name = dto.Name;
        if (dto.PhotoUrl != null) product.PhotoUrl = dto.PhotoUrl;
        if (dto.Description != null) product.Description = dto.Description;

        await _productRepository.UpdateProduceAsync(product);

        return _mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> DeleteProductByIdAsync(Guid productId)
    {
        var product = await _productRepository.GetProduceByIdAsync(productId) ??
                      throw new BadHttpRequestException("Produce does not exist.");

        await _productRepository.DeleteProduceByIdAsync(product);

        return _mapper.Map<ProductDto>(product);
    }

    public async Task<List<ProductDto>> GetProductsByCategoryIdAsync(Guid categoryId)
    {
        var products = await _productRepository.GetByCategoryIdAsync(categoryId);
        return _mapper.Map<List<ProductDto>>(products);
    }
}