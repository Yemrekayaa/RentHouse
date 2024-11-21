namespace RentHouse.Application.Features.CQRS.Contacts.Queries.GetList
{
    public class GetListContactResponse
    {
        public int ContactID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime SendDate { get; set; }
    }
}
