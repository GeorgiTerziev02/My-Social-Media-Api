namespace MySocialMedia.Server.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;
    using MySocialMedia.Server.Data.Models.Base;

    public class User : IdentityUser, IEntity
    {
        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string ModifiedBy { get; set; }

        // private setter to prevent from the collection being reinstatied
        public IEnumerable<Post> Posts { get; } = new HashSet<Post>();
    }
}
