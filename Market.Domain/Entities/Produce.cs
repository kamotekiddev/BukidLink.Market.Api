namespace Market.Domain.Entities;

public class Produce : BaseEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? PhotoUrl { get; set; }

    public ICollection<ProduceCategory>? Categories { get; set; }
    public ICollection<ProduceVariant>? Variants { get; set; }
}