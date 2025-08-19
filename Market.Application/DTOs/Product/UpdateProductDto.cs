namespace Market.Application.DTOs.Product;

public class UpdateProductDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? PhotoUrl { get; set; }

    public IEnumerable<Guid> CategoryIds { get; set; } = new List<Guid>();
}