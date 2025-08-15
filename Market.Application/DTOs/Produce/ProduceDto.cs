namespace Market.Application.DTOs.Produce;

public class ProduceDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; } = string.Empty;
    public string? PhotoUrl { get; set; } = string.Empty;
}