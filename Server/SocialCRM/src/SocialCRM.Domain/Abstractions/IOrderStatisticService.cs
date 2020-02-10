using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialCRM.Domain.Models;

namespace SocialCRM.Domain.Abstractions
{
    public interface IOrderStatisticService
    {
        Task<int> GetAmountByCompany(Guid companyId);
        Task<int> GetQuantityByCompany(Guid companyId);
        Task<Dictionary<Guid, LeadModel>> SortOrderLeadsByCompany(Guid companyId);
    }
}