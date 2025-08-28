using Market.Application.DTOs.Product;
using Market.Domain.Enums;

namespace Market.Application.DTOs.ProductVariant;

public class BaseProductVariantDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public double Price { get; set; }
    public UnitOfMeasure UnitOfMeasure { get; set; }
    public int UniSize { get; set; }
}

public class ProductVariantDto : BaseProductVariantDto
{
    public ProductDto? Product { get; set; }
}