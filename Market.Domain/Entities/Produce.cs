namespace Market.Domain.Entities;

public class Produce : BaseEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? PhotoUrl { get; set; }
    public decimal Price { get; set; }

    public Guid StoreId { get; set; }
    public Store? Store { get; set; }
}