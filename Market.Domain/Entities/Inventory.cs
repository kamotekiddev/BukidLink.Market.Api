namespace Market.Domain.Entities;

public class Inventory : BaseEntity
{
    public Guid Id { get; set; }
    public required int Quantity { get; set; }
    public required string Name { get; set; }

    public Guid ProduceId { get; set; }

    public Produce? Produce { get; set; }
}