using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialCRM.Domain.Abstractions;
using SocialCRM.Domain.Models;

namespace SocialCRM.Web.Controllers
{
    public class LeadController : BaseController
    {
        private readonly ILeadService _leadService;

        public LeadController(ILeadService leadService)
        {
            _leadService = leadService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            var lead = await _leadService.Get(id);
            
            return Ok(lead);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(LeadModel leadModel)
        {
            var leadId = await _leadService.Create(leadModel);
            
            return Ok(leadId);
        }

        [HttpPut]
        public async Task<IActionResult> Update(LeadModel leadModel)
        {
            await _leadService.Update(leadModel);
            
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _leadService.Delete(id);
            
            return Ok();
        }
    }
}