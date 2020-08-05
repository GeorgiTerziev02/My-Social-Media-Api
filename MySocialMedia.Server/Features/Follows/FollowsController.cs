namespace MySocialMedia.Server.Features.Follows
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MySocialMedia.Server.Features.Follows.Models;
    using MySocialMedia.Server.Infrastructure.Services;
    using System.Threading.Tasks;


    public class FollowsController : ApiController
    {
        private readonly IFollowsService followsService;
        private readonly ICurrentUserService currentUser;

        public FollowsController(
            IFollowsService followsService,
            ICurrentUserService currentUser)
        {
            this.followsService = followsService;
            this.currentUser = currentUser;
        }

        [HttpPost]
        public async Task<ActionResult> Follow(FollowRequestModel model)
        {
            var result = await this.followsService.Follow(
                model.UserId,
                this.currentUser.GetId());

            if (result.Failure)
            {
                return this.BadRequest(result.Error);
            }

            return this.Ok();
        }
    }
}
