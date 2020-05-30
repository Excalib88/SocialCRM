using SocialCRM.Domain.Contracts.Models;
using System;
using System.Threading.Tasks;

namespace SocialCRM.Domain.Contracts
{
    public interface ILeadService
    {
        Task<Guid> Create(LeadModel lead);
        Task<LeadModel> Get(Guid id);
        Task Update(LeadModel lead);
        Task Delete(Guid leadId);
    }
}