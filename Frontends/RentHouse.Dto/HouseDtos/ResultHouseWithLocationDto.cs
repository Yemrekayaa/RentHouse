namespace RentHouse.Dto.HouseDtos
{
    public class ResultHouseWithLocationDto
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
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
