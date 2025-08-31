using Market.Application.DTOs.ProductCategory;
using Market.Application.DTOs.ProductVariant;

namespace Market.Application.DTOs.Product;

public class ProductDto : ProductBaseDto
{
    public decimal[] PriceRange { get; set; } = [0, 0];

    public IEnumerable<ProductVariantBaseDto> Variants { get; set; } =
        new List<ProductVariantDto>();

    public IEnumerable<ProductCategoryDto> Categories { get; set; } =
        new List<ProductCategoryDto>();
}