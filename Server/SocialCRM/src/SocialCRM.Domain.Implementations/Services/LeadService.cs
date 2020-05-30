using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialCRM.DAL.Contracts.Entities;
using SocialCRM.DAL.Contracts;
using SocialCRM.Domain.Contracts;
using SocialCRM.Domain.Contracts.Models;

namespace SocialCRM.Domain.Implementations.Services
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
            await _dbRepository.SaveChangesAsync();
            
            return result;
        }

        public async Task<LeadModel> Get(Guid id)
        {
            var lead = await _dbRepository.Get<LeadEntity>().Include(x => x.Person).FirstOrDefaultAsync(x => x.Id == id);
            var leadModel = _mapper.Map<LeadModel>(lead);
            var employees = _dbRepository.Add(new EmployeeEntity());
            await _dbRepository.SaveChangesAsync();
            return leadModel;
        }

        public async Task Update(LeadModel lead)
        {
            var entity = _mapper.Map<LeadEntity>(lead);
            
            await _dbRepository.Update(entity);
            await _dbRepository.SaveChangesAsync();
        }

        public async Task Delete(Guid leadId)
        {
            await _dbRepository.Delete<LeadEntity>(leadId);
            await _dbRepository.SaveChangesAsync();
        }
    }
}