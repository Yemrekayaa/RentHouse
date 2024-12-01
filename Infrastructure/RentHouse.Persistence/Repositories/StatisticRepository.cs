using Microsoft.EntityFrameworkCore;
using RentHouse.Application.Common.Statistic;
using RentHouse.Application.Interfaces;
using RentHouse.Persistence.Context;
namespace RentHouse.Persistence.Repositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly RentHouseContext _context;

        public StatisticRepository(RentHouseContext context)
        {
            _context = context;
        }

        public async Task<StatisticModel> GetAll()
        {
            var totalHouse = await _context.Houses.CountAsync();
            var totalCustomer = await _context.Reservations.CountAsync();

            var rentedDays = await _context.Reservations
                .Select(r => new
                {
                    StartDate = r.StartDate,
                    EndDate = r.EndDate
                })
                .ToListAsync();

            int totalRentedDays = 0;

            foreach (var reservation in rentedDays)
            {
                totalRentedDays += (reservation.EndDate - reservation.StartDate).Days;
            }

            return new StatisticModel { TotalHouse = totalHouse, TotalCustomer = totalCustomer, TotalRentedDays = totalRentedDays };
        }



    }
}
