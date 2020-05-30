using System;

namespace SocialCRM.Domain.Contracts.Models
{
    public class CompanyModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Inn { get; set; }
    }
}