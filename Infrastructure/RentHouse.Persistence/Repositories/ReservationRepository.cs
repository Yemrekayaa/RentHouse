using Microsoft.EntityFrameworkCore;
using RentHouse.Application.Common.Pagination;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;
using RentHouse.Persistence.Context;

namespace RentHouse.Persistence.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly RentHouseContext _context;

        public ReservationRepository(RentHouseContext context)
        {
            _context = context;
        }

        public async Task<List<Reservation>> GetReservationListWithHouse(PaginationQuery paginationQuery)
        {
            var query = _context.Reservations.AsQueryable();
            query = query.Skip((paginationQuery.PageNumber - 1) * paginationQuery.PageSize).Take(paginationQuery.PageSize);
            query = query.Include(x => x.House);
            return await query.ToListAsync();
        }

        public async Task<int> GetReservationListWithHouseCount()
        {
            return await _context.Reservations.CountAsync();
        }

        public async Task<Reservation> GetReservationWithHouse(int id)
        {
            return await _context.Reservations.Include(x => x.House).FirstOrDefaultAsync(x => x.ReservationID == id);
        }

        public async Task<IEnumerable<Reservation>> GetListWithHouseByHouse(int id, PaginationQuery paginationQuery)
        {
            var query = _context.Reservations.AsQueryable();
            query = query.OrderByDescending(x => x.StartDate);
            query = query.Skip((paginationQuery.PageNumber - 1) * paginationQuery.PageSize).Take(paginationQuery.PageSize);
            query = query.Include(x => x.House).Where(x => x.HouseID == id);
            return await query.ToListAsync();
        }

        public async Task<int> GetWithHouseByHouseCount(int id)
        {
            return await _context.Reservations.Where(x => x.HouseID == id).CountAsync();
        }
    }
}
