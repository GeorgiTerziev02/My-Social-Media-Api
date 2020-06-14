namespace MySocialMedia.Server.Features.Posts
{
    using MySocialMedia.Server.Features.Posts.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPostsService
    {
        // TODO: Soft delete
        Task<int> Create(string description, string imageUrl, string userId);

        Task<IEnumerable<PostListingServiceModel>> PostsByUser(string userId);

        Task<bool> Delete(int id, string userId);

        Task<PostDetailsServiceModel> Details(int id);

        Task<bool> Update(int id, string description, string userId);
    }
}
