using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using TripLooking.API;
using TripLooking.Persistence;
using Xunit;

namespace TripLooking.IntegrationTestsDemo
{
    public class IntegrationTests : IAsyncLifetime
    {
        private readonly WebApplicationFactory<Startup> webApplicationFactory;

        protected HttpClient HttpClient { get; private set; }

        public IntegrationTests()
        {
            webApplicationFactory = new WebApplicationFactory<Startup>().WithWebHostBuilder(builder => { });
            HttpClient = webApplicationFactory.CreateClient();
        }

        protected async Task ExecuteDatabaseAction(Func<TripsContext, Task> databaseAction)
        {
            using (var scope = webApplicationFactory.Services.CreateScope())
            {
                var tripsContext = scope.ServiceProvider.GetRequiredService<TripsContext>();

                await databaseAction(tripsContext);
            }
        }

        private Task CleanupDatabase(TripsContext tripsContext)
        {
            return Task.CompletedTask;
        }

        public async Task InitializeAsync()
        {
            await ExecuteDatabaseAction(async(tripsContext) => await CleanupDatabase(tripsContext));
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }
    }
}
