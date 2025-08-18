namespace Market.Application.DTOs.Product;

public class UpdateProductDto
{
    public required string Name { get; set; }
    public string? Description { get; set; } = string.Empty;
    public string? PhotoUrl { get; set; } = string.Empty;
}