using ShopBlazor.Api.Entities;
using ShopBlazor.Models.DTOs;

namespace ShopBlazor.Api.Mapping;

public class MappingDtos : AutoMapper.Profile
{
    public MappingDtos()
    {
        CreateMap<Category, CategoryDto>();

        CreateMap<Product, ProductDto>();

        CreateMap<(ItemCart itemCart, Product product), ItemCartDto>();


    }
}
