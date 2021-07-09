using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace TripLooking.API.Tests
{
    public class PhotosControllerTests :  IClassFixture<WebApplicationFactory<Startup>>
    {
        public PhotosControllerTests(WebApplicationFactory<Startup> fixture)
        {
            Client = fixture.CreateClient();
        }

        public HttpClient Client { get; }

        [Fact]
        public async void When_GetPhotos_Expect_ResponseShouldBeNotSuccessStatusCode()
        {
            var result = await Client.GetAsync(@$"api/v1/trips/{Guid.NewGuid()}/photos");
            
            Assert.False(result.IsSuccessStatusCode);
        }
    }
}
