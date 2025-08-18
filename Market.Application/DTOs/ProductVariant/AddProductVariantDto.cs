using Market.Domain.Enums;

namespace Market.Application.DTOs.ProductVariant;

public class AddProductVariantDto
{
    public Guid ProduceId { get; set; }
    public double Price { get; set; }
    public UnitOfMeasure UnitOfMeasure { get; set; }
    public int UniSize { get; set; }
}