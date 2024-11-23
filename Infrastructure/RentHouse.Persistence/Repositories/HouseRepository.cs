using Microsoft.EntityFrameworkCore;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;
using RentHouse.Persistence.Context;

namespace RentHouse.Persistence.Repositories
{
    public class HouseRepository : IHouseRepository
    {
        private readonly RentHouseContext _context;

        public HouseRepository(RentHouseContext context)
        {
            _context = context;
        }

        public async Task<List<House>> GetHouseListWithLocationAsync(int? count = null)
        {
            var values = _context.Houses.Include(x => x.Location).AsQueryable();
            if (count.HasValue)
            {
                values = values.OrderByDescending(x => x.HouseID).Take(count.Value);
            }
            return await values.ToListAsync();
        }


    }
}
