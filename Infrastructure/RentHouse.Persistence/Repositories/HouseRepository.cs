using Microsoft.EntityFrameworkCore;
using RentHouse.Application.Common.Pagination;
using RentHouse.Application.Common.Sort;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;
using RentHouse.Persistence.Context;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
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

        public async Task<House> GetHouseWithLocationAsync(int id)
        {
            var value = await _context.Houses.Include(x => x.Location).FirstOrDefaultAsync(x => x.HouseID == id);

            return value;
        }

        public async Task<IEnumerable<House>> GetFilteredWithLocationAsync(Expression<Func<House, bool>> filter)
        {
            return await _context.Houses.Where(filter).Include(x => x.Location).ToListAsync();
        }

        public async Task<IEnumerable<House>> GetAvailableHousesAsync(DateTime startDate, DateTime endDate)
        {
            var reservedHouses = await _context.Reservations
                .Where(x => (x.StartDate < endDate && x.EndDate > startDate))
                .Select(x => x.HouseID)
                .Distinct()
                .ToListAsync();

            // Rezervasyon yapýlmamýþ evleri getir
            var availableHouses = await _context.Houses
                .Where(h => !reservedHouses.Contains(h.HouseID))
                .ToListAsync();

            return availableHouses;

        }

        public async Task<IEnumerable<House>> GetAvailableHousesWithLocationAsync(DateTime startDate, DateTime endDate, PaginationQuery paginationQuery, SortingQuery sortingQuery)
        {

            var reservedHouses = await _context.Reservations
                .Where(x => (x.StartDate <= endDate && x.EndDate >= startDate))
                .Select(x => x.HouseID)
                .Distinct()
            .ToListAsync();

            var query = _context.Houses.AsQueryable();

            query = query
            .Where(h => !reservedHouses.Contains(h.HouseID))
            .Include(x => x.Location);

            if (!string.IsNullOrEmpty(sortingQuery.OrderBy))
            {
                var sortExpression = $"{sortingQuery.OrderBy} {(sortingQuery.IsDescending ? "descending" : "ascending")}";
                query = query.OrderBy(sortExpression); // Dynamic LINQ
            }

            query = query.Skip((paginationQuery.PageNumber - 1) * paginationQuery.PageSize).Take(paginationQuery.PageSize);

            return await query.ToListAsync();

        }

        public async Task<int> GetAvailableHousesWithLocationCountAsync(DateTime startDate, DateTime endDate)
        {

            var reservedHouses = await _context.Reservations
                .Where(x => (x.StartDate <= endDate && x.EndDate >= startDate))
                .Select(x => x.HouseID)
                .Distinct()
            .ToListAsync();

            var query = _context.Houses.AsQueryable();

            query = query
            .Where(h => !reservedHouses.Contains(h.HouseID))
            .Include(x => x.Location);

            return await query.CountAsync();

        }

    }
}
