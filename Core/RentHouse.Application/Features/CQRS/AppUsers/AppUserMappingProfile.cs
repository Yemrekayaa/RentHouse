using AutoMapper;
using RentHouse.Application.Features.CQRS.AppUsers.Queries;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.AppUsers
{
    public class AppUserMappingProfile : Profile
    {
        public AppUserMappingProfile()
        {
            CreateMap<AppUser, GetCheckAppUserResponse>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AppUserId))
            .ForMember(dest => dest.Role, opt => opt.Ignore())
            .ForMember(dest => dest.IsExist, opt => opt.Ignore());
        }
    }
}
