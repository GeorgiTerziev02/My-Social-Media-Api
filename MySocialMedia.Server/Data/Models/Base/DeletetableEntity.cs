namespace MySocialMedia.Server.Data.Models.Base
{
    using System;

    public abstract class DeletetableEntity : Entity, IDeletableEntity
    {
        public DateTime? DeletedOn { get; set; }

        public string DeletedBy { get; set; }

        public bool IsDeleted { get; set; }
    }
}
