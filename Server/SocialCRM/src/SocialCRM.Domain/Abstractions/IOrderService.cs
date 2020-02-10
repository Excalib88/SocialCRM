using System;
using System.Threading.Tasks;
using SocialCRM.Domain.Models;

namespace SocialCRM.Domain.Abstractions
{
    public interface IOrderService
    {
        Task<Guid> Create(OrderModel order);
    }
}