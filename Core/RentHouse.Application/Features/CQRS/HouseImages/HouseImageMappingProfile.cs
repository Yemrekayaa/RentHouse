using AutoMapper;
using RentHouse.Application.Features.CQRS.HouseImages.Commands.Create;
using RentHouse.Application.Features.CQRS.HouseImages.Commands.Update;
using RentHouse.Application.Features.CQRS.HouseImages.Queries.GetByHouse;
using RentHouse.Application.Features.CQRS.HouseImages.Queries.GetById;
using RentHouse.Application.Features.CQRS.HouseImages.Queries.GetList;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.HouseImages
{
    public class HouseImageMappingProfile : Profile
    {
        public HouseImageMappingProfile()
        {
            CreateMap<HouseImage, GetListHouseImageResponse>().ReverseMap();
            CreateMap<HouseImage, GetByIdHouseImageResponse>().ReverseMap();
            CreateMap<UpdateHouseImageCommand, HouseImage>().ReverseMap();
            CreateMap<CreateHouseImageCommand, HouseImage>().ReverseMap();
            CreateMap<HouseImage, GetHouseImagesByHouseResponse>().ReverseMap();
        }
    }
}
