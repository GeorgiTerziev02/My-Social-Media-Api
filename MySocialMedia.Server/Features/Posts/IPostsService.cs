namespace MySocialMedia.Server.Features.Posts
{
    using System.Threading.Tasks;

    public interface IPostsService
    {
        Task<int> Create(string description, string imageUrl, string userId);
    }
}
