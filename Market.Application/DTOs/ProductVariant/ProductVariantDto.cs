using Market.Application.DTOs.Product;

namespace Market.Application.DTOs.ProductVariant;

public class ProductVariantDto : ProductVariantBaseDto
{
    public ProductDto? Product { get; set; }
}