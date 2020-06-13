namespace MySocialMedia.Server.Features.Posts
{
    using Microsoft.EntityFrameworkCore;
    using MySocialMedia.Server.Data;
    using MySocialMedia.Server.Data.Models;
    using MySocialMedia.Server.Features.Posts.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PostsService : IPostsService
    {
        private readonly MySocialMediaDbContext data;

        public PostsService(MySocialMediaDbContext data)
        {
            this.data = data;
        }

        public async Task<int> Create(string description, string imageUrl, string userId)
        {
            var post = new Post
            {
                Description = description,
                ImageUrl = imageUrl,
                UserId = userId,
            };

            await this.data.Posts.AddAsync(post);

            await this.data.SaveChangesAsync();

            return post.Id;
        }

        public async Task<PostDetailsServiceModel> Details(int id)
            => await this.data
                .Posts
                .Where(p => p.Id == id)
                .Select(p => new PostDetailsServiceModel
                {
                    Id = p.Id,
                    UserId = p.UserId,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    UserName = p.User.UserName
                })
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<PostListingServiceModel>> PostsByUser(string userId)
            => await this.data.Posts
                 .Where(p => p.UserId == userId)
                 .Select(p => new PostListingServiceModel
                 {
                     Id = p.Id,
                     ImageUrl = p.ImageUrl
                 })
                 .ToListAsync();
    }
}
