namespace RentHouse.Application.Features.CQRS.Abouts.Queries.GetById
{
    public class GetByIdAboutResponse
    {
        public int AboutID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
