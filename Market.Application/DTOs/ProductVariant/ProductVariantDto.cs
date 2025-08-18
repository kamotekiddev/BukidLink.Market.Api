using Market.Application.DTOs.Product;
using Market.Domain.Enums;

namespace Market.Application.DTOs.ProductVariant;

public class ProductVariantDto
{
    public Guid Id { get; set; }
    public Guid ProduceId { get; set; }

    public double Price { get; set; }
    public UnitOfMeasure UnitOfMeasure { get; set; }
    public int UniSize { get; set; }

    public ProductDto? Produce { get; set; }
}