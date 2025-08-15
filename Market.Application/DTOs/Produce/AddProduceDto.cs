namespace Market.Application.DTOs.Produce;

public class AddProduceDto
{
    public required string Name { get; set; }
    public string? Description { get; set; } = string.Empty;
    public string? PhotoUrl { get; set; } = string.Empty;
}