namespace MySocialMedia.Server.Features.Follows
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using MySocialMedia.Server.Data;
    using MySocialMedia.Server.Data.Models;
    using MySocialMedia.Server.Infrastructure.Services;

    public class FollowsService : IFollowsService
    {
        private readonly MySocialMediaDbContext data;

        public FollowsService(MySocialMediaDbContext data)
        {
            this.data = data;
        }

        public async Task<Result> Follow(string userId, string followerId)
        {
            var userAlreadyFollowed = await this.data
                .Follows
                .AnyAsync(u => u.UserId == userId && u.FollowerId == followerId);

            if (userAlreadyFollowed)
            {
                return "This user is already followed.";
            }

            var publicProfile = await this.data
                .Profiles
                .Where(p => p.UserId == userId)
                .Select(p => !p.IsPrivate)
                .FirstOrDefaultAsync();

            this.data
                .Follows
                .Add(new Follow
                {
                    UserId = userId,
                    FollowerId = followerId,
                    IsApproved = publicProfile
                });

            await this.data.SaveChangesAsync();

            return true;
        }
    }
}
