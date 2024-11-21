using AutoMapper;
using RentHouse.Application.Features.CQRS.SocialMedias.Commands.Create;
using RentHouse.Application.Features.CQRS.SocialMedias.Commands.Update;
using RentHouse.Application.Features.CQRS.SocialMedias.Queries.GetById;
using RentHouse.Application.Features.CQRS.SocialMedias.Queries.GetList;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.SocialMedias
{
    public class SocialMediaMappingProfile : Profile
    {
        public SocialMediaMappingProfile()
        {
            CreateMap<SocialMedia, GetListSocialMediaResponse>().ReverseMap();
            CreateMap<SocialMedia, GetByIdSocialMediaResponse>().ReverseMap();
            CreateMap<UpdateSocialMediaCommand, SocialMedia>().ReverseMap();
            CreateMap<CreateSocialMediaCommand, SocialMedia>().ReverseMap();
        }
    }
}
