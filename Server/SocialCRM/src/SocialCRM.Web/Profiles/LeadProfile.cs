using System.Collections.Generic;
using AutoMapper;
using SocialCRM.DAL.Contracts.Entities;
using SocialCRM.Domain.Contracts.Models;

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
            CreateMap<PersonModel, PersonEntity>();
            CreateMap<PersonEntity, PersonModel>();
        }
    }
}