namespace RentHouse.Application.Features.CQRS.Services.Queries.GetList
{
    public class GetListServiceResponse
    {
        public int ServiceID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
    }
}
