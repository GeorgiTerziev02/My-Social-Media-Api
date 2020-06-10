namespace MySocialMedia.Server.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using MySocialMedia.Server.Data.Models;

    public class MySocialMediaDbContext : IdentityDbContext<User>
    {
        public MySocialMediaDbContext(DbContextOptions<MySocialMediaDbContext> options)
            : base(options)
        {
        }
    }
}
