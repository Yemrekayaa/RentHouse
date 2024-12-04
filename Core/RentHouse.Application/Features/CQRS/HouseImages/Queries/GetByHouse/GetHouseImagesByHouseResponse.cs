namespace RentHouse.Application.Features.CQRS.HouseImages.Queries.GetByHouse
{
    public class GetHouseImagesByHouseResponse
    {
        public int HouseImageID { get; set; }
        public int HouseID { get; set; }
        public string ImageUrl { get; set; }
    }
}
