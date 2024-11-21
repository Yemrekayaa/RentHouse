namespace RentHouse.Application.Features.CQRS.FooterAddresses.Queries.GetList
{
    public class GetListFooterAddressResponse
    {
        public int FooterAddressID { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
