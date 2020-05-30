using System.Collections.Generic;

namespace SocialCRM.Domain.Contracts.Models
{
    public class OrderModel
    {
        public LeadModel Lead { get; set; }
        public List<ProductModel> Products { get; set; }
    }
}