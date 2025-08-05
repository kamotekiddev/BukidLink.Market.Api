namespace Market.Application.DTOs.Produce;

public class ProduceDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? PhotoUrl { get; set; }
    public decimal Price { get; set; }
    public Guid StoreId { get; set; }
}