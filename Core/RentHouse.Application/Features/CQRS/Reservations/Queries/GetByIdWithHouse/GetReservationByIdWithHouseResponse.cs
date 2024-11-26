namespace RentHouse.Application.Features.CQRS.Reservations.Queries.GetByIdWithHouse
{
    public class GetReservationByIdWithHouseResponse
    {
        public int ReservationID { get; set; }
        public int HouseID { get; set; }
        public string HouseName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Notes { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
