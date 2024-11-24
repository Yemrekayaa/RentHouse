namespace RentHouse.Dto.ReservationDto
{
	public class CreateReservationDto
	{
		public int HouseID { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string Notes { get; set; }
		public bool IsConfirmed { get; set; }
	}
}
