using RentHouse.Domain.Entities;

namespace RentHouse.Application.Interfaces
{
    public interface IHouseRepository
    {
        Task<List<House>> GetHouseListWithLocationAsync(int? count = null);
        Task<List<House>> GetHouseListWithPricingAsync(int? count = null);
    }
}
