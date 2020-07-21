namespace MySocialMedia.Server.Data.Models.Base
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class Entity : IEntity
    {
        public DateTime CreatedOn { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string ModifiedBy { get; set; }
    }
}
