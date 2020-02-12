using System;
using System.Threading.Tasks;
using AutoMapper;
using SocialCRM.DAL.Entities;
using SocialCRM.DAL.Repositories;
using SocialCRM.Domain.Abstractions;
using SocialCRM.Domain.Models;

namespace SocialCRM.Domain.Services
{
    public class OrderService: IOrderService
    {
        private readonly IDbRepository _dbRepository;
        private readonly IMapper _mapper;
        
        public OrderService(IDbRepository dbRepository, IMapper mapper)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
        }
        
        public async Task<Guid> Create(OrderModel order)
        {
            var entity = _mapper.Map<OrderEntity>(order);
            var result = await _dbRepository.Add(entity);

            return result;
        }

        public Guid Get(Guid id)
        {
            return Guid.Empty;
        }
    }
}