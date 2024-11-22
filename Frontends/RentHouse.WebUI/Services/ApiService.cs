using Newtonsoft.Json;
using System.Text;

namespace RentHouse.WebUI.Services
{
    public class ApiService
    {
        private readonly string apiUrl = "https://localhost:7224/api/";

        private readonly IHttpClientFactory _httpClientFactory;

        public ApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<HttpResponseMessage> RequestAsync<T>(HttpMethod method, string entityName, T? data = null) where T : class
        {
            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage(method, apiUrl + entityName);

            if (data != null)
            {
                var jsonData = JsonConvert.SerializeObject(data);
                request.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            }

            return await client.SendAsync(request);
        }

        public async Task<TResult> GetAsync<TResult>(string entityName)
        {
            var response = await RequestAsync<object>(HttpMethod.Get, entityName);

            if (!response.IsSuccessStatusCode)
            {
                return default; // Hata durumunda default değer dönüyoruz
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResult>(jsonData);
        }

    }
}
