using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using TripLooking.API.Tests.Extensions;
using TripLooking.Business.Trips.Models;
using TripLooking.Business.Trips.Models.Photos;
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

        [Fact]
        public async void When_Photo_Is_Added_ExpectWorkflowToWork()
        {
            var tripId = await Client.CreateTrip(new UpsertTripModel
            {
                Title = "title",
                Description = "dummy",
                Private = false
            });

            var createPhotoModel = new CreatePhotoModel
            {
                Content = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("This is a dummy file")), 0, 0, "Data", "dummy.txt")
            };

            //Add
            //var response = await Client.Post(@$"api/v1/trips/{tripId}/photos", createPhotoModel);
            //var photoId = Guid.Parse(response.Headers.Location.ToString());
            //photoId.Should().NotBeEmpty();

            //Get
            var response = await Client.GetAsync($@"api/v1/trips/{tripId}/photos");
            var content = await response.Content.ReadAsStringAsync();
            var photos = JsonConvert.DeserializeObject<IEnumerable<PhotoModel>>(content);
            photos.Should().NotBeNull();

            var photoId = Guid.NewGuid();

            //GetById
            response = await Client.GetAsync($@"api/v1/trips/{tripId}/photos/{photoId}");
            content = await response.Content.ReadAsStringAsync();
            var photo = JsonConvert.DeserializeObject<PhotoModel>(content);
            photo.Should().NotBeNull();

            //Delete
            response = await Client.DeleteTrip(tripId);
        }
    }
}
