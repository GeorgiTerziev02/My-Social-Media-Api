namespace MySocialMedia.Server.Features.Profiles
{
    using MySocialMedia.Server.Features.Profiles.Models;
    using System.Threading.Tasks;

    public interface IProfileService
    {
        Task<ProfileServiceModel> ByUser(string userId);
    }
}
