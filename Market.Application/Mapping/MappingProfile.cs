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
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Inventory, InventoryDto>().ReverseMap();
        CreateMap<ProductVariant, ProductVariantDto>().ReverseMap();
        CreateMap<ProductCategory, ProductCategoryDto>().ReverseMap();
    }
}