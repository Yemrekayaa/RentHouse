namespace RentHouse.Domain.Entities
{
    public class Reservation
    {
        public int ReservationID { get; set; }

        public int HouseID { get; set; }
        public House House { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Notes { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsNotified { get; set; } = false;
    }
}
