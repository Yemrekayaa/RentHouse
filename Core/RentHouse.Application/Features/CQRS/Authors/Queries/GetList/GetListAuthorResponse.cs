namespace RentHouse.Application.Features.CQRS.Authors.Queries.GetList
{
    public class GetListAuthorResponse
    {
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
