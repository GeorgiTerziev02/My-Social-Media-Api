namespace MySocialMedia.Server.Features.Posts
{
    using MySocialMedia.Server.Features.Posts.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPostsService
    {
        Task<int> Create(string description, string imageUrl, string userId);

        Task<IEnumerable<PostListingServiceModel>> PostsByUser(string userId);

        Task<PostDetailsServiceModel> Details(int id);
    }
}
