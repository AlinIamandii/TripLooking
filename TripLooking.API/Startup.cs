using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Newtonsoft.Json;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using TripLooking.API.Extensions;
using TripLooking.Business.Identity;
using TripLooking.Business.Identity.Models;
using TripLooking.Business.Identity.Services.Implementations;
using TripLooking.Business.Identity.Services.Interfaces;
using TripLooking.Business.Identity.Validators;
using TripLooking.Business.Trips;
using TripLooking.Business.Trips.Services.Implementations;
using TripLooking.Business.Trips.Services.Interfaces;
using TripLooking.Persistence;
using TripLooking.Persistence.Identity;
using TripLooking.Persistence.Trips;

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

            services
                .AddScoped<ITripsService, TripsService>()
                .AddScoped<ICommentsService, CommentsService>()
                .AddScoped<IPhotosService, PhotosService>()
                .AddScoped<IPasswordHasher, PasswordHasher>()
                .AddScoped<IAuthenticationService, AuthenticationService>();

            AddAuthentication(services);

            services
                .AddDbContext<TripsContext>(config =>
                    config.UseSqlServer(Configuration.GetConnectionString("TripsConnection")))
                .AddScoped<ITripsRepository, TripsRepository>()
                .AddScoped<IUserRepository, UserRepository>();

            services
                .AddAutoMapper(c =>
                {
                    c.AddProfile<TripsMappingProfile>();
                    c.AddProfile<IdentityMappingProfile>();
                }, typeof(TripsService))
                .AddHttpContextAccessor()
                .AddSwagger()
                .AddControllers()
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services
                .AddMvc()
                .AddFluentValidation();

            services.AddTransient<IValidator<UserRegisterModel>, UserRegisterModelValidator>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseSwagger()
                .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Trips API"));

            app
                .UseHttpsRedirection()
                .UseRouting()
                .UseCors(options => options
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader())
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints => endpoints.MapControllers());
        }

        private void AddAuthentication(IServiceCollection services)
        {
            var jwtOptions = Configuration.GetSection("JwtOptions").Get<JwtOptions>();
            services.Configure<JwtOptions>(Configuration.GetSection("JwtOptions"));

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = true;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOptions.Key)),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = jwtOptions.Issuer,
                        ValidAudience = jwtOptions.Audience
                    };
                });
        }
    }
}
