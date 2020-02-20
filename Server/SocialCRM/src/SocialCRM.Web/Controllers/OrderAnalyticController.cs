using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialCRM.Domain.Abstractions;

namespace SocialCRM.Web.Controllers
{
    public class OrderAnalyticController : BaseController
    {
        private readonly IOrderAnalyticService _orderStatisticService;

        public OrderAnalyticController(IOrderAnalyticService orderStatisticService)
        {
            _orderStatisticService = orderStatisticService;
        }

        [HttpGet("get_amount_price")]
        public async Task<ActionResult<int>> GetAmountPriceByCompany(Guid companyId)
        {
            var result = await _orderStatisticService.GetAmountByCompany(companyId);

            return Ok(result);
        }
    }
}