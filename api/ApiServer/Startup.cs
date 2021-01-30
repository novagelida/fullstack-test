using ApiServer.Middleware;
using ApiServer.Models.Authentication;
using ApiServer.Services;
using ApiServer.Services.Interfaces;
using LiteDB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ApiServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IBoilersListService, BoilersListService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<JwtMiddleware>();
            services.Configure<AuthenticationSettings>(Configuration.GetSection("AuthenticationSettings"));

            AddControllers(services);
            AddDatabase(services);

            AddSwagger(services);

            AddApiVersioning(services);

            services.AddResponseCaching();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ConfigureWebApi(app);
        }

        private static void ConfigureWebApi(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseMiddleware<JwtMiddleware>();
            app.UseResponseCaching();
            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandler = new JsonExceptionMiddleware().Invoke
            });

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void AddApiVersioning(IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ApiVersionReader = new MediaTypeApiVersionReader();
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);
            });
        }

        private static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "1.0";
                    document.Info.Title = "Boilers API";
                    document.Info.Description = "ASP.NET Core Apis per progetto test frontend";
                };
            });
        }

        private static void AddDatabase(IServiceCollection services)
        {
            var dbLocation = Environment.GetEnvironmentVariable("DATABASE_LOCATION");
            services.AddSingleton(p => new LiteDatabase(dbLocation ?? "storage/Database.db"));
        }

        private void AddControllers(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.CacheProfiles.Add("Static", new CacheProfile() { Duration = Int32.Parse(Configuration.GetSection("StaticCacheDuration").Value) });
            });
        }
    }
}
