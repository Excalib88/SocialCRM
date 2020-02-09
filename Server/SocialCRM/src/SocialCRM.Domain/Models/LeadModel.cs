using System;
using SocialCRM.DAL.Entities;

namespace SocialCRM.Domain.Models
{
    public class LeadModel
    {
        public Guid Id { get; set; }
        public PersonEntity Person { get; set; }
    }
}