using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using TripLooking.Business.Trips;
using TripLooking.Business.Trips.Models;
using TripLooking.Business.Trips.Services;
using TripLooking.Business.Trips.Services.Comments;
using TripLooking.Business.Trips.Services.Photos;
using TripLooking.Business.Trips.Validators;
using TripLooking.Persistence;

namespace TripLooking.API
{
    public sealed class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers()
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddDbContext<TripsContext>(config =>
            {
                config.UseSqlServer(Configuration.GetConnectionString("TripsConnection"));
            });

            services.AddSwaggerGen();
            services.AddAutoMapper(config => { config.AddProfile<TripsMappingProfile>(); });

            services
                .AddScoped<ITripsRepository, TripsRepository>()
                .AddScoped<ITripsService, TripsService>()
                .AddScoped<ICommentsService, CommentsService>()
                .AddScoped<IPhotosService, PhotosService>()
                .AddScoped<IValidator<UpsertTripModel>, CreateTripModelValidator>();
            
            services
                .AddMvc()
                .AddFluentValidation();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app
                .UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API");
                });

            app
                .UseHttpsRedirection()
                .UseRouting()
                .UseCors(options =>  options
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader())
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
