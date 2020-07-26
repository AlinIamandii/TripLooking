using System;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using TripLooking.API;
using TripLooking.Business.Identity.Models;
using TripLooking.Entities.Identity;
using TripLooking.Persistence;
using Xunit;

namespace TripLooking.IntegrationTests
{
    public class IntegrationTests : IAsyncLifetime
    {
        private readonly WebApplicationFactory<Startup> webApplicationFactory;

        protected HttpClient HttpClient { get; private set; }

        protected string AuthenticationToken { get; private set; }

        protected Guid AuthenticatedUserId { get; private set; }

        protected IntegrationTests()
        {
            webApplicationFactory = new WebApplicationFactory<Startup>().WithWebHostBuilder(builder => { });
            HttpClient = webApplicationFactory.CreateClient();
        }

        async Task IAsyncLifetime.InitializeAsync()
        {
            await Task.Run(async () =>
            {
                await ExecuteDatabaseAction(async(tripsContext) => await ClearDatabase(tripsContext));
                await SetAuthenticationToken();
            });
        }

        Task IAsyncLifetime.DisposeAsync()
        {
            return Task.CompletedTask;
        }

        protected async Task ExecuteDatabaseAction(Func<TripsContext, Task> databaseAction)
        {
            using (var scope = webApplicationFactory.Services.CreateScope())
            {
                var tripsContext = scope.ServiceProvider.GetRequiredService<TripsContext>();

                await databaseAction(tripsContext);
            }
        }

        private async Task ClearDatabase(TripsContext tripsContext)
        {
            tripsContext.Trips.RemoveRange(tripsContext.Trips);
            tripsContext.Users.RemoveRange(tripsContext.Users);
            await tripsContext.SaveChangesAsync();
        }

        private async Task SetAuthenticationToken()
        {
            var userRegisterModel = new UserRegisterModel
            {
                FullName = "Cristi Martin",
                Email = "cristi.martin@gmail.com",
                Password = "123456"
            };
            var userRegisterResponse = await HttpClient.PostAsJsonAsync($"api/v1/auth/register", userRegisterModel);
            userRegisterResponse.IsSuccessStatusCode.Should().BeTrue();
            AuthenticatedUserId = new Guid(userRegisterResponse.Headers.Location.OriginalString);
            var user = new User("Cristi Martin", "cristi.martin@gmail.com", "123456");
            var authenticateModel = new AuthenticationRequest
            {
                Email = user.Email,
                Password = userRegisterModel.Password
            };
            var userAuthenticateResponse = await HttpClient.PostAsJsonAsync($"api/v1/auth/login", authenticateModel);
            userAuthenticateResponse.IsSuccessStatusCode.Should().BeTrue();
            var authenticationResponseContent = await userAuthenticateResponse.Content.ReadAsAsync<AuthenticationResponse>();

            AuthenticationToken = authenticationResponseContent.Token;
        }
    }
}
