namespace RentHouse.Application.Features.CQRS.Authors.Queries.GetById
{
    public class GetByIdAuthorResponse
    {
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
