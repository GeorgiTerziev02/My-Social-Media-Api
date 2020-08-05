namespace MySocialMedia.Server.Features.Search
{
    using Microsoft.EntityFrameworkCore;
    using MySocialMedia.Server.Data;
    using MySocialMedia.Server.Features.Search.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class SearchService : ISearchService
    {
        private readonly MySocialMediaDbContext data;

        public SearchService(MySocialMediaDbContext data)
        {
            this.data = data;
        }

        public async Task<IEnumerable<ProfileSearchServiceModel>> Profiles(string query)
            => await this.data
                   .Users
                   .Where(u => u.UserName.ToLower().Contains(query.ToLower()) ||
                       u.Profile.Name.ToLower().Contains(query.ToLower()))
                   .Select(u=>new ProfileSearchServiceModel
                   {
                       UserId = u.Id,
                       UserName = u.UserName,
                       ProfilePhotoUrl = u.Profile.MainPhotoUrl
                   })
                   .ToListAsync();
    }
}
