using AutoMapper;
using RentHouse.Application.Features.CQRS.Authors.Commands.Create;
using RentHouse.Application.Features.CQRS.Authors.Commands.Update;
using RentHouse.Application.Features.CQRS.Authors.Queries.GetById;
using RentHouse.Application.Features.CQRS.Authors.Queries.GetList;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Authors
{
    public class AuthorMappingProfile : Profile
    {
        public AuthorMappingProfile()
        {
            CreateMap<Author, GetListAuthorResponse>().ReverseMap();
            CreateMap<Author, GetByIdAuthorResponse>().ReverseMap();
            CreateMap<UpdateAuthorCommand, Author>().ReverseMap();
            CreateMap<CreateAuthorCommand, Author>().ReverseMap();
        }
    }
}
