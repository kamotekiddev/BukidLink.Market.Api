using Market.Application.Interfaces;
using Market.Domain.Entities;
using Market.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Market.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _dbContext;

    public ProductRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Product> AddProductAsync(Product product)
    {
        _dbContext.AttachRange(product.Categories);
        _dbContext.Products.Add(product);
        await _dbContext.SaveChangesAsync();
        return product;
    }

    public async Task<Product> UpdateProductAsync(Product product)
    {
        _dbContext.Products.Update(product);
        await _dbContext.SaveChangesAsync();
        return product;
    }

    public async ValueTask<Product?> GetProductByIdAsync(Guid produceId)
    {
        return await _dbContext.Products
            .Include(p => p.Categories)
            .Include(p => p.Variants)
            .FirstOrDefaultAsync(p => p.Id == produceId);
    }

    public async Task<Product> DeleteProductByIdAsync(Product product)
    {
        _dbContext.Products.Remove(product);
        await _dbContext.SaveChangesAsync();

        return product;
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await _dbContext.Products.ToListAsync();
    }

    public async Task<List<Product>> GetAllWithVariantsAsync()
    {
        return await _dbContext.Products.Include(p => p.Variants).ToListAsync();
    }

    public async Task<List<Product>> GetByCategoryIdAsync(Guid categoryId)
    {
        return await _dbContext.Products
            .Include(p => p.Variants)
            .Where(p => p.Categories.Any(c => c.Id == categoryId))
            .ToListAsync();
    }
}