using System.Text.Json.Serialization;

namespace MyDeal.TechTest.Services
{
    internal class UserData
    {
        [JsonPropertyName("data")]
        public User Data { get; set; }
    }
}