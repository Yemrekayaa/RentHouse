using AutoMapper;
using RentHouse.Application.Common.Statistic;
using RentHouse.Application.Features.CQRS.Statistics.Queries.GetList;

namespace RentHouse.Application.Features.CQRS.Statistics
{
	public class StatisticMappingProfile : Profile
	{
		public StatisticMappingProfile()
		{
			CreateMap<StatisticModel, GetListStatisticResponse>().ReverseMap();
		}
	}
}
