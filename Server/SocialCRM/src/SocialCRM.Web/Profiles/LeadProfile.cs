using AutoMapper;
using SocialCRM.DAL.Entities;
using SocialCRM.Domain.Models;

namespace SocialCRM.Web.Profiles
{
    public class LeadProfile: Profile
    {
        public LeadProfile()
        {
            CreateMap<LeadEntity, LeadModel>();
            CreateMap<LeadModel, LeadEntity>();
            CreateMap<OrderModel, OrderEntity>();
            CreateMap<OrderEntity, OrderModel>();
        }
    }
}