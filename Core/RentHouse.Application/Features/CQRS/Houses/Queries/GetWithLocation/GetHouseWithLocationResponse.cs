namespace RentHouse.Application.Features.CQRS.Houses.Queries.GetWithLocation
{
    public class GetHouseWithLocationResponse
    {
        public int HouseID { get; set; }
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public int Area { get; set; }
        public byte NumberOfRooms { get; set; }
        public byte NumberOfBeds { get; set; }
        public string BigImageUrl { get; set; }
    }
}