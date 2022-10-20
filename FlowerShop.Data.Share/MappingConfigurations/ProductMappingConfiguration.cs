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
    public class ProductMappingConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.MapKeyPrimary();
            builder.Property(x => x.Title).HasColumnName(nameof(Product.Title)).HasMaxLength(128).IsRequired();
            builder.Property(x => x.Description).HasColumnName(nameof(Product.Description)).HasMaxLength(258).IsRequired();
            builder.Property(x => x.Price).HasColumnName(nameof(Product.Price)).HasMaxLength(32).IsRequired();
            builder.Property(x => x.IsHidden).HasColumnName(nameof(Product.IsHidden));
            builder.Property(x => x.ProductCategoryId).HasColumnName(nameof(Product.ProductCategoryId));
            builder.HasOne(x => x.ProductCategories).WithMany(x => x.Products);
            builder.HasMany(x => x.ProductImages).WithOne(x => x.Products);

        }
    }
}
