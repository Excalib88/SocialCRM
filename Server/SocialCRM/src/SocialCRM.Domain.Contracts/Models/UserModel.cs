using System;

namespace SocialCRM.Domain.Contracts.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string HashedPassword { get; set; }
    }
}