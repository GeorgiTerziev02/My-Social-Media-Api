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

            return Created(nameof(this.Create), postId);
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdatePostRequestModel model)
        {
            var userId = this.currentUser.GetId();

            var updated = await this.postsService.Update(model.Id, model.Description, userId);

            if (!updated)
            {
                return this.BadRequest();
            }

            return this.Ok();
        }

        [HttpDelete]
        [Route(RouteId)]
        public async Task<ActionResult> Delete(int id)
        {
            var userId = this.currentUser.GetId();

            var deleted = await this.postsService.Delete(id, userId);

            if (!deleted)
            {
                return this.BadRequest();
            }

            return this.Ok();
        }
    }
}
