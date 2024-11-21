namespace RentHouse.Application.Features.CQRS.Blogs.Queries.GetList
{
    public class GetListBlogResponse
    {
        public int BlogID { get; set; }
        public string Title { get; set; }
        public int AuthorID { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreateDate { get; set; }
        public int CategoryID { get; set; }
        public string Description { get; set; }
    }
}
