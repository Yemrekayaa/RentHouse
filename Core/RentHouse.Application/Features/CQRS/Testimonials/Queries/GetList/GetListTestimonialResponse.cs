namespace RentHouse.Application.Features.CQRS.Testimonials.Queries.GetList
{
    public class GetListTestimonialResponse
    {
        public int TestimonialID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }
    }
}
