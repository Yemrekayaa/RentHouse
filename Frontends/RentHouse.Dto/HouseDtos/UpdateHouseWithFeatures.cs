namespace RentHouse.Dto.HouseDtos
{
    public class UpdateHouseWithFeatureDto
    {
        public int HouseID { get; set; }
        public int LocationID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public int Area { get; set; }
        public byte NumberOfRooms { get; set; }
        public byte NumberOfBeds { get; set; }
        public string BigImageUrl { get; set; }
        public decimal WeekdayPrice { get; set; }
        public decimal WeekendPrice { get; set; }
        public List<UpdateHouseWithFeatureListDto> HouseFeatures { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }

    public class UpdateHouseWithFeatureListDto
    {
        public int HouseFeatureId { get; set; }
        public int HouseId { get; set; }
        public int FeatureId { get; set; }
        public bool Available { get; set; }

    }
}
