using System.Text.Json.Serialization;

namespace MyDeal.TechTest.Services
{
    public class UserData
    {
        [JsonPropertyName("data")]
        public User Data { get; set; }
    }
}