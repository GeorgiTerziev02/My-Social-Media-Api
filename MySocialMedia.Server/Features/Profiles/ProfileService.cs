namespace MySocialMedia.Server.Features.Profiles
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using MySocialMedia.Server.Data;
    using MySocialMedia.Server.Features.Profiles.Models;

    public class ProfileService : IProfileService
    {
        private readonly MySocialMediaDbContext data;

        public ProfileService(MySocialMediaDbContext data)
        {
            this.data = data;
        }

        public async Task<ProfileServiceModel> ByUser(string userId)
            => await this.data
                .Users
                .Where(u => u.Id == userId)
                .Select(u => new ProfileServiceModel
                {
                    Name = u.Profile.Name,
                    Biography = u.Profile.Biography,
                    Gender = u.Profile.Gender.ToString(),
                    MainPhotoUrl = u.Profile.MainPhotoUrl,
                    WebSite = u.Profile.WebSite,
                    IsPrivate = u.Profile.IsPrivate
                })
                .FirstOrDefaultAsync();
    }
}
