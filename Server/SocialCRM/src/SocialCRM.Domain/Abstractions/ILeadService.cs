using System;
using System.Threading.Tasks;
using SocialCRM.Domain.Models;

namespace SocialCRM.Domain.Abstractions
{
    public interface ILeadService
    {
        Task<Guid> Create(LeadModel lead);
        Task<LeadModel> Get(Guid id);
        Task Update(LeadModel lead);
        Task Delete(Guid leadId);
    }
}