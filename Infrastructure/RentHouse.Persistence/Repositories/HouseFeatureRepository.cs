using Microsoft.EntityFrameworkCore;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;
using RentHouse.Persistence.Context;

namespace RentHouse.Persistence.Repositories
{
    public class HouseFeatureRepository : IHouseFeatureRepository
    {
        private readonly RentHouseContext _context;

        public HouseFeatureRepository(RentHouseContext context)
        {
            _context = context;
        }

        public async Task ChangeAvailable(int id, bool available)
        {
            var value = await _context.HouseFeatures.Where(x => x.HouseFeatureId == id).FirstOrDefaultAsync();
            value.Available = available;
            await _context.SaveChangesAsync();
        }

        public async Task CreateByHouse(HouseFeature houseFeature)
        {
            _context.HouseFeatures.Add(houseFeature);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<HouseFeature>> GetByHouseId(int id)
        {
            var values = await _context.HouseFeatures.Where(x => x.HouseId == id).Include(x => x.Feature).ToListAsync();
            return values;
        }

        public async Task AddFeatureToHousesAsync(Feature feature)
        {
            var houses = await _context.Houses.ToListAsync();

            var houseFeatures = new List<HouseFeature>();

            foreach (var house in houses)
            {
                var houseFeature = new HouseFeature
                {
                    HouseId = house.HouseID,
                    FeatureId = feature.FeatureID,
                    Available = false
                };

                houseFeatures.Add(houseFeature);
            }

            _context.HouseFeatures.AddRange(houseFeatures);

            await _context.SaveChangesAsync();
        }
    }
}
