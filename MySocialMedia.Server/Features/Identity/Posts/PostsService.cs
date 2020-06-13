namespace MySocialMedia.Server.Features.Identity.Posts
{
    using MySocialMedia.Server.Data;
    using MySocialMedia.Server.Data.Models;
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
    }
}
