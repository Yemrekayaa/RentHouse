using AutoMapper;
using RentHouse.Application.Features.CQRS.Banners.Commands.Create;
using RentHouse.Application.Features.CQRS.Banners.Commands.Update;
using RentHouse.Application.Features.CQRS.Banners.Queries.GetById;
using RentHouse.Application.Features.CQRS.Banners.Queries.GetList;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Banners
{
    public class BannerMappingProfile : Profile
    {
        public BannerMappingProfile()
        {
            CreateMap<Banner, GetListBannerResponse>().ReverseMap();
            CreateMap<Banner, GetByIdBannerResponse>().ReverseMap();
            CreateMap<UpdateBannerCommand, Banner>().ReverseMap();
            CreateMap<CreateBannerCommand, Banner>().ReverseMap();
        }
    }
}
