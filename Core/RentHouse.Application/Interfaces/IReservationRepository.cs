using RentHouse.Application.Common.Pagination;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Interfaces
{
    public interface IReservationRepository
    {

        Task<List<Reservation>> GetReservationListWithHouse(PaginationQuery paginationQuery);
        Task<int> GetReservationListWithHouseCount();
        Task<Reservation> GetReservationWithHouse(int id);

        Task<IEnumerable<Reservation>> GetListWithHouseByHouse(int id, PaginationQuery paginationQuery);
        Task<int> GetWithHouseByHouseCount(int id);
    }

}
