namespace MySocialMedia.Server.Infrastructure.Services
{
    using Microsoft.AspNetCore.Http;
    using MySocialMedia.Server.Infrastructure.Extensions;
    using System.Security.Claims;

    public class CurrentUserService : ICurrentUserService
    {
        private readonly ClaimsPrincipal user;

        // easier for testing purposes it can be easily replaced
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            this.user = httpContextAccessor.HttpContext?.User;
        }

        public string GetId()
            => this.user
                ?.GetId();

        public string GetUserName()
            => this.user
                ?.Identity
                ?.Name;
    }
}
