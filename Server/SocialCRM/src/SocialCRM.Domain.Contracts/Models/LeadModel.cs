using System;

namespace SocialCRM.Domain.Contracts.Models
{
    public class LeadModel
    {
        public Guid Id { get; set; }
        public PersonModel Person { get; set; }
    }
}