using Microsoft.EntityFrameworkCore;
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

		public async Task<List<Reservation>> GetReservationListWithHouse()
		{
			return await _context.Reservations.Include(x => x.House).ToListAsync();

		}

		public async Task<Reservation> GetReservationWithHouse(int id)
		{
			return await _context.Reservations.Include(x => x.House).FirstOrDefaultAsync(x => x.ReservationID == id);
		}

		public async Task<List<Reservation>> GetListWithHouseByHouse(int id)
		{
			return await _context.Reservations.Include(x => x.House).Where(x => x.HouseID == id).ToListAsync();
		}

	}
}
