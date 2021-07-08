using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace TripLooking.API.Tests
{
    public class TripsControllerTests :  IClassFixture<WebApplicationFactory<Startup>>
    {
        public TripsControllerTests(WebApplicationFactory<Startup> fixture)
        {
            Client = fixture.CreateClient();
        }

        public HttpClient Client { get; }

        [Fact]
        public async void When_GetTRips_Expect_ResponseShouldBeSuccessStatusCode()
        {
            var result = await Client.GetAsync(@"/api/trips");
            
            Assert.True(result.IsSuccessStatusCode);
        }
    }
}
