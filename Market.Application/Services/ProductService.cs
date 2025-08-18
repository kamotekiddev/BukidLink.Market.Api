using AutoMapper;
using Market.Application.DTOs.Product;
using Market.Application.Interfaces;
using Market.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Market.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IProductCategoryRepository _productCategoryRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper,
        IProductCategoryRepository productCategoryRepository)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _productCategoryRepository = productCategoryRepository;
    }

    public async Task<ProductDto> CreateProductAsync(AddProductDto dto)
    {
        var categoryIds = dto.CategoryIds.Where(id => id != Guid.Empty).Distinct().ToList();
        var categories = await _productCategoryRepository.GetByIdsAsync(categoryIds);


        if (categories.Count != categoryIds.Count)
        {
            var foundIds = new HashSet<Guid>(categories.Select(c => c.Id));
            var missing = categoryIds.Where(id => !foundIds.Contains(id)).ToList();
            throw new BadHttpRequestException($"One or more category IDs were not found: {string.Join(", ", missing)}");
        }

        var product = new Product
        {
            Name = dto.Name,
            Description = dto.Description,
            PhotoUrl = dto.PhotoUrl,
            Categories = categories,
        };

        await _productRepository.AddProductAsync(product);
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<List<ProductDto>> GetAllProductsAsync()
    {
        var products = await _productRepository.GetAllProductsAsync();
        return _mapper.Map<List<ProductDto>>(products);
    }

    public async Task<ProductDto> GetProductByIdAsync(Guid productId)
    {
        var product = await _productRepository.GetProductByIdAsync(productId) ??
                      throw new BadHttpRequestException($"produce with id:{productId} not found.");

        return _mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> UpdateProductAsync(Guid productId, UpdateProductDto dto)
    {
        var product = await _productRepository.GetProductByIdAsync(productId) ??
                      throw new BadHttpRequestException("Produce does not exist.");

        product.Name = dto.Name;
        if (dto.PhotoUrl != null) product.PhotoUrl = dto.PhotoUrl;
        if (dto.Description != null) product.Description = dto.Description;

        await _productRepository.UpdateProductAsync(product);

        return _mapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> DeleteProductByIdAsync(Guid productId)
    {
        var product = await _productRepository.GetProductByIdAsync(productId) ??
                      throw new BadHttpRequestException("Produce does not exist.");

        await _productRepository.DeleteProductByIdAsync(product);

        return _mapper.Map<ProductDto>(product);
    }

    public async Task<List<ProductDto>> GetProductsByCategoryIdAsync(Guid categoryId)
    {
        var products = await _productRepository.GetByCategoryIdAsync(categoryId);
        return _mapper.Map<List<ProductDto>>(products);
    }
}