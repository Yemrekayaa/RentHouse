namespace RentHouse.Application.Features.CQRS.Pricings.Queries.GetById
{
    public class GetByIdPricingResponse
    {
        public int PricingID { get; set; }
        public int HouseID { get; set; }
        public decimal WeekdayPrice { get; set; }
        public decimal WeekendPrice { get; set; }
    }
}
