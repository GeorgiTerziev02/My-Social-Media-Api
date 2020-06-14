namespace MySocialMedia.Server.Features.Posts.Models
{
    using System.ComponentModel.DataAnnotations;

    using static MySocialMedia.Server.Data.Validation.Post;

    public class UpdatePostRequestModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }
    }
}
