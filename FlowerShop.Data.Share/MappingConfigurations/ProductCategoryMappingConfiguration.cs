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
    public class ProductCategoryMappingConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.MapKeyPrimary();
            builder.Property(x => x.Title).HasColumnName(nameof(ProductCategory.Title)).HasMaxLength(128).IsRequired();
            builder.Property(x => x.Description).HasColumnName(nameof(ProductCategory.Description)).HasMaxLength(258).IsRequired();
            builder.HasMany(x => x.Products).WithOne(x => x.ProductCategories);
        }
    }
}
