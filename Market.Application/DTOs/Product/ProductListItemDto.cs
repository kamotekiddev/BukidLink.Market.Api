namespace Market.Application.DTOs.Product;

public class ProductListItemDto : ProductBaseDto
{
    public decimal[] PriceRange { get; set; } = [0, 0];
}