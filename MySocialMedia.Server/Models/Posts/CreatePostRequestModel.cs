using System;
using System.Collections.Generic;
namespace MySocialMedia.Server.Models.Posts
{
    using System.ComponentModel.DataAnnotations;

    using static Data.Validation.Post;

    public class CreatePostRequestModel
    {
        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
