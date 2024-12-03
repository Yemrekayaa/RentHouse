using RentHouse.Domain.Entities;

namespace RentHouse.Application.Interfaces
{
    public interface IHouseFeatureRepository
    {
        Task<IEnumerable<HouseFeature>> GetByHouseId(int id);
        Task ChangeAvailable(int id, bool available);
        Task CreateByHouse(HouseFeature houseFeature);
        Task AddFeatureToHousesAsync(Feature feature);

    }
}
