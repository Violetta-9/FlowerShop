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
    public  class OrderMappingConfiguration: IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.MapKeyPrimary();
            builder.Property(x => x.UserId).HasColumnName(nameof(Order.UserId)).IsRequired();
            builder.Property(x => x.TotalPrice).HasColumnName(nameof(Order.TotalPrice)).IsRequired();
            builder.Property(x => x.Address).HasColumnName(nameof(Order.Address)).IsRequired();
            builder.Property(x => x.Quentity).HasColumnName(nameof(Order.Quentity)).IsRequired();
            builder.Property(x => x.TimeOfOrder).HasColumnName(nameof(Order.TimeOfOrder)).IsRequired();
            builder.HasOne(x => x.User).WithMany(x => x.Orders);
            builder.HasMany(x => x.ProductsList).WithOne(x => x.Order);

        }
    }
}
