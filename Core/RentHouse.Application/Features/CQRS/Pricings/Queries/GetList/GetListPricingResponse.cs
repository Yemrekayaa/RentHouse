namespace RentHouse.Application.Features.CQRS.Pricings.Queries.GetList
{
    public class GetListPricingResponse
    {
        public int PricingID { get; set; }
        public int HouseID { get; set; }
        public decimal WeekdayPrice { get; set; }
        public decimal WeekendPrice { get; set; }
    }
}
