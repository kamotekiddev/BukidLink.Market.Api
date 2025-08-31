using AutoMapper;
using Market.Application.DTOs.Inventory;
using Market.Application.DTOs.Product;
using Market.Application.DTOs.ProductCategory;
using Market.Application.DTOs.ProductVariant;
using Market.Application.DTOs.User;
using Market.Domain.Entities;

namespace Market.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<Product, ProductDto>()
            .ForMember(d => d.PriceRange, opt => opt.MapFrom(src =>
                (src.Variants != null && src.Variants.Any())
                    ? new[]
                    {
                        (decimal)src.Variants.Min(v => v.Price),
                        (decimal)src.Variants.Max(v => v.Price)
                    }
                    : Array.Empty<decimal>()))
            .ReverseMap();

        CreateMap<Product, ProductListItemDto>()
            .ForMember(d => d.PriceRange, opt => opt.MapFrom(src =>
                (src.Variants != null && src.Variants.Any())
                    ? new[]
                    {
                        (decimal)src.Variants.Min(v => v.Price),
                        (decimal)src.Variants.Max(v => v.Price)
                    }
                    : Array.Empty<decimal>()));

        CreateMap<Inventory, InventoryDto>().ReverseMap();
        CreateMap<ProductVariant, ProductVariantBaseDto>().ReverseMap();
        CreateMap<ProductVariant, ProductVariantDto>().ReverseMap();
        CreateMap<ProductCategory, ProductCategoryDto>().ReverseMap();
    }
}