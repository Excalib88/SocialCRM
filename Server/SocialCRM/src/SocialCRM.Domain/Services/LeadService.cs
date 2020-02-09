using System;
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
    public class LeadService: ILeadService
    {
        private readonly IDbRepository _dbRepository;
        private readonly IMapper _mapper;
        private readonly UserEntity _currentUser;
        
        public LeadService(IDbRepository dbRepository, IMapper mapper, UserEntity currentUser)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
            _currentUser = currentUser;
        }
        
        public async Task<Guid> Create(LeadModel lead)
        {
            var entity = _mapper.Map<LeadEntity>(lead);
            entity.UserCreated = _currentUser.Id;
            
            var result = await _dbRepository.Add(entity);
            await _dbRepository.SaveChangeAsync();
            
            return result;
        }

        public async Task<LeadModel> Get(Guid id)
        {
            var lead = await _dbRepository.Get<LeadEntity>().FirstOrDefaultAsync(x => x.Id == id);
            var leadModel = _mapper.Map<LeadModel>(lead);

            return leadModel;
        }

        public async Task Update(LeadModel lead)
        {
            var entity = _mapper.Map<LeadEntity>(lead);
            
            await _dbRepository.SaveChangeAsync();
            await _dbRepository.Update(entity);
        }

        public async Task Delete(Guid leadId)
        {
            await _dbRepository.Delete<LeadEntity>(leadId);
            await _dbRepository.SaveChangeAsync();
        }
    }
}