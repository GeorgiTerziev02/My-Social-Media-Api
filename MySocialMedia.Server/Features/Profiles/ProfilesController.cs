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
        [Authorize]
        public async Task<ActionResult<ProfileServiceModel>> MyProfile()
        {
            var userId = this.currentUser.GetId();

            return await this.profileService.ByUser(userId);
        }
    }
}
