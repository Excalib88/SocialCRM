using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialCRM.Domain.Contracts.Models;

namespace SocialCRM.Domain.Contracts
{
    public interface IOrderService
    {
        Task<Guid> Create(OrderModel order);
        List<OrderModel> GetAll();
        Task<OrderModel> Get(Guid id);
    }
}