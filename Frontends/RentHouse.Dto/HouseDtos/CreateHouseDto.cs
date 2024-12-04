using RentHouse.Dto.HouseImagesDtos;

namespace RentHouse.Dto.HouseDtos
{
    public class CreateHouseDto
    {
        public int LocationID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public int Area { get; set; }
        public byte NumberOfRooms { get; set; }
        public byte NumberOfBeds { get; set; }
        public List<ResultHouseImagesDto> HouseImages { get; set; }
        public decimal WeekdayPrice { get; set; }
        public decimal WeekendPrice { get; set; }

        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
