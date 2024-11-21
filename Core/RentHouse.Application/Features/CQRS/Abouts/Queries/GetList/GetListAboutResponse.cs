namespace RentHouse.Application.Features.CQRS.Abouts.Queries.GetList
{
    public class GetListAboutResponse
    {
        public int AboutID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
