namespace MySocialMedia.Server.Features.Posts.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Data.Validation.Post;

    public class CreatePostRequestModel
    {
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
