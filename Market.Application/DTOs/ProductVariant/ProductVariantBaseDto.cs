using Market.Domain.Enums;

namespace Market.Application.DTOs.ProductVariant;

public class ProductVariantBaseDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public double Price { get; set; }
    public UnitOfMeasure UnitOfMeasure { get; set; }
    public int UniSize { get; set; }
}