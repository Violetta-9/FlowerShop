using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerShop.Data.Domain.Models;
using FlowerShop.Data.Share.MappingConfigurations.Exstension;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlowerShop.Data.Share.MappingConfigurations
{
    public class ProductItemMappingConfiguration : IEntityTypeConfiguration<ProductItem>
    {
        public void Configure(EntityTypeBuilder<ProductItem> builder)
        {
            builder.MapKeyPrimary();
            builder.Property(x => x.UserId).HasColumnName(nameof(ProductItem.UserId)).IsRequired();
            builder.Property(x => x.Quentity).HasColumnName(nameof(ProductItem.Quentity)).IsRequired();
            builder.Property(x => x.OrderId).HasColumnName(nameof(ProductItem.OrderId));
            builder.Property(x => x.ProductId).HasColumnName(nameof(ProductItem.ProductId)).IsRequired();
            builder.HasOne(x => x.Order).WithMany(x => x.ProductsList);
            builder.HasOne(x => x.User).WithMany(x=>x.ProductsList);
            builder.HasOne(x => x.Product).WithMany(x=>x.ProductList);
        }
    }
}
