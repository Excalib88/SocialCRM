using System;

namespace SocialCRM.DAL.Entities
{
    public class ProductEntity: BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime? BuyDate { get; set; }
        public DateTime? SellDate { get; set; }
    }
}