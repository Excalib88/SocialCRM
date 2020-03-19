using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialCRM.Domain.Abstractions;
using SocialCRM.Domain.Models;

namespace SocialCRM.Web.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<Guid>> Create(OrderModel order)
        {
            var result = await _orderService.Create(order);

            if (result == Guid.Empty)
            {
                return BadRequest("Guid is empty");
            }
            
            return Ok(result);
        }

        [HttpGet]
        public ActionResult<OrderModel> GetAll()
        {
            var collection = _orderService.GetAll();

            if (collection == null || !collection.Any())
            {
                return BadRequest("Collection is empty");
            }

            return Ok(collection);
        }

        [HttpGet("{id}")]
        public ActionResult<OrderModel> Get(Guid id)
        {
            var order = _orderService.Get(id);

            if (order == null)
            {
                return BadRequest("Order was not found");
            }
            
            return Ok(order);
        }
    }
}