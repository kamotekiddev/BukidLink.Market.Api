using Market.Domain.Enums;

namespace Market.Application.DTOs.ProductVariant;

public class UpdateProductVariantDto
{
    public double Price { get; set; }
    public UnitOfMeasure UnitOfMeasure { get; set; }
    public int UniSize { get; set; }
}