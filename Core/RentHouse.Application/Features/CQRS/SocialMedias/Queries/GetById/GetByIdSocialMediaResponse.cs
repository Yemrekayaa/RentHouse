namespace RentHouse.Application.Features.CQRS.SocialMedias.Queries.GetById
{
    public class GetByIdSocialMediaResponse
    {
        public int SocialMediaID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}
