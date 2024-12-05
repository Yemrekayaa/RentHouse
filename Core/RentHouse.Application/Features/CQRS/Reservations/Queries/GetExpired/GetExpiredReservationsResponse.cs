namespace RentHouse.Application.Features.CQRS.Reservations.Queries.GetExpired
{
    public class GetExpiredReservationsResponse
    {
        public int ReservationID { get; set; }
        public int HouseID { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsNotified { get; set; }
    }
}
