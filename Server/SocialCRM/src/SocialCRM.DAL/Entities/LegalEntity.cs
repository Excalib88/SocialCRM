using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SocialCRM.DAL.Entities
{
    public class LegalEntity: BaseEntity
    {
        [JsonIgnore]
        [ForeignKey("CompanyId")]
        public CompanyEntity Company { get; set; }
        
        public Guid CompanyId { get; set; }
        
        [JsonIgnore]
        [ForeignKey("LeadId")]
        public LeadEntity Lead { get; set; }
        
        public Guid LeadId { get; set; }
    }
}