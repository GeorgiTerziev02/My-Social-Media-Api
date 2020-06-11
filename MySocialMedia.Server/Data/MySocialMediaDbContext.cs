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

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Post>()
                .HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
