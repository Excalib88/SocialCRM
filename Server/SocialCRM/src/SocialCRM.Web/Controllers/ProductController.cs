using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialCRM.Domain.Abstractions;
using SocialCRM.Domain.Models;

namespace SocialCRM.Web.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult<ProductModel>> Create(ProductModel model)
        {
            var result = await _productService.Create(model);
            
            return Ok(result);
        }

        [HttpGet("id")]
        public ActionResult<ProductModel> Get(Guid id)
        {
            var model = _productService.Get(id);

            if (model == null)
            {
                return BadRequest("Product not found");
            }

            return Ok(model);
        }

        [HttpGet]
        public ActionResult<List<ProductModel>> GetAll()
        {
            var collection = _productService.GetAll();

            if (collection == null)
            {
                return BadRequest("Products not found");
            }

            return Ok(collection);
        }

        [HttpPut]
        public async Task<ActionResult> Update(ProductModel model)
        {
            var result = await _productService.Update(model);

            if (result == Guid.Empty)
            {
                return BadRequest("Product not updated");
            }
            
            return Ok(result);
        }

        [HttpDelete("id")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _productService.Delete(id);

            return Ok();
        }
    }
}