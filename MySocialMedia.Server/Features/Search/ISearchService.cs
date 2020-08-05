namespace MySocialMedia.Server.Features.Search
{
    using MySocialMedia.Server.Features.Search.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;


    public interface ISearchService
    {
        Task<IEnumerable<ProfileSearchServiceModel>> Profiles(string query);
    }
}
