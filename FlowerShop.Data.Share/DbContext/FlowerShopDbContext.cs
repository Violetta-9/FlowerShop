using System;
using System.Collections.Generic;
using FlowerShop.Data.Domain.Models;
using FlowerShop.Data.Share.MappingConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.Data.Share.DbContext
{
    public class FlowerShopDbContext : IdentityDbContext<ShopUser>
    {
        public FlowerShopDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserMappingConfiguration());
        }
    }
}
