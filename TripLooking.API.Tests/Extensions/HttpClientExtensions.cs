using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TripLooking.Business.Trips.Models;
using TripLooking.Business.Trips.Models.Comments;

namespace TripLooking.API.Tests.Extensions
{
    internal static class HttpClientExtensions
    {
        public static async Task<Guid> CreateTrip(this HttpClient client, UpsertTripModel model)
        {
            var response = await client.Post(@"api/trips", model);
            return Guid.Parse(response.Headers.Location.ToString());
        }

        public static async Task<HttpResponseMessage> DeleteTrip(this HttpClient client, Guid id) =>
            await client.DeleteAsync(@$"api/trips/{id}");

        public static  async Task<Guid> AddComment(this HttpClient client, Guid tripId, CreateCommentModel createCommentModel)
        {
            var response = await client.Post(@$"api/v1/trips/{tripId}/comments", createCommentModel);
            return Guid.Parse(response.Headers.Location.ToString());
        }

        public static Task<HttpResponseMessage> Post(this HttpClient client, string url, object data)
        {
            return client.PostAsync(url, data.ToStringContent());
        }

        public static Task<HttpResponseMessage> Put(this HttpClient client, string url, object data)
        {
            return client.PutAsync(url, data.ToStringContent());
        }

        public static async Task<T> Get<T>(this HttpClient client, string url)
        {
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
