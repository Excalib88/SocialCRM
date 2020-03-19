using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public List<OrderModel> GetAll()
        {
            var collection = _dbRepository.GetAll<OrderEntity>().ToList();
            var models = _mapper.Map<List<OrderModel>>(collection);

            return models;
        }

        public async Task<OrderModel> Get(Guid id)
        {
            var entity = await _dbRepository.Get<OrderEntity>().FirstOrDefaultAsync(x => x.Id == id);
            var model = _mapper.Map<OrderModel>(entity);

            return model;
        }
    }
}