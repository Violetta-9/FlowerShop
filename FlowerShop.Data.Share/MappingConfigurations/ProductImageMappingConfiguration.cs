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
    public class ProductImageMappingConfiguration: IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.MapKeyPrimary();
            builder.Property(x => x.FileName).HasColumnName(nameof(ProductImage.FileName)).HasMaxLength(512)
                .IsRequired();
            builder.Property(x => x.Path).HasColumnName(nameof(ProductImage.Path)).HasMaxLength(1024).IsRequired();
            builder.Property(x=>x.ContainerName).HasColumnName(nameof(ProductImage.ContainerName)).HasMaxLength(512).IsRequired();
            builder.HasOne(x => x.Products).WithMany(x => x.ProductImages);

        }
    }
}
