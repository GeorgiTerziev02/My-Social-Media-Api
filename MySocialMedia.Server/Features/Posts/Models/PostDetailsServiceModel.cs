namespace MySocialMedia.Server.Features.Posts.Models
{
    public class PostDetailsServiceModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }
    }
}
