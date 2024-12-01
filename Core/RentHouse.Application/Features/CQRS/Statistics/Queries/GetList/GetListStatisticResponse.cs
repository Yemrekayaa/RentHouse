namespace RentHouse.Application.Features.CQRS.Statistics.Queries.GetList
{
	public class GetListStatisticResponse
	{
		public int TotalHouse { get; set; }
		public int TotalCustomer { get; set; }
		public int TotalRentedDays { get; set; }
	}
}
