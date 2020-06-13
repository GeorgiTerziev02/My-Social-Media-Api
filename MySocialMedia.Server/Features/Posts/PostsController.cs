namespace MySocialMedia.Server.Features.Posts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MySocialMedia.Server.Features.Posts.Models;
    using MySocialMedia.Server.Infrastructure.Extensions;

    [Authorize]
    public class PostsController : ApiController
    {
        private readonly IPostsService postsService;

        public PostsController(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        [HttpGet]
        public async Task<IEnumerable<PostListingServiceModel>> MyPosts()
        {
            var userId = this.User.GetId();

            return await this.postsService.PostsByUser(userId);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<PostDetailsServiceModel>> Details(int id)
           => await this.postsService.Details(id);

        [HttpPost]
        public async Task<ActionResult> Create(CreatePostRequestModel model)
        {
            var userId = this.User.GetId();

            var postId = await this.postsService.Create(model.Description, model.ImageUrl, userId);

            return Created(nameof(this.Create), postId);
        }
    }
}
