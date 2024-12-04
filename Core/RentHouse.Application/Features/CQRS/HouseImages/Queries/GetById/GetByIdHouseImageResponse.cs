namespace RentHouse.Application.Features.CQRS.HouseImages.Queries.GetById
{
    public class GetByIdHouseImageResponse
    {
        public int HouseImageID { get; set; }
        public int HouseID { get; set; }
        public string ImageUrl { get; set; }
    }
}
