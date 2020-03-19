using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialCRM.Domain.Models;

namespace SocialCRM.Domain.Abstractions
{
    public interface IProductService
    {
        Task<Guid> Create(ProductModel product);
        List<ProductModel> GetAll();
        ProductModel Get(Guid id);
        Task<Guid> Update(ProductModel product);
        Task Delete(Guid id);
    }
}