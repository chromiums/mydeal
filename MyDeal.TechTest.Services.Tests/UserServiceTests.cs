using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MyDeal.TechTest.Services.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public async void Test1()
        {
            // Setting up the mock response for the client
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{ \"data\": { \"first_name\": \"First\" } }"),
                });

            var client = new HttpClient(mockHttpMessageHandler.Object);
            // Client BaseAddress needs to be set because it normally pulls it in from config which is not set up in tests
            client.BaseAddress = new System.Uri("http://localhost");

            var userService = new UserService(client);

            var response = await userService.GetUserDetails("2");

            Assert.Equal("First", response?.FirstName);
        }
    }
}