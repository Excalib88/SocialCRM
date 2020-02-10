using System;

namespace SocialCRM.Domain.Models
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime? BuyDate { get; set; }
        public DateTime? SellDate { get; set; }
    }
}