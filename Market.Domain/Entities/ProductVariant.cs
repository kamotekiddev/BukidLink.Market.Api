using Market.Domain.Enums;

namespace Market.Domain.Entities;

public class ProductVariant : BaseEntity
{
    public Guid Id { get; set; }

    public double Price { get; set; }
    public UnitOfMeasure UnitOfMeasure { get; set; }
    public int UniSize { get; set; }

    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
}