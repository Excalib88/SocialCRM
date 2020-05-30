using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialCRM.Domain.Contracts.Models;

namespace SocialCRM.Domain.Contracts
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