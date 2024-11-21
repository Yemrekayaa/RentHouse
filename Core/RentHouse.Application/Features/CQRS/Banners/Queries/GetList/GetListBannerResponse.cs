namespace RentHouse.Application.Features.CQRS.Banners.Queries.GetList
{
    public class GetListBannerResponse
    {
        public int BannerID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoDescription { get; set; }
        public string VideoUrl { get; set; }
    }
}
