using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using FlowerShop.Data.Domain.Models;
using FlowerShop.Data.Share.MappingConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlowerShop.Data.Share.DbContext
{
    public class FlowerShopDbContext : IdentityDbContext<ShopUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Order> ProductOrders { get; set; }

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
