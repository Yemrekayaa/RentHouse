namespace RentHouse.Application.Features.CQRS.Reservations.Queries.GetById
{
	public class GetByIdReservationResponse
	{
		public int ReservationID { get; set; }
		public int HouseID { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string Notes { get; set; }
		public bool IsConfirmed { get; set; }
	}
}
