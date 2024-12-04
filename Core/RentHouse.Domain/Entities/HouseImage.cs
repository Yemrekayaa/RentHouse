namespace RentHouse.Domain.Entities
{
    public class HouseImage
    {
        public int HouseImageID { get; set; }
        public int HouseID { get; set; }
        public House House { get; set; }
        public string ImageUrl { get; set; }
    }
}
