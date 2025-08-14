using Market.Application.DTOs.Produce;
using Market.Domain.Enums;

namespace Market.Application.DTOs.ProduceVariant;

public class ProduceVariantDto
{
    public Guid Id { get; set; }
    public Guid ProduceId { get; set; }

    public double Price { get; set; }
    public UnitOfMeasure UnitOfMeasure { get; set; }
    public int UniSize { get; set; }

    public ProduceDto? Produce { get; set; }
}