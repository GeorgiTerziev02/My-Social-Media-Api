namespace MySocialMedia.Server.Features.Posts.Models
{
    using System.ComponentModel.DataAnnotations;

    using static MySocialMedia.Server.Data.Validation.Post;

    public class UpdatePostRequestModel
    {
        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }
    }
}
