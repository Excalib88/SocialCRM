using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SocialCRM.DAL.Entities
{
    public class OrderEntity: BaseEntity
    {
        [JsonIgnore]
        [ForeignKey("LeadId")]
        public LeadEntity Lead { get; set; }
        
        public Guid LeadId { get; set; }
        
        [JsonIgnore]
        [ForeignKey("ProductsId")]
        public List<ProductEntity> Products { get; set; }
        
        public List<Guid> ProductsId { get; set; }
    }
}