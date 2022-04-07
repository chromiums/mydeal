using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

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

        public async Task<UserData> GetUserDetails(string userId)
        {
            var response = await _httpClient.GetAsync("/api/users/" + userId);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<UserData>(responseBody);
            //StreamReader reader = new StreamReader(response.GetResponseStream());
            //string json = reader.ReadToEnd();
            //return JsonConvert.DeserializeObject<UserData>(json);
        }
    }
}
