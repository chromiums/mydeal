using System.Text.Json;

namespace MyDeal.TechTest.Services
{
    public class UserService : IUserService
    {
        private HttpClient _httpClient;
        private readonly string BaseUrl = "https://reqres.in";

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserData?> GetUserDetails(string userId)
        {
            var response = await _httpClient.GetAsync("/api/users/" + userId);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<UserData>(responseBody);
        }
    }
}
