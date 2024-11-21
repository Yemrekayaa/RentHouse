using AutoMapper;
using RentHouse.Application.Features.CQRS.Categories.Commands.Create;
using RentHouse.Application.Features.CQRS.Categories.Commands.Update;
using RentHouse.Application.Features.CQRS.Categories.Queries.GetById;
using RentHouse.Application.Features.CQRS.Categories.Queries.GetList;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Categorys
{
    public class CategoriesMappingProfile : Profile
    {
        public CategoriesMappingProfile()
        {
            CreateMap<Category, GetListCategoryResponse>().ReverseMap();
            CreateMap<Category, GetByIdCategoryResponse>().ReverseMap();
            CreateMap<UpdateCategoryCommand, Category>().ReverseMap();
            CreateMap<CreateCategoryCommand, Category>().ReverseMap();
        }
    }
}
