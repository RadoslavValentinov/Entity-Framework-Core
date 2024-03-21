using AutoMapper;
using ProductShop.DTOClassesMapping;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<UsersDto, User>();
            this.CreateMap<ImportProductDto, Product>();
            this.CreateMap<ImportCategoryDto, Category>();
            this.CreateMap<CategoryProductDTO,CategoryProduct>();
        }
    }
}
