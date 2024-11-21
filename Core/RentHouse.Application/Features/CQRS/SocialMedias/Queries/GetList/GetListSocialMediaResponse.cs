namespace RentHouse.Application.Features.CQRS.SocialMedias.Queries.GetList
{
    public class GetListSocialMediaResponse
    {
        public int SocialMediaID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}
