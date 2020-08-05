namespace MySocialMedia.Server.Features.Profiles
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MySocialMedia.Server.Features.Profiles.Models;
    using MySocialMedia.Server.Infrastructure.Services;
    using System.Threading.Tasks;

    public class ProfilesController : ApiController
    {
        private readonly IProfileService profileService;
        private readonly ICurrentUserService currentUser;

        public ProfilesController(
            IProfileService profileService,
            ICurrentUserService currentUser)
        {
            this.profileService = profileService;
            this.currentUser = currentUser;
        }

        [HttpGet]
        public async Task<ActionResult<ProfileServiceModel>> MyProfile()
        {
            var userId = this.currentUser.GetId();

            var result = await this.profileService.ByUser(userId);

            return result;
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateProfileRequestModel model)
        {
            var userId = this.currentUser.GetId();

            var result = await this.profileService.Update(
                userId,
                model.Email,
                model.UserName,
                model.Name,
                model.MainPhotoUrl,
                model.WebSite,
                model.Biography,
                model.Gender,
                model.IsPrivate);

            if (result.Failure)
            {
                return this.BadRequest(result.Error);
            }

            return this.Ok();
        }
    }
}
