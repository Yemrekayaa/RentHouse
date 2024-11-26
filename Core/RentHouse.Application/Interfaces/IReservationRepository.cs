using RentHouse.Domain.Entities;

namespace RentHouse.Application.Interfaces
{
    public interface IReservationRepository
    {

        Task<List<Reservation>> GetReservationListWithHouse();
        Task<Reservation> GetReservationWithHouse(int id);

        Task<List<Reservation>> GetListWithHouseByHouse(int id);
    }

}
