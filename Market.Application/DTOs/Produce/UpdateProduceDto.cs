namespace Market.Application.DTOs.Produce;

public class UpdateProduceDto
{
    public required string Name { get; set; }
    public string? Description { get; set; } = string.Empty;
    public string? PhotoUrl { get; set; } = string.Empty;
    public decimal Price { get; set; }
}