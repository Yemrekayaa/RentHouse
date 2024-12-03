namespace RentHouse.Dto.HouseDtos
{
    public class CreateHouseWithFeatureDto
    {
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

        public List<CreateHouseWithFeatureListDto> HouseFeatures { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }

    public class CreateHouseWithFeatureListDto
    {
        public int FeatureId { get; set; }
        public bool Available { get; set; }

    }
}
