namespace MySocialMedia.Server.Features.Posts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using MySocialMedia.Server.Features.Posts.Models;
    using MySocialMedia.Server.Infrastructure.Extensions;
    using MySocialMedia.Server.Infrastructure.Services;
    using static Infrastructure.WebConstants;

    [Authorize]
    public class PostsController : ApiController
    {
        private readonly IPostsService postsService;
        private readonly ICurrentUserService currentUser;

        public PostsController(IPostsService postsService, ICurrentUserService currentUser)
        {
            this.postsService = postsService;
            this.currentUser = currentUser;
        }

        [HttpGet]
        public async Task<IEnumerable<PostListingServiceModel>> MyPosts()
        {
            var userId = this.currentUser.GetId();

            return await this.postsService.PostsByUser(userId);
        }

        [HttpGet]
        [Route(RouteId)]
        public async Task<ActionResult<PostDetailsServiceModel>> Details(int id)
           => await this.postsService.Details(id);

        [HttpPost]
        public async Task<ActionResult> Create(CreatePostRequestModel model)
        {
            var userId = this.currentUser.GetId();

            var postId = await this.postsService.Create(model.Description, model.ImageUrl, userId);

            return this.Created(nameof(this.Create), postId);
        }

        [HttpPut]
        [Route(RouteId)]
        public async Task<ActionResult> Update(int id, UpdatePostRequestModel model)
        {
            var userId = this.currentUser.GetId();

            var result = await this.postsService.Update(id, model.Description, userId);

            if (result.Failure)
            {
                return this.BadRequest(result.Error);
            }

            return this.Ok();
        }

        [HttpDelete]
        [Route(RouteId)]
        public async Task<ActionResult> Delete(int id)
        {
            var userId = this.currentUser.GetId();

            var result = await this.postsService.Delete(id, userId);

            if (result.Failure)
            {
                return this.BadRequest(result.Error);
            }

            return this.Ok();
        }
    }
}
