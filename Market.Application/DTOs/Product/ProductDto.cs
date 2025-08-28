using Market.Application.DTOs.ProductCategory;
using Market.Application.DTOs.ProductVariant;

namespace Market.Application.DTOs.Product;

public class ProductBaseDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; } = string.Empty;
    public string? PhotoUrl { get; set; } = string.Empty;
}

public class ProductDto : ProductBaseDto
{
    public IEnumerable<ProductVariantDto> Variants { get; set; } =
        new List<ProductVariantDto>();

    public IEnumerable<ProductCategoryDto> Categories { get; set; } =
        new List<ProductCategoryDto>();
}

public class ProductListItemDto : ProductBaseDto
{
    public decimal[] PriceRange { get; set; } = [0, 0];
}