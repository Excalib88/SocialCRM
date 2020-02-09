using System;

namespace SocialCRM.DAL.Entities
{
    public class BaseEntity: IEntity
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateUpdated { get; set; }
        public Guid? UserCreated { get; set; }
        public Guid? UserUpdated { get; set; }
    }
}