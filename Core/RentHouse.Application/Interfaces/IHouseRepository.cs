using RentHouse.Domain.Entities;

namespace RentHouse.Application.Interfaces
{
	public interface IHouseRepository
	{
		Task<List<House>> GetHouseListWithLocationAsync(int? count = null);
		Task<House> GetHouseWithLocationAsync(int id);

	}

}
