namespace MySocialMedia.Server.Data.Models
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        // private setter to prevent from the collection being reinstatied
        public IEnumerable<Post> Posts { get; } = new HashSet<Post>();
    }
}
