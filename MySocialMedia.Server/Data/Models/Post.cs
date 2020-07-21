namespace MySocialMedia.Server.Data.Models
{
    using MySocialMedia.Server.Data.Models.Base;
    using System.ComponentModel.DataAnnotations;

    using static Validation.Post;

    public class Post : DeletetableEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
