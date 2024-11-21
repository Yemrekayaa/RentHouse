using AutoMapper;
using RentHouse.Application.Features.CQRS.Blogs.Commands.Create;
using RentHouse.Application.Features.CQRS.Blogs.Commands.Update;
using RentHouse.Application.Features.CQRS.Blogs.Queries.GetById;
using RentHouse.Application.Features.CQRS.Blogs.Queries.GetList;
using RentHouse.Application.Features.CQRS.Blogs.Queries.GetListWithAuthor;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Blogs
{
    public class BlogMappingProfile : Profile
    {
        public BlogMappingProfile()
        {
            CreateMap<Blog, GetListBlogResponse>().ReverseMap();
            CreateMap<Blog, GetByIdBlogResponse>().ReverseMap();
            CreateMap<UpdateBlogCommand, Blog>().ReverseMap();
            CreateMap<CreateBlogCommand, Blog>().ReverseMap();
            CreateMap<Blog, GetBlogListWithAuthorResponse>().ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name));

        }
    }
}
