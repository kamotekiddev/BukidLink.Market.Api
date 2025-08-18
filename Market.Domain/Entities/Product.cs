namespace Market.Domain.Entities;

public class Product : BaseEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? PhotoUrl { get; set; }

    public ICollection<ProductCategory>? Categories { get; set; }
    public ICollection<ProductVariant>? Variants { get; set; }
}