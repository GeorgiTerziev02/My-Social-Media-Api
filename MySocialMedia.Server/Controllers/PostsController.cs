namespace MySocialMedia.Server.Controllers
{
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MySocialMedia.Server.Data;
    using MySocialMedia.Server.Data.Models;
    using MySocialMedia.Server.Infrastructure;
    using MySocialMedia.Server.Models.Posts;

    public class PostsController : ApiController
    {
        private readonly MySocialMediaDbContext data;

        public PostsController(MySocialMediaDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(CreatePostRequestModel model)
        {
            var userId = this.User.GetId();

            var post = new Post
            {
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                UserId = userId,
            };

            await this.data.Posts.AddAsync(post);

            await this.data.SaveChangesAsync();

            return Created(nameof(this.Create), post.Id);
        }
    }
}
