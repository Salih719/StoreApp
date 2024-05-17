using AutoMapper;
using Entitites.Dtos;
using Entitites.Models;
using Microsoft.AspNetCore.Identity;

namespace StoreApp.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDtoForInsertion, Product>();
            CreateMap<ProductDtoForUpdate, Product>().ReverseMap();

            CreateMap<CategoryDtoForInsertion, Category>();
            CreateMap<CategoryDtoForUpdate, Category>().ReverseMap();

            CreateMap<UserDtoForCreation, IdentityUser>();
            CreateMap<UserDtoForUpdate, IdentityUser>().ReverseMap();
        }
    }
}