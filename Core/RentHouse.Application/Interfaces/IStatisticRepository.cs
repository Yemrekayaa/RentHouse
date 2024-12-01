using RentHouse.Application.Common.Statistic;

namespace RentHouse.Application.Interfaces
{
	public interface IStatisticRepository
	{
		Task<StatisticModel> GetAll();
	}
}
