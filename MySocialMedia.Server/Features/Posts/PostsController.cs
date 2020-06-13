namespace MySocialMedia.Server.Features.Posts
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MySocialMedia.Server.Features.Posts.Models;
    using MySocialMedia.Server.Infrastructure;

    public class PostsController : ApiController
    {
        private readonly IPostsService postsService;

        public PostsController(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(CreatePostRequestModel model)
        {
            var userId = this.User.GetId();

            var postId = await this.postsService.Create(model.Description, model.ImageUrl, userId);

            return Created(nameof(this.Create), postId);
        }
    }
}
