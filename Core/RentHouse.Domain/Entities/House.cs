namespace RentHouse.Domain.Entities
{
    public class House
    {
        public int HouseID { get; set; }
        public int LocationID { get; set; }
        public Location Location { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public int Area { get; set; }
        public byte NumberOfRooms { get; set; }
        public byte NumberOfBeds { get; set; }
        public string BigImageUrl { get; set; }
        public List<HouseFeature> HouseFeatures { get; set; }
        public Pricing Pricing { get; set; }
    }
}