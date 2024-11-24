namespace RentHouse.Dto.ReservationDto
{
	public class UpdateReservationDto
	{
		public int ReservationID { get; set; }
		public int HouseID { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string Notes { get; set; }
		public bool IsConfirmed { get; set; }
	}
}
