namespace MySocialMedia.Server.Features.Search
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MySocialMedia.Server.Features.Search.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SearchController : ApiController
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route(nameof(Profiles))]
        public async Task<IEnumerable<ProfileSearchServiceModel>> Profiles(string query) 
            => await this.searchService.Profiles(query);
    }
}
