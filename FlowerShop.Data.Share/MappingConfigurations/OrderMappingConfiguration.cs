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
            builder.Property(x => x.FlowerId).HasColumnName(nameof(Order.FlowerId)).IsRequired();
        }
    }
}
