namespace Market.Application.DTOs.Product;

public class AddProductDto
{
    public required string Name { get; set; }
    public string? Description { get; set; } = string.Empty;
    public string? PhotoUrl { get; set; } = string.Empty;
    public IEnumerable<Guid> CategoryIds { get; set; } = new List<Guid>();
}