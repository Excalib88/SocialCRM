using System;
using SocialCRM.DAL.Entities;

namespace SocialCRM.Domain.Models
{
    public class LeadModel
    {
        public Guid Id { get; set; }
        public PersonModel Person { get; set; }
    }
}