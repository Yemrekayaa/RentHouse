using Newtonsoft.Json;
using System.Text;

namespace RentHouse.WebUI.Services
{
    public class ApiService
    {
        private readonly string apiUrl = "https://localhost:7224/api/";

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ApiService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<HttpResponseMessage> RequestAsync<T>(HttpMethod method, string entityName, T? data = null) where T : class
        {
            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage(method, apiUrl + entityName);

            var token = GetTokenFromClaims();
            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

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
                return default;
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResult>(jsonData);
        }
        public string GetTokenFromClaims()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            if (user == null) return null;

            return user.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;
        }
    }
}
