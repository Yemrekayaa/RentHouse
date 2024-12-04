namespace RentHouse.Application.Features.CQRS.HouseImages.Queries.GetList
{
    public class GetListHouseImageResponse
    {
        public int HouseImageID { get; set; }
        public int HouseID { get; set; }
        public string ImageUrl { get; set; }
    }
}
