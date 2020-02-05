using System;

namespace SocialCRM.DAL.Entities
{
    public class BaseEntity: IEntity
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}