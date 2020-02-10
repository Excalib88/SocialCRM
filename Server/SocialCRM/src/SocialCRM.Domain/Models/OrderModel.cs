using System.Collections.Generic;
using SocialCRM.DAL.Entities;

namespace SocialCRM.Domain.Models
{
    public class OrderModel
    {
        public LeadModel Lead { get; set; }
        public List<ProductModel> Products { get; set; }
    }
}