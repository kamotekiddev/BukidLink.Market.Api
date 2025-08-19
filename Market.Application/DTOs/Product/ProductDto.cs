using Market.Application.DTOs.ProductCategory;

namespace Market.Application.DTOs.Product;

public class ProductDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; } = string.Empty;
    public string? PhotoUrl { get; set; } = string.Empty;

    public IEnumerable<ProductCategoryDto> Categories { get; set; } =
        new List<ProductCategoryDto>();
}