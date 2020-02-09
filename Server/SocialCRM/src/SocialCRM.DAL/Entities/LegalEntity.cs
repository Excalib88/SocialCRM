namespace SocialCRM.DAL.Entities
{
    public class LegalEntity: BaseEntity
    {
        public CompanyEntity Company { get; set; }
        public LeadEntity Lead { get; set; }
    }
}