using Microsoft.AspNetCore.SignalR;

namespace RentHouse.WebApi.Hubs
{
    public class HouseHub : Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HouseHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task SendHouseCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7224/api/Statistics/Houses/Count");
            var value = await responseMessage.Content.ReadAsStringAsync();
            await Clients.All.SendAsync("ReceiveHouseCount", value);
        }
    }
}
