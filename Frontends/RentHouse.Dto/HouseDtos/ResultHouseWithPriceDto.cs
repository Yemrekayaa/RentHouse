namespace RentHouse.Dto.HouseDtos
{
    public class ResultHouseWithPriceDto
    {
        public int houseID { get; set; }
        public int locationID { get; set; }
        public string locationName { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string coverImageUrl { get; set; }
        public int area { get; set; }
        public int numberOfRooms { get; set; }
        public int numberOfBeds { get; set; }
        public string bigImageUrl { get; set; }
        public decimal WeekdayPrice { get; set; }
        public decimal WeekendPrice { get; set; }
    }
}
