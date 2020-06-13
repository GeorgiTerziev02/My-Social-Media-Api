namespace MySocialMedia.Server
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using MySocialMedia.Server.Infrastructure.Extensions;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var appSettings = services.GetApplicationSettings(this.Configuration);

            services
                .AddDatabase(this.Configuration)
                .AddIdentity()
                .AddJwtAuthentication(appSettings)
                .AddApplicationServices()
                .AddSwagger()
                .AddApiControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDatabaseErrorPage();
                app.UseDeveloperExceptionPage();
            }

            app
                .UseSwaggerUI()
                .UseRouting()
                .UseCors(options => options
                     .AllowAnyOrigin()
                     .AllowAnyMethod()
                     .AllowAnyHeader())
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                })
                .ApplyMigrations();
        }
    }
}
