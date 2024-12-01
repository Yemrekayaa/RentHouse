namespace RentHouse.Application.Features.Filters.Houses
{
	public class HouseFilterDto
	{
		public decimal MinPrice { get; set; } = 0;
		public decimal MaxPrice { get; set; } = int.MaxValue;

	}
}
