using System.Collections.Generic;

namespace SocialCRM.DAL.Entities
{
    public class OrderEntity: BaseEntity
    {
        public LeadEntity Lead { get; set; }
        public List<ProductEntity> Products { get; set; }
    }
}