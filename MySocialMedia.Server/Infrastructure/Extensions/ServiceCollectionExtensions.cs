namespace MySocialMedia.Server.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.OpenApi.Models;
    using MySocialMedia.Server.Data;
    using MySocialMedia.Server.Data.Models;
    using MySocialMedia.Server.Features.Follows;
    using MySocialMedia.Server.Features.Identity;
    using MySocialMedia.Server.Features.Posts;
    using MySocialMedia.Server.Features.Profiles;
    using MySocialMedia.Server.Features.Search;
    using MySocialMedia.Server.Infrastructure.Filters;
    using MySocialMedia.Server.Infrastructure.Services;
    using System.Text;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services
                .AddDbContext<MySocialMediaDbContext>(options =>
                    options.UseSqlServer(configuration.GetDefaultConnectionString()));

            return services;
        }

        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequiredLength = 6;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<MySocialMediaDbContext>();

            // chainable services
            return services;
        }

        public static IServiceCollection AddJwtAuthentication(
            this IServiceCollection services,
            ApplicationSettings appSettings)
        {
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;
        }

        public static ApplicationSettings GetApplicationSettings(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var applicationSettingsConfiguration = configuration.GetSection("ApplicationSettings");
            services.Configure<ApplicationSettings>(applicationSettingsConfiguration);
            // configure jwt authentication
            var appSettings = applicationSettingsConfiguration.Get<ApplicationSettings>();

            return appSettings;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
            => services
                .AddScoped<ICurrentUserService, CurrentUserService>()
                .AddTransient<IProfileService, ProfileService>()
                .AddTransient<IIdentityService, IdentityService>()
                .AddTransient<ISearchService, SearchService>()
                .AddTransient<IFollowsService, FollowsService>()
                .AddTransient<IPostsService, PostsService>();

        public static IServiceCollection AddSwagger(this IServiceCollection services)
            => services.AddSwaggerGen(c =>
                 {
                     c.SwaggerDoc(
                         "v1",
                         new OpenApiInfo { Title = "My Social Media API", Version = "v1" });
                 });

        public static void AddApiControllers(this IServiceCollection services)
            => services
                .AddControllers(options => options
                    .Filters
                    .Add<ModelOrNotFoundActionFilter>());
    }
}
