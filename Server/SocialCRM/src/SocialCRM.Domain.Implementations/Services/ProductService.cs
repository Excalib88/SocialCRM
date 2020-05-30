using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SocialCRM.DAL.Contracts.Entities;
using SocialCRM.DAL.Contracts;
using SocialCRM.Domain.Contracts;
using SocialCRM.Domain.Contracts.Models;

namespace SocialCRM.Domain.Implementations.Services
{
    public class ProductService: IProductService
    {
        private readonly IDbRepository _dbRepository;
        private readonly IMapper _mapper;
        
        public ProductService(IDbRepository dbRepository, IMapper mapper)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Create(ProductModel product)
        {
            var entity = _mapper.Map<ProductEntity>(product);
            var result = await _dbRepository.Add(entity);

            await _dbRepository.SaveChangesAsync();

            return result;
        }

        public List<ProductModel> GetAll()
        {
            var collection = _dbRepository.GetAll<ProductEntity>();
            var result = _mapper.Map<List<ProductModel>>(collection);

            if (result == null || !result.Any())
            {
                return null;
            }

            return result;
        }

        public ProductModel Get(Guid id)
        {
            var entity = _dbRepository.Get<ProductEntity>().FirstOrDefault(x => x.Id == id);
            var model = _mapper.Map<ProductModel>(entity);
            
            return model;
        }

        public async Task<Guid> Update(ProductModel product)
        {
            var entity = _mapper.Map<ProductEntity>(product);
            
            await _dbRepository.Update<ProductEntity>(entity);
            await _dbRepository.SaveChangesAsync();
            
            return entity.Id;
        }

        public async Task Delete(Guid id)
        {
            await _dbRepository.Delete<ProductEntity>(id);
            await _dbRepository.SaveChangesAsync();
        }
    }
}