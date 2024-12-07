using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace RentHouse.WebUI.Services
{
    public class ApiSettings
    {
        public string BaseUrl { get; set; }
    }

    public class ApiService
    {
        private readonly string _apiBaseUrl;

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ApiService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor,IOptions<ApiSettings> options)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
            _apiBaseUrl = options.Value.BaseUrl;
        }

        public async Task<HttpResponseMessage> RequestAsync<T>(HttpMethod method, string entityName, T? data = null) where T : class
        {
            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage(method, _apiBaseUrl + entityName);

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
