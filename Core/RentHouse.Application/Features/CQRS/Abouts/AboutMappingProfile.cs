using AutoMapper;
using RentHouse.Application.Features.CQRS.Abouts.Commands.Create;
using RentHouse.Application.Features.CQRS.Abouts.Commands.Update;
using RentHouse.Application.Features.CQRS.Abouts.Queries.GetById;
using RentHouse.Application.Features.CQRS.Abouts.Queries.GetList;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Abouts
{
    public class AboutMappingProfile : Profile
    {
        public AboutMappingProfile()
        {
            CreateMap<About, GetListAboutResponse>().ReverseMap();
            CreateMap<About, GetByIdAboutResponse>().ReverseMap();
            CreateMap<UpdateAboutCommand, About>().ReverseMap();
            CreateMap<CreateAboutCommand, About>().ReverseMap();
        }
    }
}
