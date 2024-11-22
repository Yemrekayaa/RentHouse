using AutoMapper;
using RentHouse.Application.Settings.CQRS.Settings.Commands.Create;
using RentHouse.Application.Settings.CQRS.Settings.Commands.Update;
using RentHouse.Application.Settings.CQRS.Settings.Queries.GetById;
using RentHouse.Application.Settings.CQRS.Settings.Queries.GetList;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Settings.CQRS.Settings
{
    public class SettingMappingProfile : Profile
    {
        public SettingMappingProfile()
        {
            CreateMap<Setting, GetListSettingResponse>().ReverseMap();
            CreateMap<Setting, GetByIdSettingResponse>().ReverseMap();
            CreateMap<UpdateSettingCommand, Setting>().ReverseMap();
            CreateMap<CreateSettingCommand, Setting>().ReverseMap();
        }
    }
}
