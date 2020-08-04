namespace MySocialMedia.Server.Features.Profiles
{
    using MySocialMedia.Server.Data.Models;
    using MySocialMedia.Server.Features.Profiles.Models;
    using MySocialMedia.Server.Infrastructure.Services;
    using System.Threading.Tasks;

    public interface IProfileService
    {
        Task<ProfileServiceModel> ByUser(string userId);

        Task<Result> Update(
            string userId,
            string email,
            string userName,
            string name,
            string mainPhotoUrl,
            string webSite,
            string biography,
            Gender gender,
            bool isPrivate);
    }
}
