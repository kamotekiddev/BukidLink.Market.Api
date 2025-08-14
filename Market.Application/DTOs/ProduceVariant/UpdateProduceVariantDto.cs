using Market.Domain.Enums;

namespace Market.Application.DTOs.ProduceVariant;

public class UpdateProduceVariantDto
{
    public double Price { get; set; }
    public UnitOfMeasure UnitOfMeasure { get; set; }
    public int UniSize { get; set; }
}