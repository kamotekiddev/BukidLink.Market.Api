using Market.Domain.Enums;

namespace Market.Domain.Entities;

public class ProduceVariant : BaseEntity
{
    public Guid Id { get; set; }
    public Guid ProduceId { get; set; }

    public double Price { get; set; }
    public UnitOfMeasure UnitOfMeasure { get; set; }
    public int UniSize { get; set; }

    public Produce? Produce { get; set; }
}