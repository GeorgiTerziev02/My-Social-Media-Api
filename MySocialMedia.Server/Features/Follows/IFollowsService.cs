namespace MySocialMedia.Server.Features.Follows
{
    using System.Threading.Tasks;
    using MySocialMedia.Server.Infrastructure.Services;

    public interface IFollowsService
    {
        Task<Result> Follow(string userId, string followerId);
    }
}
