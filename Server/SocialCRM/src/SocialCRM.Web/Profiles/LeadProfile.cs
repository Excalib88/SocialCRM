using System.Collections.Generic;
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
            CreateMap<List<OrderModel>, List<OrderEntity>>();
            CreateMap<List<OrderEntity>, List<OrderModel>>();
            CreateMap<ProductModel, ProductEntity>();
            CreateMap<ProductEntity, ProductModel>();
            CreateMap<List<ProductModel>, List<ProductEntity>>();
            CreateMap<List<ProductEntity>, List<ProductModel>>();
        }
    }
}