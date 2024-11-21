namespace RentHouse.Domain.Entities
{
    public class Pricing
    {
        public int PricingID { get; set; }
        public int HouseID { get; set; }
        public House House { get; set; }

        public decimal WeekdayPrice { get; set; }
        public decimal WeekendPrice { get; set; }
    }
}
