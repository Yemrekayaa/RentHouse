namespace RentHouse.Application.Features.CQRS.Testimonials.Queries.GetById
{
    public class GetByIdTestimonialResponse
    {
        public int TestimonialID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }
    }
}
