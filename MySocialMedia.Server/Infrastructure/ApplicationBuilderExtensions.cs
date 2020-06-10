namespace MySocialMedia.Server.Infrastructure
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using MySocialMedia.Server.Data;

    public static class ApplicationBuilderExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

            var dbcontext = services.ServiceProvider.GetService<MySocialMediaDbContext>();

            dbcontext.Database.Migrate();
        }
    }
}
